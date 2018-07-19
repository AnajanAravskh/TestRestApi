using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace DAL.Context
{
    public class ResourcesContext: DbContext
    {
        public ResourcesContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Resource> Resources { get; set; }

        public override int SaveChanges()
        {
            var entities = from e in ChangeTracker.Entries()
                           where e.State == EntityState.Added
                               || e.State == EntityState.Modified
                           select e.Entity;
            foreach (var entity in entities)
            {
                var validationContext = new ValidationContext(entity);
                Validator.ValidateObject(
                    entity,
                    validationContext,
                    validateAllProperties: true);
            }

            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Resource>().HasData(new Resource { Id = 1, Name = "Vasya", CustomProperty2 = "Some data", CustomProperty3 = DateTime.Now, CustomProperty5 = 5 },
                                                    new Resource { Id = 2, Name = "Andy", CustomProperty2 = "Some data2", CustomProperty3 = DateTime.Now, CustomProperty4 = 10.5m, CustomProperty5 = 6 });
            base.OnModelCreating(modelBuilder);
        }
    }
}
