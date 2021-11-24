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
    public class CuentaController : Controller
    {
        private readonly corebancarioContext _context;

        public CuentaController(corebancarioContext context)
        {
            _context = context;
        }
        //Listar Cuentas
        public async Task<IActionResult> Index()
        {
            var cuentas = await _context.Cuentas.ToListAsync();
            return View(cuentas);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Crear Nueva Cuenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cuenta cuenta)
        {
            if (ModelState.IsValid)
            {
                _context.Cuentas.Add(cuenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cuenta);
        }

        //Actualizar cuenta por id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var cuentaenDb = await _context.Cuentas.FirstOrDefaultAsync(u => u.IntCuencodigo == id);

            if (cuentaenDb == null)
            {
                return NotFound();
            }
            return View(cuentaenDb);
        }

        //Actualizar cuenta
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cuenta cuenta)
        {
            if (!ModelState.IsValid)
            {
                return View(cuenta);
            }
            _context.Cuentas.Update(cuenta);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var cuentaenDb = await _context.Cuentas.FirstOrDefaultAsync(u => u.IntCuencodigo == id);

            if (cuentaenDb == null)
            {
                return NotFound();
            }
            _context.Cuentas.Remove(cuentaenDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
