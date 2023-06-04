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
    public class Entity_TipoHabitacionController : Controller
    {
        private readonly DA_Hotel_5_Rosas_TipoHabitacion _context;

        public Entity_TipoHabitacionController(DA_Hotel_5_Rosas_TipoHabitacion context)
        {
            _context = context;
        }



        // GET: api/Entity_TipoHabitacion/GetRoomTypes
        [HttpGet]
        public List<Entities_Hotel_5_Rosas.Entity_TipoHabitacion> GetRoomTypes()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Tipos_Habitacion";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_TipoHabitacion> tipos = new List<Entity_TipoHabitacion>();
            while (reader.Read())
            {
                Entity_TipoHabitacion tipo = new Entity_TipoHabitacion();
                tipo.PK_Tipo_Habitacion = (int)reader["PK_Tipo_Habitacion"];
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Descripcion = (string)reader["Descripcion"];
                tipo.Tarifa = (decimal)reader["Tarifa"];
                tipo.Imagen = (string)reader["Imagen"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }

        // GET: api/Entity_TipoHabitacion/GetRoomTypesById
        [HttpGet("{Pk_tipo_habitacion}")]
        public async Task<Entities_Hotel_5_Rosas.Entity_TipoHabitacion> GetRoomTypesById(int Pk_tipo_habitacion)
        {
            Entity_TipoHabitacion tipo = new Entity_TipoHabitacion();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Un_Tipo_Habitacion", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Tipo_Habitacion", Pk_tipo_habitacion);
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            tipo.PK_Tipo_Habitacion = (int)item["PK_Tipo_Habitacion"];
                            tipo.Nombre = (string)item["Nombre"];
                            tipo.Descripcion = (string)item["Descripcion"];
                            tipo.Tarifa = (decimal)item["Tarifa"];
                            tipo.Imagen = (string)item["Imagen"];
                        }
                    }
                    return tipo;
                }
            }
        }



        //---------------------------------Put

        // PUT: api/Entity_TipoHabitacion/PutRoomTypesById
        [HttpPut]
        public async Task<IActionResult> PutRoomTypesById(Entity_TipoHabitacion tipo_habitacion)
        {
            Entity_TipoHabitacion tipo = new Entity_TipoHabitacion();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Actualizar_Tipo_Habitacion", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Tipo_Habitacion", tipo_habitacion.PK_Tipo_Habitacion);
                    cmd.Parameters.AddWithValue("@param_Nombre", tipo_habitacion.Nombre);
                    cmd.Parameters.AddWithValue("@param_Descripcion", tipo_habitacion.Descripcion);
                    cmd.Parameters.AddWithValue("@param_Tarifa", tipo_habitacion.Tarifa);
                    cmd.Parameters.AddWithValue("@param_Imagen", tipo_habitacion.Imagen);

                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return Ok(); // Se actualizó correctamente
                    }
                    else
                    {
                        return NotFound(); // No se encontró el elemento para actualizar
                    }
                }
            }
        }

       
        



        private bool Entity_TipoHabitacionExists(int id)
        {
            return _context.Entity_TipoHabitacion.Any(e => e.PK_Tipo_Habitacion == id);
        }
    }
}
