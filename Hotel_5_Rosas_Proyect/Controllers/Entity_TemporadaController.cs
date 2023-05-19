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
        public ActionResult<Entity_Temporada> GetEspecificSeason(int PK_Temporada)
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Get_SpecificSeason]";
            cmd.Parameters.Add("@param_Nombre", System.Data.SqlDbType.VarChar, 20).Value = PK_Temporada;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Temporada> listSeason = new List<Entity_Temporada>();

            while (reader.Read())
            {
                Entity_Temporada season = new Entity_Temporada();
                season.PK_Temporada = (int)reader["PK_Temporada"];
                season.Nombre = (string)reader["Nombre"];
                season.Fecha_Inicio = (DateTime)reader["Fecha_Inicio"];
                season.Fecha_Fin = (DateTime)reader["Fecha_Fin"];
                listSeason.Add(season);
                reader.Close();
            }
            
            if (listSeason.Count > 0)
            {
                return Ok(listSeason[0]);
            }

            return BadRequest();
        }


        // POST: api/Entity_Temporada/PostInsertSeason
        [HttpPost]
        public async Task<ActionResult<Entity_Temporada>> PostInsertSeason(Entity_Temporada temporada)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"EXEC PA_InsertarTemporada
                                            @pNombre={temporada.Nombre}, @pFecha_Inicio={temporada.Fecha_Inicio}, @pFecha_Fin{temporada.Fecha_Fin}");

            return Ok(temporada);
        }

        // POST: api/Entity_Temporada/PostUpdateSeason
        [HttpPost]
        public async Task<ActionResult<Entity_Temporada>> PostUpdateSeason(Entity_Temporada temporada)
        {
            await _context.Database.ExecuteSqlInterpolatedAsync($@"EXEC PA_InsertarTemporada
                                            @PK_Temporada={temporada.PK_Temporada}, @pNombre={temporada.Nombre}, 
                                            @pFecha_Inicio={temporada.Fecha_Inicio}, @pFecha_Fin{temporada.Fecha_Fin}");

            return Ok(temporada);
        }


        // DELETE: api/Entity_Temporada/DeleteSeason
        [HttpDelete("{PK_Temporada}")]
        public async Task<ActionResult<Entity_Temporada>> DeleteSeason(int PK_Temporada)
        {
            var season = await _context.Entity_Temporada.FindAsync(PK_Temporada);

            if(season == null)
            {
                return NotFound();
            }

            _context.Entity_Temporada.Remove(season);
            await _context.SaveChangesAsync();

            return NoContent();
        }






        private bool Entity_TemporadaExists(int id)
        {
            return _context.Entity_Temporada.Any(e => e.PK_Temporada == id);
        }
    }
}
