﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Entities_Hotel_5_Rosas;
using Hotel_5_Rosas_Proyect.Data;
using System.Web.Http.Cors;

namespace Hotel_5_Rosas_Proyect.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class Entity_PublicidadController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Publicidad _context;

        public Entity_PublicidadController(DA_Hotel_5_Rosas_Publicidad context)
        {
            _context = context;
        }

        // GET: Entity_Publicidad
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity_Publicidad.ToListAsync());
        }

        // GET: 4
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Publicidad>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Publicidad>().ToListAsync();
        }

        private bool Entity_PublicidadExists(int id)
        {
            return _context.Entity_Publicidad.Any(e => e.PK_Publicidad == id);
        }
    }
}
