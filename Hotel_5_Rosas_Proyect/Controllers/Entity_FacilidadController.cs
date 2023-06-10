﻿using System;
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
    public class Entity_FacilidadController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Facilidad _context;

        public Entity_FacilidadController(DA_Hotel_5_Rosas_Facilidad context)
        {
            _context = context;
        }

        // GET: api/Entity_Facilidad/GetFacilities
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Facilidad>> GetFacilities()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Facilidad>().ToListAsync();
        }


        // GET: api/Entity_Facilidad/GetOneFaclity
        [HttpGet("{PK_Facilidad}")]
        public List<Facility> GetOneFaclity(int PK_Facilidad)
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Obtener_Una_Facilidad]";
            cmd.Parameters.AddWithValue("@param_id", PK_Facilidad);

            SqlDataReader reader = cmd.ExecuteReader();
            List<Facility> listFacilty = new List<Facility>();

            while (reader.Read())
            {
                Facility facility = new Facility();
                facility.PK_Facilidad = (int)reader["PK_Facilidad"];
                facility.Nombre = (string)reader["Nombre"];
                facility.Descripcion = (string)reader["Descripcion"];
                facility.FK_Imagen = (int)reader["FK_Imagen"];
                facility.Imagen = (string)reader["Imagen"];

                listFacilty.Add(facility);
            }
            conexion.Close();

            return listFacilty;
        }



        //------------------------------------Puts--------------------------------------
        // PUT: api/Entity_Facilidad/PutModificarFacilidad
        [HttpPut]
        public async Task<ActionResult<Entity_Facilidad>> PutModificarFacilidad(Facility facilidad)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Modificar_Facilidad
                                                  @param_Id={facilidad.PK_Facilidad}, @param_Nombre={facilidad.Nombre}, 
                                                    @param_Descripcion={facilidad.Descripcion}, @param_Imagen={facilidad.Imagen}");

            return Ok(facilidad);
        }


        //----------------------------DELETE-----------------------------

        // PUT: api/Entity_Facilidad/PutEliminarFacilidad
        [HttpPut("{PK_Facilidad}")]
        public async Task<ActionResult<Entity_Reserva>> PutEliminarFacilidad(int PK_Facilidad)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Eliminar_Facilidad
                                                  @param_id={PK_Facilidad}");

            return Ok();
        }


        //---------------------------Post

        // Post: api/Entity_Facilidad/InsertFacility
        [HttpPost]
        public async Task<IActionResult> InsertFacility(Facility facility)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Insertar_Facilidad", sql))
                {

                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("param_Nombre", facility.Nombre);
                    cmd.Parameters.AddWithValue("param_Descripcion", facility.Descripcion);
                    cmd.Parameters.AddWithValue("@param_Imagen", facility.Imagen);

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




        private bool Entity_FacilidadExists(int id)
        {
            return _context.Entity_Facilidad.Any(e => e.PK_Facilidad == id);
        }
    }
}
