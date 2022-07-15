using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;
using System;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class HomeController : Controller
    {
        private ContactContext context { get; set; }
        public HomeController(ContactContext ctx)
        {
            context = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string searchString)
        {
            var contacts = from m in context.Contacts
                           .Include(c => c.Category)
                           .OrderBy(c => c.Lastname)
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = contacts.Where(s => s.Lastname!.Contains(searchString));
            }

            return View(await contacts.ToListAsync());
        }





    }
}
