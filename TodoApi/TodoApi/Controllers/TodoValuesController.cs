using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Filters;
using TodoApi.Models;

namespace TodoApi.Controllers
{
    [Route("api/values")]
    public class TodoValuesController : Controller
    {
        private readonly TodoContext _context;

        public TodoValuesController(TodoContext context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult GetItemValuesByIdOfItem(long id)
        {
            try
            {
                _context.TodoItems.UpdateRange();
                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                return new ObjectResult(item.Values);
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

                return CreatedAtRoute("GetTodo", new
                {
                    id = todo.Id,
                    name = todo.Name,
                    isComplete = todo.IsComplete,
                    values = todo.Values
                }, _context.TodoItems.Where(item => item.Id == id).Select(item => item.Values));
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpDelete("{id}/{valueId}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult Delete(long id, long valueId)
        {
            try
            {
                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                var value = item.Values.FirstOrDefault(v => v.Id == valueId);

                if (value == null)
                {
                    return NotFound();
                }

                _context.TodoItemValues.Remove(value);
                _context.SaveChanges();

                string result = $"Value with id '{value.Id}' and value '{value.Value}' was deleted " +
                                $"from item: {item.Id}";

                return new ObjectResult(result);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }
    }
}