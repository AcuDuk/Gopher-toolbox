using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Gopher_toolbox.Models;
using Gopher_toolbox.Services;

namespace Gopher_toolbox.Controllers
{
    [Authorize/*(Roles = "Administrator")*/]
    public class AdminController : Controller
    {
        private readonly IUserService _userService;

        public AdminController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            //var users = _userService.GetAllUsers();
            return View(/*users*/);
        }

        [HttpPost]
        public IActionResult BlockUser(string userId)
        {
            _userService.BlockUser(userId);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ChangePassword(string userId, string newPassword)
        {
            _userService.ChangePassword(userId, newPassword);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AddToDepartment(string userId, string department)
        {
            _userService.AddToDepartment(userId, department);
            return RedirectToAction("Index");
        }
    }
}
