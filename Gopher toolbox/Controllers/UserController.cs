using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using GopherToolboxNew.Data; 
using GopherToolboxNew.Models; 
using GopherToolboxNew.ViewModels; 

namespace GopherToolboxNew.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var duties = await _context.Duties
                                       .Where(d => d.UserId == user.Id)
                                       .Include(d => d.Department)
                                       .ToListAsync();
            var viewModel = new UserCalendarViewModel
            {
                Duties = duties
            };
            return View(viewModel);
        }
    }
}
