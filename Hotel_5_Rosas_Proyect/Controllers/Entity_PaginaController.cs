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

    public class Entity_PaginaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Pagina _context;

        public Entity_PaginaController(DA_Hotel_5_Rosas_Pagina context)
        {
            _context = context;
        }

        // GET: api/Entity_Pagina/GetPages
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Pagina>> GetPages()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Pagina>().ToListAsync();
        }

        private bool Entity_PaginaExists(int id)
        {
            return _context.Entity_Pagina.Any(e => e.PK_Pagina == id);
        }
    }
}
