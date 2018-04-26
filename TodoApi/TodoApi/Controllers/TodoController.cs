using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Filters;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    public class TodoController : Controller
    {
        private readonly TodoContext _context;

        public TodoController(TodoContext context)
        {
            _context = context;

            if (!_context.TodoItems.Any())
            {
                _context.TodoItems.Add(new TodoItem { Name = "Item1" });
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
                allItems = _context.TodoItems.ToList();
            }
            catch (Exception)
            {
                allItems = null;
            }
            return allItems;
        }

        [HttpGet("{id}", Name = "GetTodo")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult GetById(long id)
        {
            try
            {
                _context.TodoItems.UpdateRange();
                var item = _context.TodoItems.FirstOrDefault(t => t.Id == id);
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

                _context.TodoItems.Add(item);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = item.Id, name = item.Name, isComplete = item.IsComplete, values = item.Values }, item);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpPut("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Update(long id, [FromBody] TodoItem item)
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
                return new NoContentResult();
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpPost("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult AddValues(long id, [FromBody] TodoItemValue itemValues)
        {
            try
            {
                if (itemValues == null || id.Equals(null))
                {
                    return BadRequest();
                }

                var todo = _context.TodoItems.FirstOrDefault(t => t.Id == id);
                if (todo == null)
                {
                    return NotFound();
                }

                if (todo.Values == null)
                {
                    todo.Values = new List<TodoItemValue>();
                }

                todo.Values.Add(itemValues);

                _context.TodoItems.Update(todo);
                _context.SaveChanges();

                return CreatedAtRoute("GetTodo", new { id = todo.Id, name = todo.Name, isComplete = todo.IsComplete, values = todo.Values }, todo);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpDelete("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Delete(long id)
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