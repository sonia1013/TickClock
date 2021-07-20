using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TickClock.Models;
using TickClock.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TickClock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly ClockService _clockService;
        
        public TodoController(ClockService clockService)
        {
            _clockService = clockService;
        }
        
        // GET: api/<TodoController>
        [HttpGet]
        public ActionResult<List<TodoItem>> Get()=>
            _clockService.Get();
            //return new string[] { "value1", "value2" };

        // GET api/<TodoController>/5
        [HttpGet("{id}")]
        public ActionResult<TodoItem> Get(string id)
        {
            var todoItem = _clockService.Get(id);

            if ( todoItem == null ) return NotFound();

            return todoItem;
        }

        // POST api/<TodoController>
        [HttpPost]
        public ActionResult<TodoItem> Post(TodoItem todoItem)
        {
            _clockService.Create(todoItem);

            return CreatedAtRoute("GetTodoItem", new { Id = todoItem.Id.ToString() }, todoItem);
        }

        // PUT api/<TodoController>/5
        [HttpPut("{id}")]
        public IActionResult Update(string id, TodoItem todoItem)
        {
            var item = _clockService.Get(id);

            if ( item == null ) return NotFound();

            _clockService.Update(id, todoItem);

            return NoContent();
        }

        // DELETE api/<TodoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var item = _clockService.Get(id);

            if ( item == null ) return NotFound();

            _clockService.Remove(item.Id);

            return NoContent();
        }
    }
}
