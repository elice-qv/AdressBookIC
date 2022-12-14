using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdressBook.Data;
using AdressBook.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.View;
using Microsoft.AspNetCore.Authorization;
using NuGet.Protocol;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims;

namespace AdressBook.Controllers
{
    [Authorize]
    public class WorkplacesController : Controller
    {
        private readonly AdressBookContext _context;

        public WorkplacesController(AdressBookContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string searchString)
        {
            var workplaces = from m in _context.Workplace
                             select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                workplaces = workplaces.Where(s => s.Name!.Contains(searchString));
            }

            return View(await workplaces.ToListAsync());
        }

        //Login

        [AllowAnonymous]
        public IActionResult Login(string returnUrl)
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var claims = new List<Claim>
            {
                new Claim("Demo","Value")
            };
            var claimIdentity = new ClaimsIdentity(claims, "Cookie");
            var claimPrincipal = new ClaimsPrincipal(claimIdentity);
            await HttpContext.SignInAsync("Cookie", claimPrincipal);

            return Redirect(model.ReturnUrl);
        }
        public IActionResult LogOff()
        {
            HttpContext.SignOutAsync("Cookie");
            return Redirect("/AdressBook/Index");
        }


        // GET: Workplaces/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Workplace == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // GET: Workplaces/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Workplaces/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Adress,Password")] Workplace workplace)
        {
            if (ModelState.IsValid)
            {
                _context.Add(workplace);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(workplace);
        }

        // GET: Workplaces/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Workplace == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplace.FindAsync(id);
            if (workplace == null)
            {
                return NotFound();
            }
            return View(workplace);
        }

        // POST: Workplaces/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Adress,Password")] Workplace workplace)
        {
            if (id != workplace.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(workplace);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WorkplaceExists(workplace.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(workplace);
        }

        // GET: Workplaces/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Workplace == null)
            {
                return NotFound();
            }

            var workplace = await _context.Workplace
                .FirstOrDefaultAsync(m => m.Id == id);
            if (workplace == null)
            {
                return NotFound();
            }

            return View(workplace);
        }

        // POST: Workplaces/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Workplace == null)
            {
                return Problem("Entity set 'AdressBookContext.Workplace'  is null.");
            }
            var workplace = await _context.Workplace.FindAsync(id);
            if (workplace != null)
            {
                _context.Workplace.Remove(workplace);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WorkplaceExists(int id)
        {
          return _context.Workplace.Any(e => e.Id == id);
        }
    }
}
