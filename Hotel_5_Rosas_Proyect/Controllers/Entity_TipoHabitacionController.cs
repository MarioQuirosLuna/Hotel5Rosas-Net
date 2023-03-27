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
    public class Entity_TipoHabitacionController : Controller
    {
        private readonly DA_Hotel_5_Rosas_TipoHabitacion _context;

        public Entity_TipoHabitacionController(DA_Hotel_5_Rosas_TipoHabitacion context)
        {
            _context = context;
        }

        // GET: Entity_TipoHabitacion
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity_TipoHabitacion.ToListAsync());
        }

        // GET: api/Entity_TipoHabitacion/GetTipo
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_TipoHabitacion>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_TipoHabitacion>().ToListAsync();
        }

        private bool Entity_TipoHabitacionExists(int id)
        {
            return _context.Entity_TipoHabitacion.Any(e => e.PK_Tipo_Habitacion == id);
        }
    }
}
