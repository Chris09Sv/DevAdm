using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DevControl.Data;
using DevControl.Models.Establecimientos;
using DevControl.Services;

namespace DevControl.Controllers
{
    public class TbEstablecimientosController : Controller
    {
        private readonly DevContext _context;
        private readonly IData _data;


        public TbEstablecimientosController(DevContext context,IData data)
        {
            _data=data;
            _context = context;
        }

        // GET: TbEstablecimientos
        public IActionResult Index()
        {


            return _data.GetVmEstablecimientos() != null ?
                        View( _data.GetVmEstablecimientos()) :
                        Problem("Entity set 'DevContext.tbEstablecimientos'  is null.");
        }

        // GET: TbEstablecimientos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tbEstablecimientos == null)
            {
                return NotFound();
            }

            var tbEstablecimientos = await _context.tbEstablecimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbEstablecimientos == null)
            {
                return NotFound();
            }

            return View(tbEstablecimientos);
        }

        // GET: TbEstablecimientos/Create
        public IActionResult Create()
        {
            var prov = _context.tbProvincias.ToList();
            var lista = new SelectList(prov, "id", "Provincia");
            ViewData["DbProvincias"] = lista;


            var inst = _context.tbInstitucion.ToList();
            var list_inst = new SelectList(inst, "Id", "Institucion");
            ViewData["DbInstitucion"] = list_inst;

            var subs = _context.tbSubsectors.ToList();
            var list_subs = new SelectList(subs, "Id", "Subsector");
            ViewData["DbSubsectors"] = list_subs;

            var cat = _context.tbCategorias.ToList();
            var list_cat = new SelectList(cat, "Id", "Categoria");
            ViewData["DbCategoria"] = list_cat;

            var nivel = _context.tbNivel.ToList();
            var list_nivel = new SelectList(nivel, "Id", "Nivel");
            ViewData["DbNivel"] = list_nivel;
            return View();
        }

        // POST: TbEstablecimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Centro,Institucion,Categoria,Subsector,Nivel,Capacidad,Provincia,Municipio,Distrito,Sector,Area")] TbEstablecimientos tbEstablecimientos)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbEstablecimientos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbEstablecimientos);
        }

        // GET: TbEstablecimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tbEstablecimientos == null)
            {
                return NotFound();
            }
            var prov = _context.tbProvincias.ToList();
            var lista = new SelectList(prov, "id", "Provincia");
            ViewData["DbProvincias"] = lista;


            var inst = _context.tbInstitucion.ToList();
            var list_inst = new SelectList(inst, "Id", "Institucion");
            ViewData["DbInstitucion"] = list_inst;

            var subs = _context.tbSubsectors.ToList();
            var list_subs = new SelectList(subs, "Id", "Subsector");
            ViewData["DbSubsectors"] = list_subs;

            var cat = _context.tbCategorias.ToList();
            var list_cat = new SelectList(cat, "Id", "Categoria");
            ViewData["DbCategoria"] = list_cat;

            var nivel = _context.tbNivel.ToList();
            var list_nivel = new SelectList(nivel, "Id", "Nivel");
            ViewData["DbNivel"] = list_nivel;

            var tbEstablecimientos = await _context.tbEstablecimientos.FindAsync(id);
            if (tbEstablecimientos == null)
            {
                return NotFound();
            }
            return View(tbEstablecimientos);
        }

        // POST: TbEstablecimientos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Centro,Institucion,Categoria,Subsector,Nivel,Capacidad,Provincia,Municipio,Distrito,Sector,Area")] TbEstablecimientos tbEstablecimientos)
        {
            if (id != tbEstablecimientos.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbEstablecimientos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbEstablecimientosExists(tbEstablecimientos.Id))
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
            return View(tbEstablecimientos);
        }

        // GET: TbEstablecimientos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tbEstablecimientos == null)
            {
                return NotFound();
            }

            var tbEstablecimientos = await _context.tbEstablecimientos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tbEstablecimientos == null)
            {
                return NotFound();
            }

            return View(tbEstablecimientos);
        }

        // POST: TbEstablecimientos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tbEstablecimientos == null)
            {
                return Problem("Entity set 'DevContext.tbEstablecimientos'  is null.");
            }
            var tbEstablecimientos = await _context.tbEstablecimientos.FindAsync(id);
            if (tbEstablecimientos != null)
            {
                _context.tbEstablecimientos.Remove(tbEstablecimientos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbEstablecimientosExists(int id)
        {
            return (_context.tbEstablecimientos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
