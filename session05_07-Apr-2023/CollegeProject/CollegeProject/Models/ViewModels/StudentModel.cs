namespace CollegeProject.Models.ViewModels {
    public class StudentModel {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int CourseId { get; set; }
        public IFormFile Image { get; set; }

        // public string CourseName { get; set; }
        // public decimal CourseFee { get; set; }

        public static void MapStudent(Student source, StudentModel destination) {
            destination.Name = source.Name;
            destination.Phone = source.Phone;
            destination.Email = source.Email;
            // destination.CourseName = source.Course?.Name;
            // destination.CourseFee = source.Course.CourseFees;
        }

        public static void MapStudent(StudentModel source, Student destination) {
            destination.Name = source.Name;
            destination.Phone = source.Phone;
            destination.Email = source.Email;
        }
    }
}
