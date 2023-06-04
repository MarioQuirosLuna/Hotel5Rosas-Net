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
    public class Entity_OfertaTemporadaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_OfertaTemporada _context;

        public Entity_OfertaTemporadaController(DA_Hotel_5_Rosas_OfertaTemporada context)
        {
            _context = context;
        }


        // Delete: api/Entity_OfertaTemporada/DeleteSeasonOffer
        [HttpDelete("{PK_Oferta_Temporada}")]
        public async Task<IActionResult> DeleteSeasonOffer(int PK_Oferta_Temporada)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Eliminar_Oferta", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Pk_oferta", PK_Oferta_Temporada);

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


        // PUT: api/Entity_OfertaTemporada/UpdateSeasonOffer
        [HttpPut]
        public async Task<IActionResult> UpdateSeasonOffer(Entity_OfertaTemporada seasonOffer)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Oferta", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Pk_oferta", seasonOffer.PK_Oferta_Temporada);
                    cmd.Parameters.AddWithValue("@param_FK_Temporada", seasonOffer.FK_Temporada);
                    cmd.Parameters.AddWithValue("@param_FK_Tipo_Habitacion", seasonOffer.FK_Tipo_Habitacion);
                    cmd.Parameters.AddWithValue("@param_Oferta", seasonOffer.Oferta);

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



        // Post: api/Entity_OfertaTemporada/PostSeasonOffer
        [HttpPost]
        public async Task<IActionResult> InsertSeasonOffer(Entity_OfertaTemporada seasonOffer)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Insertar_Oferta", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_FK_Temporada", seasonOffer.FK_Temporada);
                    cmd.Parameters.AddWithValue("@param_FK_Tipo_Habitacion", seasonOffer.FK_Tipo_Habitacion);
                    cmd.Parameters.AddWithValue("@param_Oferta", seasonOffer.Oferta);

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


        // GET: api/Entity_OfertaTemporada/GetEspecificSeasonOffer/1
        [HttpGet("{PK_Oferta_Temporada}")]
        public async Task<OfertaTemporada> GetEspecificSeasonOffer(int PK_Oferta_Temporada)
        {

            OfertaTemporada seasonOffer = new OfertaTemporada();

            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Oferta_Por_Id", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Pk_oferta", PK_Oferta_Temporada);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            seasonOffer.PK_Oferta_Temporada = PK_Oferta_Temporada;
                            seasonOffer.Temporada = (string)item["Temporada"];
                            seasonOffer.Tipo_Habitacion = (string)item["Tipo_Habitacion"];
                            seasonOffer.Oferta = (decimal)item["Oferta"];
                        }
                    }
                    return seasonOffer;
                }
            }
        }


        // GET: api/Entity_OfertaTemporada/GetAllSeasonOfer
        [HttpGet]
        public ActionResult<OfertaTemporada> GetAllSeasonOfer()
        {

            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Obtener_Ofertas]";
            SqlDataReader reader = cmd.ExecuteReader();
            List<OfertaTemporada> listSeasonOffer = new List<OfertaTemporada>();

            while (reader.Read())
            {
                OfertaTemporada seasonOffer = new OfertaTemporada();
                seasonOffer.PK_Oferta_Temporada = (int)reader["PK_Oferta_Temporada"];
                seasonOffer.Temporada = (string)reader["Temporada"];
                seasonOffer.Tipo_Habitacion = (string)reader["Tipo_Habitacion"];
                seasonOffer.Oferta = (decimal)reader["Oferta"];
                listSeasonOffer.Add(seasonOffer);
            }

            if (listSeasonOffer.Count > 0)
            {
                return Ok(listSeasonOffer);
            }

            return BadRequest();

        }


        // GET: api/Entity_OfertaTemporada/GetSeasonalsOffers
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_OfertaTemporada>> GetSeasonalsOffers()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_OfertaTemporada>().ToListAsync();
        }

        private bool Entity_OfertaTemporadaExists(int id)
        {
            return _context.Entity_OfertaTemporada.Any(e => e.PK_Oferta_Temporada == id);
        }
    }
}

