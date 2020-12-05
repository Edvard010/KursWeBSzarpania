using HelloWorld.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models
{
    public class SzkolaDbContext : DbContext
    {
        public SzkolaDbContext(DbContextOptions options) : base(options) { }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<ProjectEntity> Projects { get; set; }
        public DbSet<UserProjectEntity> UserProject { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserProjectEntity>()
                .HasKey(up => new { up.UserId, up.ProjectId });
            modelBuilder.Entity<UserProjectEntity>()
                .HasOne(up => up.User)
                .WithMany(up => up.UserProject)
                .HasForeignKey(up => up.UserId);
            modelBuilder.Entity<UserProjectEntity>()
                .HasOne(up => up.Project)
                .WithMany(up => up.UserProject)
                .HasForeignKey(up => up.ProjectId);
        }
    }
}
