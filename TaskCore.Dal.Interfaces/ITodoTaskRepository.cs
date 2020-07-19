using System.Collections.Generic;
using TaskCore.Dal.Models;

namespace TaskCore.Dal.Interfaces
{
    public interface ITodoTaskRepository
    {
        TodoTask Get(long taskId);

        IReadOnlyList<TodoTask> GetByCategory(string categoryId);

        void Add(TodoTask task);

        bool Delete(string taskId);

        IReadOnlyList<TodoTask> GetAll(bool includeCompletedTasks);
        
        IReadOnlyList<long> GetTasksSortedByIdDesc(bool includeCompletedTasks = false);
        
        void Update(TodoTask task);
    }
}