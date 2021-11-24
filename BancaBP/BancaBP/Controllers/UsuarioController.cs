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
    public class UsuarioController : Controller
    {
        public readonly corebancarioContext _context;

        public UsuarioController(corebancarioContext context)
        {
            _context = context;
        }
        //Listar Usuarios
        public async Task<IActionResult> Index()
        {
            var usuarios = await _context.Usuarios.ToListAsync();
            //usuarios[0].VchUsupassword = "*********";
            return View(usuarios);
        }
        
        public IActionResult Create()
        {
            return View();
        }
        //Crear Nuevo Usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                _context.Usuarios.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        //Actualizar usuario por id
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var usuarioenDb = await _context.Usuarios.FirstOrDefaultAsync(u => u.IntUsucodigo == id);

            if (usuarioenDb == null)
            {
                return NotFound();
            }
            return View(usuarioenDb);
        }

        //Actualizar usuario
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Usuario usuario)
        {
            if (!ModelState.IsValid)
            {
                return View(usuario);
            }            
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return BadRequest();
            }
            var usuarioenDb = await _context.Usuarios.FirstOrDefaultAsync(u => u.IntUsucodigo == id);

            if (usuarioenDb == null)
            {
                return NotFound();
            }
            _context.Usuarios.Remove(usuarioenDb);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

    }
}
