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
using Entities_Hotel_5_Rosas.Modelos;

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

        //---------------------------------------------Gets-------------------

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
                page.PK_Publicidad = (int)reader["PK_Publicidad"];
                page.Nombre = (string)reader["Nombre"];
                page.Descripcion = (string)reader["Descripcion"];
                page.Imagen = (string)reader["Imagen"];
                pages.Add(page);
            }
            conexion.Close();

            return pages;

        }


        // GET: api/Entity_Publicidad/GetEspecificPublicity/1
        [HttpGet("{PK_Publicidad}")]
        public async Task<Entity_Publicidad> GetEspecificPublicity(int PK_Publicidad)
        {

            Entity_Publicidad publicity = new Entity_Publicidad();

            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Una_Publicidad", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Publicidad", PK_Publicidad);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            publicity.PK_Publicidad = PK_Publicidad;
                            publicity.Nombre = (string)item["Nombre"];
                            publicity.Descripcion = (string)item["Descripcion"];
                            publicity.FK_Imagen = (int)item["FK_Imagen"];
                            publicity.FK_Hotel = (int)item["FK_Hotel"];
                            publicity.Imagen = (string)item["Imagen"];
                        }
                    }
                    return publicity;
                }
            }
        }



        //---------------------------------------------DELETE-------------------
        // PUT: api/Entity_Publicidad/DeletePublicity
        [HttpDelete("{PK_Publicidad}")]
        public async Task<ActionResult<Entity_Publicidad>> DeletePublicity(int PK_Publicidad)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Eliminar_Publisidad
                                                  @param_PK_Publicidad={PK_Publicidad}");

            return Ok("Ok");
        }



        //------------------------------------Insert--------------------------------
        // PUT: api/Entity_Publicidad/Insertpublicity
        [HttpPost]
        public async Task<IActionResult> Insertpublicity(Entity_Publicidad publicity)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Insertar_Publicidad", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Nombre", publicity.Nombre);
                    cmd.Parameters.AddWithValue("@param_Descripcion", publicity.Descripcion);
                    cmd.Parameters.AddWithValue("@param_Imagen", publicity.Imagen);

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


        //------------------------------------------ Modificar ---------------------------
        // PUT: api/Entity_Publicidad/Updateplublicity
        [HttpPut]
        public async Task<IActionResult> Updateplublicity(Entity_Publicidad publicity)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Publicidad", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Publicidad", publicity.PK_Publicidad);
                    cmd.Parameters.AddWithValue("@param_Nombre", publicity.Nombre);
                    cmd.Parameters.AddWithValue("@param_Descripcion", publicity.Descripcion);
                    cmd.Parameters.AddWithValue("@param_Imagen", publicity.Imagen);

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


        private bool Entity_PublicidadExists(int id)
        {
            return _context.Entity_Publicidad.Any(e => e.PK_Publicidad == id);
        }
    }
}
