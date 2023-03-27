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
    public class Entity_ReservaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Reserva _context;

        public Entity_ReservaController(DA_Hotel_5_Rosas_Reserva context)
        {
            _context = context;
        }

        // GET: Entity_Reserva
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity_Reserva.ToListAsync());
        }

        // GET: api/Entity_Reserva/GetTipo
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Reserva>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Reserva>().ToListAsync();
        }

        private bool Entity_ReservaExists(int id)
        {
            return _context.Entity_Reserva.Any(e => e.PK_Reserva == id);
        }
    }
}
