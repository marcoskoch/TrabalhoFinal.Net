using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinal.Data;
using TrabalhoFinal.Models;
using Microsoft.AspNetCore.Authorization;

namespace TrabalhoFinal.Controllers
{
    public class MedicoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MedicoController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Medico
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Medicos.Include(m => m.Especialidade);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Medico/Details/5
        [Authorize]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.Especialidade)
                .SingleOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // GET: Medico/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "IdEspecialidade", "Nome");
            return View();
        }

        // POST: Medico/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdMedico,Nome,IdEspecialidade")] Medico medico)
        {
            if (ModelState.IsValid)
            {
                _context.Add(medico);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        // GET: Medico/Edit/5
        [Authorize]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos.SingleOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        // POST: Medico/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdMedico,Nome,IdEspecialidade")] Medico medico)
        {
            if (id != medico.IdMedico)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(medico);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MedicoExists(medico.IdMedico))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["IdEspecialidade"] = new SelectList(_context.Especialidades, "IdEspecialidade", "Nome", medico.IdEspecialidade);
            return View(medico);
        }

        // GET: Medico/Delete/5
        [Authorize]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var medico = await _context.Medicos
                .Include(m => m.Especialidade)
                .SingleOrDefaultAsync(m => m.IdMedico == id);
            if (medico == null)
            {
                return NotFound();
            }

            return View(medico);
        }

        // POST: Medico/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var medico = await _context.Medicos.SingleOrDefaultAsync(m => m.IdMedico == id);
            _context.Medicos.Remove(medico);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool MedicoExists(int id)
        {
            return _context.Medicos.Any(e => e.IdMedico == id);
        }
    }
}
