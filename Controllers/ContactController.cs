using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ContactManager.Models;
using System.Threading.Tasks;

namespace ContactManager.Controllers
{
    public class ContactController : Controller
    {
        private ContactContext context { get; set; }
        public ContactController(ContactContext ctx)
        {
            context = ctx;
        }

        /*
        public async Task<IActionResult> Index(string searchString)
        {
            var contacts = from m in context.Contacts
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                contacts = context.Contacts.Where(s => s.Lastname!.Contains(searchString));
            }

            return View(await contacts.ToListAsync());
        }
        */
        public IActionResult Details(int id)
        {
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        [HttpGet]
        public IActionResult Add()
        {
            ViewBag.Action = "Add";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
            return View("Edit", new Contact());
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            ViewBag.Action = "Edit";
            ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();

            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Edit(Contact contact)
        {
            string action = (contact.ContactId == 0) ? "Add" : "Edit";

            if (ModelState.IsValid)
            {
                if (action == "Add")
                {
                    contact.DateAdded = DateTime.Now;
                    context.Contacts.Add(contact);
                }         
                else
                {
                    context.Contacts.Update(contact);
                }  
                context.SaveChanges();

                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Action = action;
                ViewBag.Categories = context.Categories.OrderBy(c => c.Name).ToList();
                return View(contact);
            }
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            var contact = context.Contacts
                .Include(c => c.Category)
                .FirstOrDefault(c => c.ContactId == id);
            return View(contact);
        }

        [HttpPost]
        public IActionResult Delete(Contact contact)
        {
            context.Contacts.Remove(contact);
            context.SaveChanges();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
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
