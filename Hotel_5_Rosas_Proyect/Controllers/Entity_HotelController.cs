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
    public class Entity_HotelController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Hotel _context;

        public Entity_HotelController(DA_Hotel_5_Rosas_Hotel context)
        {
            _context = context;
        }

        // GET: api/Entity_Hotel/GetHotels
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Hotel>> GetHotels()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Hotel>().ToListAsync();
        }

        private bool Entity_HotelExists(int id)
        {
            return _context.Entity_Hotel.Any(e => e.PK_Hotel == id);
        }
    }
}
