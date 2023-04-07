using EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCore {
    public class Program {
        public static void Main(string[] args) { 
            ApplicationDbContext context = new ApplicationDbContext();

            //Department department = new Department {
            //    Name= "CSC",
            //};
            //context.Departments.Add(department);


            //var Dept = context.Departments.Where(x => x.Name.Equals("CSC")).Select(x => x.Id).FirstOrDefault();

            //Employee employee = new Employee {
            //    Name = "Sajad",
            //    EmployeeId = "TIS123",
            //    DepartmentId = Dept
            //};
            //context.Employees.Add(employee);
            //context.SaveChanges();
            //IList, ArrayList, IArrayList, Enumerable, IEnumerable, IQueryable

            //IQueryable<Employee> employees = new();
            //IEnumerable<Employee> employees2 = new();

            //var emps = context.Employees.Where(x => x.Name.Equals("Sajad")).ToList();

            var Emp = context.Employees.AsNoTracking().FirstOrDefault();

            Emp.Name = "SajadShafi 987978";
         
            context.SaveChanges();
                
            //Console.Write(emps.Count);
            //foreach (var employee in emps) {
            //    Console.WriteLine(employee.Name + "\n");
            //}
        }
    }
}