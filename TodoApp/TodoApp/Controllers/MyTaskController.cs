using BusinessObject;
using DataAccess.Repository.MyTaskRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TodoApp.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class MyTaskController : ControllerBase
	{
		private readonly IMyTaskRepository _myTaskRepository;

		public MyTaskController(IMyTaskRepository myTaskRepository)
		{
			_myTaskRepository = myTaskRepository;
		}

		[HttpGet("all")]
		public IActionResult GetAllTask()
		{
			try
			{
				var allTask = _myTaskRepository.GetAll();
				if (allTask != null)
				{
					return Ok(allTask);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpGet("{id}")]
		public IActionResult GetTask(string id)
		{
			try
			{
				var task = _myTaskRepository.GetById(id);
				if (task != null)
				{
					return Ok(task);
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpPost("create")]
		public IActionResult CreateTask(MyTask task)
		{
			try
			{
				_myTaskRepository.Create(task);
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpPut("update/{id}")]
		public IActionResult UpdateTask(MyTask task, string id)
		{
			try
			{
				var taskFound = _myTaskRepository.GetById(id);
				if (taskFound != null)
				{
					_myTaskRepository.Update(task, id);
					return Ok();
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpDelete("delete/{id}")]
		public IActionResult DeleteTask(string id)
		{
			try
			{
				var taskFound = _myTaskRepository.GetById(id);
				if (taskFound != null)
				{
					_myTaskRepository.Delete(id);
					return Ok();
				}
				return NotFound();
			}
			catch (Exception ex)
			{
				return BadRequest(new { message = ex.Message });
			}
		}

		[HttpDelete("deleteAll")]
		public IActionResult DeleteAllTask()
		{
			try
			{
				_myTaskRepository.DeleteAll();
				return Ok();
			}
			catch (Exception ex)
			{
				return BadRequest(ex.Message);
			}
		}
	}

}
