using BancaBP.Data;
using BancaBP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancaBP.Controllers
{
    public class MovimientoController : Controller
    {
        private readonly corebancarioContext _context;

        public MovimientoController(corebancarioContext context)
        {
            _context = context;
        }
        //Listar Movimientos
        public async Task<IActionResult> Index()
        {
            var movimientos = await _context.Movimientos.ToListAsync();
            return View(movimientos);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Crear Nuevo Movimiento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Movimiento movimiento)
        {
            if (ModelState.IsValid)
            {
                _context.Movimientos.Add(movimiento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(movimiento);
        }

        //Actualizar movimiento por id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var movimientoenDb = await _context.Movimientos.FirstOrDefaultAsync(u => u.IntMovicodigo == id);

            if (movimientoenDb == null)
            {
                return NotFound();
            }
            return View(movimientoenDb);
        }

        //Actualizar movimiento
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Movimiento movimiento)
        {
            if (!ModelState.IsValid)
            {
                return View(movimiento);
            }
            _context.Movimientos.Update(movimiento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var movimientoenDb = await _context.Movimientos.FirstOrDefaultAsync(u => u.IntMovicodigo == id);

            if (movimientoenDb == null)
            {
                return NotFound();
            }
            _context.Movimientos.Remove(movimientoenDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
