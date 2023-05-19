using TaskTracker.Utilities;
using Microsoft.AspNetCore.Identity;

namespace TaskTracker.Models.ViewModels {
    public class ProjectTaskVM {
        public Guid? Id { get; set; }
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        public int Priority { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public int TaskType { get; set; }
        public Guid? UserId { get; set; }
        public string PriorityName { get; set; }
        public string TaskTypeName { get; set; }

        public void MapEntityToVM(ProjectTask source, ProjectTaskVM destination) {
            destination.Id = source.Id;
            destination.TaskName = source.TaskName;
            destination.TaskDescription = source.TaskDescription;
            destination.IsCompleted = source.IsCompleted;
            destination.Deadline = source.Deadline;
            destination.TaskType = (int)source.TaskType;
            destination.Priority = (int)source.Priority;
            destination.UserId = source.UserId;
            destination.PriorityName = source.Priority.ToString();
            destination.TaskTypeName = source.TaskType.ToString();
        }

        public void MapVMToEntity(ProjectTaskVM source, ProjectTask destination) {
            destination.TaskName = source.TaskName;
            destination.TaskDescription = source.TaskDescription;
            destination.IsCompleted = source.IsCompleted;
            destination.Deadline = source.Deadline;
            destination.TaskType = (TaskType)source.TaskType;
            destination.Priority = (TaskPriority)source.Priority;
            destination.UserId = source.UserId;

            if(Id != null) {
                destination.Id = (Guid)source.Id;
                destination.ModifiedDate = DateTime.Now;

            } else {
                destination.CreatedDate = DateTime.Now;
            }
        }
    }
}
