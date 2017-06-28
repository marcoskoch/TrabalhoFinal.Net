using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TrabalhoFinal.Data;
using TrabalhoFinal.Models;

namespace TrabalhoFinal.Controllers
{
    public class AgendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AgendaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Agenda
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Agendas.Include(a => a.Medico);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Agenda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .Include(a => a.Medico)
                .SingleOrDefaultAsync(m => m.IdAgenda == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // GET: Agenda/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome");
            return View();
        }

        // POST: Agenda/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdAgenda,DataAgenda,HorarioEntrada,HorarioSaida,IdMedico")] Agenda agenda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(agenda);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", agenda.IdMedico);
            return View(agenda);
        }

        // GET: Agenda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas.SingleOrDefaultAsync(m => m.IdAgenda == id);
            if (agenda == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", agenda.IdMedico);
            return View(agenda);
        }

        // POST: Agenda/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdAgenda,DataAgenda,HorarioEntrada,HorarioSaida,IdMedico")] Agenda agenda)
        {
            if (id != agenda.IdAgenda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(agenda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AgendaExists(agenda.IdAgenda))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", agenda.IdMedico);
            return View(agenda);
        }

        // GET: Agenda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var agenda = await _context.Agendas
                .Include(a => a.Medico)
                .SingleOrDefaultAsync(m => m.IdAgenda == id);
            if (agenda == null)
            {
                return NotFound();
            }

            return View(agenda);
        }

        // POST: Agenda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var agenda = await _context.Agendas.SingleOrDefaultAsync(m => m.IdAgenda == id);
            _context.Agendas.Remove(agenda);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool AgendaExists(int id)
        {
            return _context.Agendas.Any(e => e.IdAgenda == id);
        }
    }
}
