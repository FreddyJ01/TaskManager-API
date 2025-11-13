using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TaskManagerAPI.Data;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;
using TaskManagerAPI.Repositories;

namespace TaskManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskItemsController : ControllerBase
    {
        // We inject the ITaskRepository to allow our controller to access our methods that access our DB and perform the code we want to execute.

        private ITaskRespository taskRespository;


        public TaskItemsController(ITaskRespository taskRespository)
        {
            this.taskRespository = taskRespository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok();
            // return await taskRespository.GetAllTasks();
        }

        [HttpGet("{id}")]
        public async Task<TaskItem> Get(int id)
        {
            return await taskRespository.GetTaskById(id);
        }

        [HttpPost]
        public async Task Post([FromBody] TaskItem taskItem)
        {
            await taskRespository.AddTask(taskItem);
        }

        [HttpPut("{id}")]
        public async Task Put(int id, [FromBody] TaskItem taskItem)
        {
            await taskRespository.UpdateTask(id, taskItem);
        }

        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await taskRespository.DeleteTask(id);
        }

    }
}
