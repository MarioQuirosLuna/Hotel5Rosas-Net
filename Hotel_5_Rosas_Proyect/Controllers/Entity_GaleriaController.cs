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

    public class Entity_GaleriaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Galeria _context;

        public Entity_GaleriaController(DA_Hotel_5_Rosas_Galeria context)
        {
            _context = context;
        }

        // GET: api/Entity_Galeria/GetGaleries
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Galeria>> GetGaleries()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Galeria>().ToListAsync();
        }

        private bool Entity_GaleriaExists(int id)
        {
            return _context.Entity_Galeria.Any(e => e.PK_Galeria == id);
        }
    }
}
