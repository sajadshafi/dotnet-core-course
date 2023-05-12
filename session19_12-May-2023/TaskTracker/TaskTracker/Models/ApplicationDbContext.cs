using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TaskTracker.Models {
    public class ApplicationDbContext : IdentityDbContext<SystemUser, SystemRole, Guid> {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    foreach (var type in modelBuilder.Model.GetEntityTypes()) {
        //        if (typeof(IBaseEntity).IsAssignableFrom(type.ClrType))
        //            modelBuilder.SetSoftDeleteFilter(type.ClrType);
        //    }
        //    base.OnModelCreating(modelBuilder);
        //}

        public override int SaveChanges() {
            UpdateSoftDeleteStatuses();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default) {
            UpdateSoftDeleteStatuses();
            return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
        }

        private void UpdateSoftDeleteStatuses() {
            foreach (var entry in ChangeTracker.Entries()) {
                switch (entry.State) {
                    case EntityState.Added:
                        entry.CurrentValues["IsDeleted"] = false;
                        break;
                    case EntityState.Deleted:  // remove
                        entry.State = EntityState.Modified;
                        entry.CurrentValues["IsDeleted"] = true;
                        break;
                }
            }
        }
    }
}
