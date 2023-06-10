using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CrudProjectJpv.Models;

namespace CrudProjectJpv.Controllers
{
    public class CadastroPessoasController : Controller
    {
        private readonly Context _context;

        public CadastroPessoasController(Context context)
        {
            _context = context;
        }

        // GET: CadastroPessoas
        public async Task<IActionResult> Index()
        {
              return _context.CadastroPessoas != null ? 
                          View(await _context.CadastroPessoas.ToListAsync()) :
                          Problem("Entity set 'Context.CadastroPessoas'  is null.");
        }

        // GET: CadastroPessoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.CadastroPessoas == null)
            {
                return NotFound();
            }

            var cadastroPessoa = await _context.CadastroPessoas
                .FirstOrDefaultAsync(m => m.id == id);
            if (cadastroPessoa == null)
            {
                return NotFound();
            }

            return View(cadastroPessoa);
        }

        // GET: CadastroPessoas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CadastroPessoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,nomeCompleto,dataNascimento,valorRenda,cpf")] CadastroPessoa cadastroPessoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cadastroPessoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cadastroPessoa);
        }

        // GET: CadastroPessoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.CadastroPessoas == null)
            {
                return NotFound();
            }

            var cadastroPessoa = await _context.CadastroPessoas.FindAsync(id);
            if (cadastroPessoa == null)
            {
                return NotFound();
            }
            return View(cadastroPessoa);
        }

        // POST: CadastroPessoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,nomeCompleto,dataNascimento,valorRenda,cpf")] CadastroPessoa cadastroPessoa)
        {
            if (id != cadastroPessoa.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cadastroPessoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CadastroPessoaExists(cadastroPessoa.id))
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
            return View(cadastroPessoa);
        }

        // GET: CadastroPessoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.CadastroPessoas == null)
            {
                return NotFound();
            }

            var cadastroPessoa = await _context.CadastroPessoas
                .FirstOrDefaultAsync(m => m.id == id);
            if (cadastroPessoa == null)
            {
                return NotFound();
            }

            return View(cadastroPessoa);
        }

        // POST: CadastroPessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.CadastroPessoas == null)
            {
                return Problem("Entity set 'Context.CadastroPessoas'  is null.");
            }
            var cadastroPessoa = await _context.CadastroPessoas.FindAsync(id);
            if (cadastroPessoa != null)
            {
                _context.CadastroPessoas.Remove(cadastroPessoa);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CadastroPessoaExists(int id)
        {
          return (_context.CadastroPessoas?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
