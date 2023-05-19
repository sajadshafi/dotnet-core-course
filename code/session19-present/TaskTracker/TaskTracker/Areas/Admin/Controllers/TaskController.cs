using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using TaskTracker.Helpers;
using TaskTracker.IServices;
using TaskTracker.Models.ViewModels;

namespace TaskTracker.Areas.Admin.Controllers {

    [Area("Admin")]
    public class TaskController : Controller {
        private readonly ITaskRepository _taskRepo;
        private readonly IToastNotification _toast;

        public TaskController(ITaskRepository taskRepo, IToastNotification toast) {
            this._taskRepo = taskRepo;
            this._toast = toast;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Index() {
            List<ProjectTaskVM> tasks = await _taskRepo.GetAllTasksAsync();
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> AddTask(ProjectTaskVM model) {
            var result = await _taskRepo.SaveTaskAsync(model);
            if(result.Success) {
                _toast.AddSuccessToastMessage(result.Message);
            } else {
                _toast.AddErrorToastMessage(result.Message);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult GetTask(Guid? taskId) {
            // Code to retrieve the task with the specified taskId
            var task = _taskRepo.GetByIdAsync(taskId);
            return View(task);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteTask(Guid? taskId) {
            // Code to delete the task with the specified taskId
            var result = await _taskRepo.DeleteTaskAsync(taskId);
            if (result.Success) {
                _toast.AddSuccessToastMessage(result.Message);
            } else {
                _toast.AddErrorToastMessage(result.Message);
            }
            return Ok(result);
        }
    }
}
