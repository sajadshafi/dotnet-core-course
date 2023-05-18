using TaskTracker.Helpers;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.IServices {
    public interface ITaskRepository {
        Task<Response<IEnumerable<ProjectTaskVM>>> GetAllTasksAsync();
        Task<Response<ProjectTaskVM>> SaveTaskAsync(ProjectTaskVM model);
        Task<Response<Guid?>> DeleteTaskAsync(Guid? id);
        Task<Response<ProjectTaskVM>> GetByIdAsync(Guid? id);
    }
}
