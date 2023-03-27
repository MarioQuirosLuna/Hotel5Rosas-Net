using System;
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
    public class Entity_HabitacionController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Habitacion _context;

        public Entity_HabitacionController(DA_Hotel_5_Rosas_Habitacion context)
        {
            _context = context;
        }

        // GET: Entity_Habitacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity_Habitacion.ToListAsync());
        }

        // GET: api/Entity_Habitacion/GetTipo
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Habitacion>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Habitacion>().ToListAsync();
        }

        private bool Entity_HabitacionExists(int id)
        {
            return _context.Entity_Habitacion.Any(e => e.PK_Habitacion == id);
        }
    }
}
