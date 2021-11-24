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
    public class ClienteController : Controller
    {
        private readonly corebancarioContext _context;

        public ClienteController(corebancarioContext context)
        {
            _context = context;
        }
        //Listar Clientes
        public async Task<IActionResult> Index()
        {
            var clientes = await _context.Clientes.ToListAsync();
            return View(clientes);
        }

        public IActionResult Create()
        {
            return View();
        }
        //Crear Nuevo Cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Cliente cliente)
        {
            if (ModelState.IsValid)
            {
                _context.Clientes.Add(cliente);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cliente);      
        }

        //Actualizar cliente por id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var clienteenDb = await _context.Clientes.FirstOrDefaultAsync(u => u.IntCliecodigo == id);

            if (clienteenDb == null)
            {
                return NotFound();
            }
            return View(clienteenDb);
        }

        //Actualizar cliente
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Cliente cliente)
        {
            if (!ModelState.IsValid)
            {
                return View(cliente);
            }
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var clienteenDb = await _context.Clientes.FirstOrDefaultAsync(u => u.IntCliecodigo == id);

            if (clienteenDb == null)
            {
                return NotFound();
            }
            _context.Clientes.Remove(clienteenDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
