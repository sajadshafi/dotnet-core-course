using System.ComponentModel.DataAnnotations.Schema;
using TaskTracker.Utilities;

namespace TaskTracker.Models {
    public class ProjectTask : BaseEntity {
        public string TaskName { get; set; }
        public string TaskDescription { get; set; } = string.Empty;
        public TaskPriority Priority { get; set; }
        public DateTime Deadline { get; set; }
        public bool IsCompleted { get; set; }
        public TaskType TaskType { get; set; }

        public Guid? UserId { get; set; }

        [ForeignKey("UserId")]
        public SystemUser SystemUser { get; set; }
    }
}
