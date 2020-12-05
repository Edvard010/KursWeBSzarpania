using HelloWorld.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models.Services
{
    public class ProjectService
    {
        private SzkolaDbContext _context;
        public ProjectService(SzkolaDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var entity = new ProjectEntity
            {
                Name = "Project1",
                Description = "Desc"
            };
            _context.Projects.Add(entity);
            _context.SaveChanges();
        }
    }
}
