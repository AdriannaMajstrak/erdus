using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using erdus.ng.DTO;

namespace erdus.ng.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestDeleted> RequestsDeleted { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Category> Categories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Request>()
                .Property(b => b.CreationDate)
                .HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }

        //public DbSet<erdus.ng.ViewModels.StatusEditViewModel> StatusEditViewModel { get; set; }

        //public DbSet<erdus.ng.ViewModels.IndexRequestViewModel> IndexRequestViewModel { get; set; }

       // public DbSet<erdus.ng.ViewModels.DetailsRequestViewModel> DetailsRequestViewModel { get; set; }

       // public DbSet<erdus.ng.ViewModels.AdvancedEditViewModel> AdvancedEditViewModel { get; set; }


    }
}
