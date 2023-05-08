using Microsoft.EntityFrameworkCore;

namespace AuthBasic.Models {
    public class TodoContext : DbContext {
        public TodoContext(DbContextOptions<TodoContext> options) 
            : base(options)
        {}

        public DbSet<User> Users { get; set; }
    }
}
