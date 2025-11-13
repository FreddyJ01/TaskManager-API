using System;
using TaskManagerAPI.Models;

namespace TaskManagerAPI.Interfaces;

public interface ITaskRespository
{
    // Get All Tasks

    Task<IEnumerable<TaskItem>> GetAllTasks();

    // Get Task By Id

    Task<TaskItem> GetTaskById(int id);

    // Add Task

    Task AddTask(TaskItem item);

    // Update Task

    Task UpdateTask(int id, TaskItem item);

    // Delete Task

    Task DeleteTask(int id);
}
