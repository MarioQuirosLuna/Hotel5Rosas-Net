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

    public class Entity_TemporadaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Temporada _context;

        public Entity_TemporadaController(DA_Hotel_5_Rosas_Temporada context)
        {
            _context = context;
        }

        // GET: api/Entity_Temporada/GetSeasons
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Temporada>> GetSeasons()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Temporada>().ToListAsync();
        }


        //------------------------------Temporada----------------------------------------------

        //api/Entity_Temporada/GetEspecificSeason/1 
        [HttpGet("{PK_Temporada}")]
        public async Task<Entity_Temporada> GetEspecificSeason(int PK_Temporada)
        {
            Entity_Temporada season = new Entity_Temporada();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Temporada", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Temporada", PK_Temporada);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            season.PK_Temporada = PK_Temporada;
                            season.Nombre = (string)item["Nombre"];
                            season.Fecha_Inicio = (DateTime)item["Fecha_Inicio"];
                            season.Fecha_Fin = (DateTime)item["Fecha_Fin"];
                        }
                    }
                    return season;
                }
            }
        }

        // POST: api/Entity_Temporada/PostInsertSeason
        [HttpPost]
        public async Task<IActionResult> PostInsertSeason(Entity_Temporada temporada)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Insertar_Temporada", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Nombre", temporada.Nombre);
                    cmd.Parameters.AddWithValue("@param_Fecha_Inicio", temporada.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@param_Fecha_Fin", temporada.Fecha_Fin);

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

        // PUT: api/Entity_Temporada/PutSeason
        [HttpPut]
        public async Task<IActionResult> PutSeason(Entity_Temporada temporada)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Actualizar_Temporada", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Temporada", temporada.PK_Temporada);
                    cmd.Parameters.AddWithValue("@param_Nombre", temporada.Nombre);
                    cmd.Parameters.AddWithValue("@param_Fecha_Inicio", temporada.Fecha_Inicio);
                    cmd.Parameters.AddWithValue("@param_Fecha_Fin", temporada.Fecha_Fin);

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

        // Delete: api/Entity_Temporada/DeleteSeason
        [HttpDelete("{PK_Temporada}")]
        public async Task<IActionResult> DeleteSeason(int PK_Temporada)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Eliminar_Temporada", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Temporada", PK_Temporada);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return NoContent();
                    }
                    else
                    {
                        return NotFound();
                    }
                }
            }
        }

        private bool Entity_TemporadaExists(int id)
        {
            return _context.Entity_Temporada.Any(e => e.PK_Temporada == id);
        }
    }
}
