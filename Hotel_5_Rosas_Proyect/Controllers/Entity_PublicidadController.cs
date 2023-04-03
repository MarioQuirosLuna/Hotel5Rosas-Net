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
using Microsoft.Data.SqlClient;

namespace Hotel_5_Rosas_Proyect.Controllers
{

    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class Entity_PublicidadController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Publicidad _context;

        public Entity_PublicidadController(DA_Hotel_5_Rosas_Publicidad context)
        {
            _context = context;
        }

        // GET: api/Entity_Publicidad/GetPublicities
        [HttpGet]
        public async Task<Entity_Publicidad> GetPublicities()
        {
            Entity_Publicidad page = new Entity_Publicidad();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Publicidad", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            page.Nombre = item["Nombre"].ToString();
                            page.Descripcion = item["Descripcion"].ToString();
                            page.Imagen = (byte[])item["Imagen"];
                        }
                    }
                    return page;
                }
            }
        }

        private bool Entity_PublicidadExists(int id)
        {
            return _context.Entity_Publicidad.Any(e => e.PK_Publicidad == id);
        }
    }
}
