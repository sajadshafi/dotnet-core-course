using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
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
        public IActionResult Index() {
            return View();
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
    }
}
