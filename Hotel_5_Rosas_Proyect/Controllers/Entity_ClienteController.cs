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

    public class Entity_ClienteController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Cliente _context;

        public Entity_ClienteController(DA_Hotel_5_Rosas_Cliente context)
        {
            _context = context;
        }

        // GET: api/Entity_Cliente/GetTipo
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Cliente>> GetTipo()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Cliente>().ToListAsync();
        }

        private bool Entity_ClienteExists(int id)
        {
            return _context.Entity_Cliente.Any(e => e.PK_Cliente == id);
        }
    }
}
