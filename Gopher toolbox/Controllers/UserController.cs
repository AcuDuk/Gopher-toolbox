using ExampleLoginEmptyProject.Data;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using Gopher_toolbox.Models;

namespace Gopher_toolbox.Services
{
    public interface IUserService
    {
        //List<ApplicationUser> GetAllUsers();
        void BlockUser(string userId);
        void ChangePassword(string userId, string newPassword);
        void AddToDepartment(string userId, string department);
    }

    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

       /* public List<ApplicationUser> GetAllUsers()
        {
            return _context.Users.ToList();
        }*/

        public void BlockUser(string userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                user.LockoutEnd = DateTimeOffset.MaxValue;
                _context.SaveChanges();
            }
        }

        public void ChangePassword(string userId, string newPassword)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                //user.PasswordHash = new PasswordHasher<ApplicationUser>().HashPassword(user, newPassword);
                _context.SaveChanges();
            }
        }

        public void AddToDepartment(string userId, string department)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                //user.Department = department;
                _context.SaveChanges();
            }
        }
    }
}
