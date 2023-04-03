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
    public class Entity_CaracteristicasController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Caracteristicas _context;

        public Entity_CaracteristicasController(DA_Hotel_5_Rosas_Caracteristicas context)
        {
            _context = context;
        }

        // GET: api/Entity_Caracteristicas/GetFeatures
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Caracteristicas>> GetFeatures()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Caracteristicas>().ToListAsync();
        }

    }
}
