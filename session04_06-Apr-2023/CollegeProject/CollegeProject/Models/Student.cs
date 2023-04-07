using System.ComponentModel.DataAnnotations.Schema;

namespace CollegeProject.Models {
    public class Student {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CourseId { get; set; }

        [ForeignKey("CourseId")]
        public Course Course { get; set; }
    }
}
