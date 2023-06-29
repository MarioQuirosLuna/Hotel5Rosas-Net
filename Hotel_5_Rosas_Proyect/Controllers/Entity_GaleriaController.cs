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

        // GET: api/Entity_Galeria/getGalleryAboutUs
        [HttpGet]
        public List<Entities_Hotel_5_Rosas.Entity_Imagen> getGalleryAboutUs()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Galeria_Sobre_Nosotros";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Imagen> tipos = new List<Entity_Imagen>();
            while (reader.Read())
            {
                Entity_Imagen tipo = new Entity_Imagen();
                tipo.PK_Imagen = (int)reader["PK_Imagen"];
                tipo.Imagen = (string)reader["Imagen"];
                tipo.show = (bool)reader["show"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }

        //------------------------------------------ Modificar ---------------------------
        // PUT: api/Entity_Galeria/putShowImage
        [HttpPut("{id}")]
        public async Task<IActionResult> putShowImage(int id)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_show_imagen_gallery", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_id", id);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        private bool Entity_GaleriaExists(int id)
        {
            return _context.Entity_Galeria.Any(e => e.PK_Galeria == id);
        }
    }
}
