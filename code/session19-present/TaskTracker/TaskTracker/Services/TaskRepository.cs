using Microsoft.EntityFrameworkCore;
using TaskTracker.Helpers;
using TaskTracker.IServices;
using TaskTracker.Models;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.Services {
    public class TaskRepository : ITaskRepository {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<TaskRepository> _logger;

        public TaskRepository(ApplicationDbContext context, ILogger<TaskRepository> logger) {
            this._context = context;
            this._logger = logger;
        }
        public async Task<Response<Guid?>> DeleteTaskAsync(Guid? id) {
            Response<Guid?> response = new() { Data = null };
            if(id == null) {
                response.Message = "Id not valid";
                return response;
            } 
            try {
                ProjectTask task = await _context.ProjectTasks.FirstOrDefaultAsync(x => x.Id == id);

                if (task == null) {
                    response.Message = "Task not found!";
                    return response;
                }

                response.Data = task.Id;
                _context.ProjectTasks.Remove(task);
                await _context.SaveChangesAsync();

                response.Message = "Task Deleted successfully!";
                response.Count = 1;
                return response;

            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                response.Success = false;
                return response;
            }
        }

        public async Task<Response<List<ProjectTaskVM>>> GetAllTasksAsync() {
            Response<List<ProjectTaskVM>> response = new() {
                Data = new List<ProjectTaskVM>()
            };

            List<ProjectTask> tasks = await _context.ProjectTasks.ToListAsync();

            foreach(var task in tasks) {
                ProjectTaskVM temp = new ProjectTaskVM();
                new ProjectTaskVM().MapEntityToVM(task, temp);
                response.Data.Add(temp);
            }

            return response;
        }

        public async Task<Response<ProjectTaskVM>> GetByIdAsync(Guid? id) {
            Response<ProjectTaskVM> response = new Response<ProjectTaskVM>();

            if (id == null) {
                response.Message = "Id not valid";
                return response;
            }

            try {
                ProjectTask task = await _context.ProjectTasks.FindAsync(id);

                if (task == null) {
                    response.Message = "Task not found!";
                    return response;
                }

                ProjectTaskVM taskVM = new ProjectTaskVM();
                new ProjectTaskVM().MapEntityToVM(task, taskVM);

                response.Data = taskVM;
                response.Count = 1;
                response.Message = "Task retrieved successfully!";

                return response;
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                response.Success = false;
                response.Message = "An error occurred while retrieving task.";
                return response;
            }
        }

        public async Task<Response<ProjectTaskVM>> SaveTaskAsync(ProjectTaskVM model) {
            Response<ProjectTaskVM> response = new Response<ProjectTaskVM>();

            try {
                ProjectTask task;

                if (model.Id == null) {
                    task = new ProjectTask();
                    new ProjectTaskVM().MapVMToEntity(model, task);
                    _context.ProjectTasks.Add(task);
                    await _context.SaveChangesAsync();
                    response.Message = "Task created successfully!";
                    model.Id = task.Id;
                    response.Data = model;
                    return response;
                } else {
                    task = await _context.ProjectTasks.FindAsync(model.Id);

                    if (task == null) {
                        response.Message = "Task not found!";
                        return response;
                    }
                    new ProjectTaskVM().MapVMToEntity(model, task);

                    await _context.SaveChangesAsync();

                    response.Data = model;
                    response.Count = 1;

                    response.Message = "Task updated successfully!";
                    return response;
                }
            } catch (Exception ex) {
                _logger.LogError(ex.ToString());
                response.Success = false;
                response.Message = "An error occurred while saving task.";
                return response;
            }
        }
    }
}
