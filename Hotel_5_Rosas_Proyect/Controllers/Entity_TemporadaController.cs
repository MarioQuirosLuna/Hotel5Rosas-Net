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

    public class Entity_TemporadaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Temporada _context;

        public Entity_TemporadaController(DA_Hotel_5_Rosas_Temporada context)
        {
            _context = context;
        }

        // GET: api/Entity_Temporada/GetSeasons
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Temporada>> GetSeasons()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Temporada>().ToListAsync();
        }

        private bool Entity_TemporadaExists(int id)
        {
            return _context.Entity_Temporada.Any(e => e.PK_Temporada == id);
        }
    }
}
