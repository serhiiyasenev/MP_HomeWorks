﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Filters;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/items")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                context.Database.OpenConnection();
                context.Database.ExecuteSqlCommand("SET IDENTITY_INSERT dbo.TodoItems ON; INSERT INTO dbo.TodoItems (Id, Name, IsComplete) VALUES (0, 'test1', 1);");
                _context.TodoItems.Add(
                    new TodoItem
                    {
                        Id = 1,
                        Name = "Item1",
                        IsComplete = true,
                        Values = new List<TodoItemValue> {
                            new TodoItemValue { Id = 22, Value = 22 }
                        }

                    }
                );
                _context.SaveChanges();
            }
        }

        [HttpGet]
        [ActionFilter]
        [ValidationModel]
        public IEnumerable<TodoItem> GetAll()
        {
            IEnumerable<TodoItem> allItems;
            try
            {
                _context.TodoItems.UpdateRange();
                //var items =
                //    from ti in _context.TodoItems
                //    select new
                //    {
                //        ti,
                //        ti.Values
                //    };
                allItems = _context.TodoItems.Include(ti => ti.Values).ToList();
            }
            catch (Exception)
            {
                allItems = null;
            }
            return allItems;
        }

        [HttpGet("{id:int}", Name = "GetTodo")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult GetById(int id)
        {
            try
            {
                _context.TodoItems.UpdateRange();
                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                return new ObjectResult(item);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpPost]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Create([FromBody] TodoItem item)
        {
            try
            {
                if (item == null)
                {
                    return BadRequest();
                }

                List<TodoItem> items = _context.TodoItems.ToList();

                if (items.Count(it => it.Id == item.Id) != 0)
                {
                    return BadRequest("Wrong request: item with id " + item.Id + " has already been added");
                }

                if (item.Values == null)
                {
                    item.Values = new List<TodoItemValue>();
                }
                foreach (var val in item.Values)
                {
                    _context.TodoItemValues.Add(val);
                }

                _context.TodoItems.Add(item);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = item.Id, name = item.Name, isComplete = item.IsComplete, values = item.Values }, item);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpPut("{id:int}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Update(int id, [FromBody] TodoItem item)
        {
            try
            {
                if (item == null || item.Id != id)
                {
                    return BadRequest();
                }

                var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
                if (todo == null)
                {
                    return NotFound();
                }

                todo.IsComplete = item.IsComplete;
                todo.Name = item.Name;
                todo.Values = item.Values;

                _context.TodoItems.Update(todo);
                _context.SaveChanges();
                return CreatedAtRoute("GetTodo", new { id = item.Id, name = item.Name, isComplete = item.IsComplete, values = item.Values }, item);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpDelete("{id:int}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Delete(int id)
        {
            try
            {
                var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
                if (todo == null)
                {
                    return NotFound();
                }

                _context.TodoItems.Remove(todo);
                _context.SaveChanges();
                return new NoContentResult();
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }
    }
}