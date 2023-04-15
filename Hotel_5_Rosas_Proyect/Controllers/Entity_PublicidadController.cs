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
        public List<Entities_Hotel_5_Rosas.Entity_Publicidad> GetPublicities()
        {

            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Publicidad";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Publicidad> pages = new List<Entity_Publicidad>();
            while (reader.Read())
            {
                Entity_Publicidad page = new Entity_Publicidad();
                page.Nombre = (string)reader["Nombre"];
                page.Descripcion = (string)reader["Descripcion"];
                page.Imagen = (string)reader["Imagen"];
                pages.Add(page);
            }
            conexion.Close();

            return pages;

        }

        private bool Entity_PublicidadExists(int id)
        {
            return _context.Entity_Publicidad.Any(e => e.PK_Publicidad == id);
        }
    }
}
