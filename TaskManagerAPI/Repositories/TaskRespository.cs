using System;
using TaskManagerAPI.Data;
using TaskManagerAPI.Interfaces;
using TaskManagerAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace TaskManagerAPI.Repositories;

public class TaskRespository : ITaskRespository
{
    private ApiDbContext dbContext;

    public TaskRespository(ApiDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    public async Task AddTask(TaskItem item)
    {
        await dbContext.TaskItems.AddAsync(item);
        // You need to call the SaveChanges() method for add, update and delete.
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTask(int id)
    {
        var existingTaskItem = await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
        if (existingTaskItem != null)
        {
            dbContext.TaskItems.Remove(existingTaskItem);
            await dbContext.SaveChangesAsync();
        }
    }

    public async Task<IEnumerable<TaskItem>> GetAllTasks()
    {
        return await dbContext.TaskItems.ToListAsync();
    }

    public async Task<TaskItem> GetTaskById(int id)
    {
        return await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
    }

    public async Task UpdateTask(int id, TaskItem item)
    {
        var existingTaskItem = await dbContext.TaskItems.FirstOrDefaultAsync(t => t.Id == id);
        if (existingTaskItem != null)
        {
            // dbContext.TaskItems.Entry(existingTaskItem).CurrentValues.SetValues(taskItem);
            existingTaskItem.Title = item.Title;
            existingTaskItem.Description = item.Description;
            await dbContext.SaveChangesAsync();
        }
    }
}
