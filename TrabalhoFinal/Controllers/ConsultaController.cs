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
    public class ConsultaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ConsultaController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Consulta
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Consultas.Include(c => c.Medico).Include(c => c.Paciente);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Consulta/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .SingleOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // GET: Consulta/Create
        public IActionResult Create()
        {
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome");
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Nome");
            return View();
        }

        // POST: Consulta/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdConsulta,IdMedico,IdPaciente,DataHora,HorarioConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(consulta);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Nome", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consulta/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas.SingleOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Email", consulta.IdPaciente);
            return View(consulta);
        }

        // POST: Consulta/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdConsulta,IdMedico,IdPaciente,DataHora,HorarioConsulta")] Consulta consulta)
        {
            if (id != consulta.IdConsulta)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(consulta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ConsultaExists(consulta.IdConsulta))
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
            ViewData["IdMedico"] = new SelectList(_context.Medicos, "IdMedico", "Nome", consulta.IdMedico);
            ViewData["IdPaciente"] = new SelectList(_context.Pacientes, "IdPaciente", "Email", consulta.IdPaciente);
            return View(consulta);
        }

        // GET: Consulta/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var consulta = await _context.Consultas
                .Include(c => c.Medico)
                .Include(c => c.Paciente)
                .SingleOrDefaultAsync(m => m.IdConsulta == id);
            if (consulta == null)
            {
                return NotFound();
            }

            return View(consulta);
        }

        // POST: Consulta/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var consulta = await _context.Consultas.SingleOrDefaultAsync(m => m.IdConsulta == id);
            _context.Consultas.Remove(consulta);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ConsultaExists(int id)
        {
            return _context.Consultas.Any(e => e.IdConsulta == id);
        }
    }
}
