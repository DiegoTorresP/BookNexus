using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookNexus.Data;
using BookNexus.Models;
using SmartBreadcrumbs.Attributes;

namespace BookNexus.Controllers
{
    public class BooksController : Controller
    {
        private readonly BookNexusContext _context;

        public BooksController(BookNexusContext context)
        {
            _context = context;
        }

        // GET: Books
        [Breadcrumb("Lista de Libros")]
        public async Task<IActionResult> Index()
        {
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(await _context.Book.ToListAsync());
        }

        // GET: Books/Details/5
        [Breadcrumb("Detalles")]
        public async Task<IActionResult> Details(int? id)
        {
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Books/Create
        [Breadcrumb("Crear")]
        public IActionResult Create()
        {
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Portada,ReleaseDate,Genre,Price")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(book);
        }

        // GET: Books/Edit/5
        [Breadcrumb("Editar")]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,ReleaseDate,Genre,Price")] Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.Id))
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
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(book);
        }

        // GET: Books/Delete/5

        [Breadcrumb("Eliminar")]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Book == null)
            {
                return NotFound();
            }

            var book = await _context.Book
                .FirstOrDefaultAsync(m => m.Id == id);
            if (book == null)
            {
                return NotFound();
            }
            string name = HttpContext.Session.GetString("NameUser");
            ViewBag.Usuario = name;
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Book == null)
            {
                return Problem("Entity set 'BookNexusContext.Book'  is null.");
            }
            var book = await _context.Book.FindAsync(id);
            if (book != null)
            {
                _context.Book.Remove(book);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
          return _context.Book.Any(e => e.Id == id);
        }
    }
}
