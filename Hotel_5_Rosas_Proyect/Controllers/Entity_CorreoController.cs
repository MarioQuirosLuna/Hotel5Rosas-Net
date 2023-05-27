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
    public class Entity_CorreoController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Correo _context;

        public Entity_CorreoController(DA_Hotel_5_Rosas_Correo context)
        {
            _context = context;
        }



        // GET: api/Entity_Correo/GetMails
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Correo>> GetMails()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Correo>().ToListAsync();
        }

        private bool Entity_CorreoExists(int id)
        {
            return _context.Entity_Correo.Any(e => e.PK_Correo == id);
        }
    }
}
