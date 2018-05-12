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

        [HttpGet("{itemId}/{valueId}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult GetItemValueByIdOfItem(long itemId, long valueId)
        {
            try
            {
                _context.TodoItems.UpdateRange();
                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == itemId);
                if (item == null)
                {
                    return NotFound();
                }

                double value = 0;

                if (item.Values != null)
                {
                    value = item.Values.First(v => v.Id == valueId).Value;
                }

                return new ObjectResult(value);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }

        [HttpPost("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult AddValue(long id, [FromBody] TodoItemValue itemValue)
        {
            try
            {
                if (itemValue == null || id.Equals(null))
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

                todo.Values.Add(itemValue);
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

        [HttpPut("{itemId}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult UpdateValue(long itemId, [FromBody] TodoItemValue value)
        {
            try
            {
                if (value == null)
                {
                    return BadRequest();
                }

                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == itemId);

                if (item == null)
                {
                    return NotFound();
                }

                var val = item.Values.FirstOrDefault(v => v.Id == value.Id);

                if (val == null)
                {
                    AddValue(itemId, value);
                }
                else
                {
                    val.Value = value.Value;
                }

                _context.TodoItems.Update(item);
                _context.SaveChanges();
                return new ObjectResult($"New value is '{val?.Value}' in item {item.Id} for value {val?.Id}");
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

        [HttpDelete("{id}")]
        [ActionFilter]
        [ValidationModel]
        public IActionResult DeleteAllValues(long id)
        {
            try
            {
                var item = _context.TodoItems.Include(ti => ti.Values).FirstOrDefault(t => t.Id == id);
                if (item == null)
                {
                    return NotFound();
                }

                List<TodoItemValue> values = item.Values.ToList();

                if (values.Count == 0)
                {
                    return NotFound();
                }

                _context.TodoItemValues.RemoveRange(values);
                _context.SaveChanges();

                string result = $"All Values from item: {item.Id} was deleted";

                return new ObjectResult(result);
            }
            catch (Exception e)
            {
                return BadRequest("Wrong request: " + e.Message);
            }
        }
    }
}