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
    }
}
