using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TodoList.Application.Contracts.Persistence;
using TodoList.Application.DTOs;
using TodoList.Domain;
using TodoList.Domain.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TodoList.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoItemsController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ITodoItemRepository _todoItem;
        private readonly IMapper _mapper;

        public TodoItemsController(UserManager<ApplicationUser> userManager,
            ITodoItemRepository todoItem,
            IMapper mapper)
        {
            _userManager = userManager;
            _todoItem = todoItem;
            _mapper = mapper;
        }

        // GET: api/<TodoItemsController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetAllTodos()
        {

            //var items = await _todoItem.GetAll();
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var items = new List<TodoItem>();
            items.AddRange(await _todoItem.GetCompleteItems(user));
            items.AddRange(await _todoItem.GetIncompleteItems(user));

            return Ok(items);
        }

        // Get done/non-done items
        [HttpGet("complete")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetCompleteItemsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var items = await _todoItem.GetCompleteItems(user);

            return Ok(items);
        }

        [HttpGet("incomplete")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetIncompleteItemsAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var items = await _todoItem.GetIncompleteItems(user);

            return Ok(items);
        }

        // Get items by tag
        [HttpGet("bytag/{tag}")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetItemsByTag(string tag)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }
            var items = await _todoItem.GetItemsByTag(user, tag);

            return Ok(items);
        }

        // Get item by Id
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetItemById(Guid id)
        {
            var item = await _todoItem.GetItem(id);
            if (item == null)
            {
                //"Item with id {id} not found.");
                return NotFound();
            }

            return Ok(item);
        }

        // Create item
        [HttpPost]
        public async Task<ActionResult<TodoItem>> CreateItem([FromBody] TodoItemDto item)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            if (item == null)
            {
                //"Received null item.");
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            if (item.Done == null) item.Done = false;

            // create mapping
            var dbItem = _mapper.Map<TodoItem>(item);
            await _todoItem.AddItem(dbItem, user);

            //"Created new TodoItem with id {dbItem.Id}");
            return CreatedAtAction(nameof(GetItemById), new { Id = dbItem.Id }, dbItem);
        }

        // Update item
        [HttpPut("{id}")]
        public async Task<ActionResult<TodoItem>> UpdateItem([FromBody] TodoItemDto newItem, Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            if (newItem == null)
            {
                //"Received null item."
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                //"Received invalid item."
                return BadRequest();
            }

            if (newItem.Done == null) newItem.Done = false;

            var dbItem = await _todoItem.GetItem(id);
            if (dbItem == null)
            {
                //"Item with id {id} not found."
                return NotFound();
            }

            dbItem = _mapper.Map<TodoItem>(newItem);
            if (dbItem.Done)
                await _todoItem.UpdateDone(id, user);
            else
                await _todoItem.UpdateItem(dbItem, user);

            //"Updated item with id {dbItem.Id}."
            return NoContent();
        }

        // Update status
        [HttpPatch("{id:Guid}/{status:bool}")]
        public async Task<ActionResult> UpdateStatus(Guid id, bool status)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            var item = await _todoItem.GetItem(id);
            if (item == null)
            {
                //"Item with id {id} not found."
                return NotFound();
            }

            if (status)
            {
                await _todoItem.UpdateDone(id, user);
            }

            //"Item with id {id} was set to DONE.");
            return NoContent();
        }

        // Delete item
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteItem(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Unauthorized();
            }

            await _todoItem.DeleteItem(id, user);

            //"Removed item with id {id}."
            return NoContent();
        }
    }
}
