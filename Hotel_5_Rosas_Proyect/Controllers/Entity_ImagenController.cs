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

    public class Entity_ImagenController : Controller
    {

        private readonly DA_Hotel_5_Rosas_Galeria _context;

        public Entity_ImagenController(DA_Hotel_5_Rosas_Galeria context)
        {
            _context = context;
        }

        // GET: Entity_Imagen
        public async Task<IActionResult> Index()
        {
            return View(await _context.Entity_Imagen.ToListAsync());
        }

        // GET: api/Entity_Imagen/GetTipo
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Imagen>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Imagen>().ToListAsync();
        }

        private bool Entity_ImagenExists(int id)
        {
            return _context.Entity_Imagen.Any(e => e.PK_Imagen == id);
        }
    }
}
