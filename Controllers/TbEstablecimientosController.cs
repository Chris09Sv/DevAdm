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


        public TbEstablecimientosController(DevContext context, IData data)
        {
            _data = data;
            _context = context;
        }

        // GET: TbEstablecimientos
        public IActionResult Index()
        {


            return _data.GetVmEstablecimientos() != null ?
                        View(_data.GetVmEstablecimientos()) :
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

            var cap = _context.tbCapacidad.Where(x => x.Capacidad != "No procesa").ToList();
            var list_cap = new SelectList(cap, "Id", "Capacidad");
            ViewData["DbCap"] = list_cap;

            List<SelectListItem> YesNo = new List<SelectListItem>();
            YesNo.Add(new SelectListItem { Text = "No", Value = "0" });
            YesNo.Add(new SelectListItem { Text = "Si", Value = "1" });
            ViewData["DbYesNo"] = YesNo;


            return View();
        }

        // POST: TbEstablecimientos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TbEstablecimientos input)
        {
            var idviepi = 0;
            var idsat = "";
            TbEstablecimientos establecimiento = new()
            {
                Centro = input.Centro,
                Institucion = input.Institucion,
                Categoria = input.Categoria,
                Subsector = input.Subsector,
                Nivel = input.Nivel,
                // Capacidad = 0, // input.Capacidad,
                Provincia = input.Provincia,
                Municipio = input.Municipio,
                Distrito = input.Distrito,
                Sector = input.Sector,
                Seccion = input.Seccion,
                Area = input.Area,
                prueba = input.prueba,
                Laboratorio = input.Laboratorio,
                IdViepi = 0, ///input.IdViepi,
                Sat = input.Sat,
                Estado = 1,
                Creacion = DateTime.Now,
                Activacion = DateTime.Now,
                Usuario = input.Usuario
            };


            var cat = _context.tbCategorias.Where(x => x.Id == establecimiento.Categoria).SingleOrDefault();

            // validacion en plataformas
            if (establecimiento.Nivel > 3 || cat.plataforma == 2)
            {
                _data.AddEstablecimiento(establecimiento);
                idviepi = _data.AddEstablecimiento(establecimiento);

            }
            else if (cat.plataforma == 1)
            {
                idsat = _data.AddEstablecimientoSat(establecimiento);

            }
            else
            {
                idviepi = _data.AddEstablecimiento(establecimiento);
                idsat = _data.AddEstablecimientoSat(establecimiento);
                establecimiento.Sat = idsat;
                establecimiento.IdViepi = idviepi;

            }


            if (ModelState.IsValid)
            {
                _context.Add(establecimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(establecimiento);
        }

        // GET: TbEstablecimientos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            var tbEstablecimientos = await _context.tbEstablecimientos.FindAsync(id);

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


            var mun = _context.tbMunicipios.Where(x => Convert.ToInt32(x.provincia) == tbEstablecimientos.Provincia).ToList();
            var list_mun = new SelectList(mun, "Id", "municipio");
            ViewData["DbMun"] = list_mun;

            var municipio = mun.Where(x=>x.Id==tbEstablecimientos.Municipio).SingleOrDefault();
            var dm = _context.tbDistritos.Where(x => (Convert.ToInt32(x.provincia) == tbEstablecimientos.Provincia) && x.municipio == municipio.mun).ToList();
            var list_dm = new SelectList(dm, "Id", "distrito");
            ViewData["DbDm"] = list_dm;

            var se = _context.tbSectores.Where(x => x.Id == tbEstablecimientos.Sector).ToList();
            var list_se = new SelectList(se, "Id", "barrio");
            ViewData["DbSe"] = list_se;

            var sec = _context.tbSecciones.Where(x => x.Id == tbEstablecimientos.Seccion).ToList();
            var list_sec = new SelectList(sec, "Id", "nombreone");
            ViewData["DbSecc"] = list_sec;

            var cap = _context.tbCapacidad.Where(x => x.Capacidad != "No procesa").ToList();
            var list_cap = new SelectList(cap, "Id", "Capacidad");
            ViewData["DbCap"] = list_cap;

            var area = _context.tbArea.Where(x => x.id == tbEstablecimientos.Area || Convert.ToInt32(x.Provincia) == tbEstablecimientos.Provincia).ToList();
            var list_area = new SelectList(area, "id", "Area");
            ViewData["DbArea"] = list_area;

            List<SelectListItem> YesNo = new List<SelectListItem>();
            YesNo.Add(new SelectListItem { Text = "No", Value = "0" });
            YesNo.Add(new SelectListItem { Text = "Si", Value = "1" });
            ViewData["DbYesNo"] = YesNo;

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
        public async Task<IActionResult> Edit(int id, TbEstablecimientos tbEstablecimientos)
        {
            if (id != tbEstablecimientos.Id)
            {
                return NotFound();
            }
            if (!ModelState.IsValid)
            {
                try
                {
                    if (tbEstablecimientos.IdViepi == null)
                    {
                        tbEstablecimientos.IdViepi = _data.AddEstablecimiento(tbEstablecimientos);
                        _context.Update(tbEstablecimientos);
                        _data.UpEstablecimientoSat(tbEstablecimientos);
                    }
                    else
                    {
                        _context.Update(tbEstablecimientos);
                        _data.UpEstablecimientoSat(tbEstablecimientos);
                        _data.UpdateEstablecimiento(tbEstablecimientos);
                    }
                    // _context.Update(tbEstablecimientos);

                    // _data.UpEstablecimientoSat(tbEstablecimientos);
                    // _data.UpdateEstablecimiento(tbEstablecimientos);

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
            else
            {

                var errors = ModelState.Select(x => x.Value.Errors)
                                       .Where(y => y.Count > 0)
                                       .ToList();
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
