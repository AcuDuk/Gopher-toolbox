using GopherToolboxNew.Data;
using GopherToolboxNew.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GopherToolboxNew.Models;

namespace GopherToolboxNew.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var departments = await _context.Departments.ToListAsync();
            var duties = await _context.Duties.Include(d => d.User).Include(d => d.Department).ToListAsync();
            var viewModel = new AdminCalendarViewModel
            {
                Departments = departments,
                Duties = duties
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDuty(AdminCalendarViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Duties.Add(viewModel.NewDuty);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            viewModel.Departments = await _context.Departments.ToListAsync();
            viewModel.Duties = await _context.Duties.Include(d => d.User).Include(d => d.Department).ToListAsync();
            return View("Index", viewModel);
        }
    }
}
