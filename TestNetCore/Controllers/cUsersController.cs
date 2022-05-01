#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TestNetCore.Models;

namespace TestNetCore.Controllers
{
    public class cUsersController : Controller
    {
        private readonly cUserContext _context;

        public cUsersController(cUserContext context)
        {
            _context = context;
        }

        // GET: cUsers
        public async Task<IActionResult> Index()
        {
            return View(await _context.tUser.ToListAsync());
        }

        // GET: cUsers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await _context.tUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }

        // GET: cUsers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: cUsers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,User,Pass,Created_at,Direccion")] cUser cUser)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cUser);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cUser);
        }

        // GET: cUsers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await _context.tUser.FindAsync(id);
            if (cUser == null)
            {
                return NotFound();
            }
            return View(cUser);
        }

        // POST: cUsers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,User,Pass,Created_at,Direccion")] cUser cUser)
        {
            if (id != cUser.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cUser);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!cUserExists(cUser.Id))
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
            return View(cUser);
        }

        // GET: cUsers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cUser = await _context.tUser
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cUser == null)
            {
                return NotFound();
            }

            return View(cUser);
        }

        // POST: cUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cUser = await _context.tUser.FindAsync(id);
            _context.tUser.Remove(cUser);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool cUserExists(int id)
        {
            return _context.tUser.Any(e => e.Id == id);
        }
    }
}
