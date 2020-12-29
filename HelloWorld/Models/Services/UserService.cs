using HelloWorld.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloWorld.Models.Services
{
    public class UserService
    {
        private SzkolaDbContext _context;
        
        public UserService(SzkolaDbContext context)
        {
            _context = context;
         
        }
        public void CreateUser(string firstName, string lastName, string login, string password, string aboutMe)
        {

        }
        public IEnumerable<UserListItemViemModel> GetAll()
        {
            var users = _context.Users
                .Include(x => x.UserProject)
                .ThenInclude(x => x.Project)
                .Select(x => new UserListItemViemModel
                {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Login = x.Login,
                Projects = x.UserProject.Select(p => p.Project.Name)
            }).ToList();
            return users;
        }

        public void Remove(int id)
        {
            var user = _context.Users.Find(id);
            
            _context.Users.Remove(user);
                        
            _context.SaveChanges();
        }

        public EditUserViewModel GetToEdit(int id)
        {
            var user = _context.Users.Find(id);
            var vm = new EditUserViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe
            };
            return vm;
        }
        public void Update(EditUserViewModel updated)
        {
            var user = _context.Users.Find(updated.Id);

            user.FirstName = updated.FirstName;
            user.LastName = updated.LastName;
            user.AboutMe = updated.AboutMe;

            _context.Update(user);
            _context.SaveChanges();
        }
        public UserDetailsViewModel GetToDetails(int Id) //nieważne czy jest id czy Id
        {
            var user = _context.Users.Find(Id);
            
            var vm = new UserDetailsViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                AboutMe = user.AboutMe,
                
            };
            return vm;
        }
    }
}
