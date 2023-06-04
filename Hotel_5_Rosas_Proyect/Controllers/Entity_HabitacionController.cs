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
    public class Entity_HabitacionController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Habitacion _context;

        public Entity_HabitacionController(DA_Hotel_5_Rosas_Habitacion context)
        {
            _context = context;
        }

        // GET: api/Entity_Habitacion/GetRooms
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Habitacion>> GetRooms()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Habitacion>().ToListAsync();
        }

        // GET: api/Entity_Habitacion/GetAvaibilityRoom
        [HttpGet("{startDate}/{endDate}/{roomType}")]
        public List<Entity_HabitacionReserva> GetAvaibilityRoom(DateTime startDate, DateTime endDate,int roomType )
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Habitacion_Disponible]";
            cmd.Parameters.AddWithValue("@param_Fecha_Inicio", startDate);
            cmd.Parameters.AddWithValue("@param_Fecha_Fin", endDate);
            cmd.Parameters.AddWithValue("@param_Tipo_Habitacion", roomType);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_HabitacionReserva> listRooms = new List<Entity_HabitacionReserva>();

            while (reader.Read())
            {
                Entity_HabitacionReserva room = new Entity_HabitacionReserva();
                room.PK_habitacion = (int)reader["PK_Habitacion"];
                room.Tipo_Habitacion = (string)reader["Nombre"];
                room.Numero_Habitacion = (int)reader["Numero_Habitacion"];
                //room.Imagen = (string)reader["Imagen"];
                room.Descripcion = (string)reader["Descripcion"];
                room.Tarifa = (decimal)reader["Tarifa"];
                room.Oferta = (decimal)reader["Oferta"];
                room.Nombre_Temporada = (string)reader["Temporada"];

                listRooms.Add(room);
            }
            conexion.Close();

            return listRooms;
        }


        //----------Estado de la habitacion al dia de hoy
        [HttpGet]// GET: api/Entity_Habitacion/GetEstadoHabitacion
        public List<Entities_Hotel_5_Rosas.Modelos.Entity_Estado_Habitacion> GetEstadoHabitacion()
        {

            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Estado_Habitaciones_Hoy";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Estado_Habitacion> tipos = new List<Entity_Estado_Habitacion>();
            while (reader.Read())
            {
                Entity_Estado_Habitacion tipo = new Entity_Estado_Habitacion();
                tipo.PK_Habitacion = (int)reader["PK_Habitacion"];
                tipo.Numero_Habitacion = (int)reader["Numero_Habitacion"];
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Estado_Del_Dia = (string)reader["Estado_Del_Dia"];
                tipo.FK_Tipo_Habitacion = (int)reader["FK_Tipo_Habitacion"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }


        // GET: api/Entity_Habitacion/GetOneRoom
        [HttpGet("{numero_Habitacion}")]
        public List<Entity_Estado_Habitacion> GetOneRoom(int numero_Habitacion)
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Obtener_Una_Habitacion]";
            cmd.Parameters.AddWithValue("@param_PK_Habitacion", numero_Habitacion);
 
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Estado_Habitacion> listRooms = new List<Entity_Estado_Habitacion>();

            while (reader.Read())
            {
                Entity_Estado_Habitacion room = new Entity_Estado_Habitacion();
                room.PK_Habitacion = (int)reader["PK_Habitacion"];
                room.Numero_Habitacion = (int)reader["Numero_Habitacion"];
                room.Nombre = (string)reader["Nombre"];
                room.Estado_Del_Dia = (string)reader["Estado"];

                listRooms.Add(room);
            }
            conexion.Close();

            return listRooms;
        }




        //---------------------------PUT

        // PUT: api/Entity_TipoHabitacion/UpdateRoom
        [HttpPut]
        public async Task<IActionResult> UpdateRoom(Entity_Habitacion room)
        {
            Entity_TipoHabitacion tipo = new Entity_TipoHabitacion();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Habitacion", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Habitacion", room.PK_Habitacion);
                    cmd.Parameters.AddWithValue("@param_FK_Tipo_Habitacion", room.FK_Tipo_Habitacion);
                    cmd.Parameters.AddWithValue("@param_Estado", room.Estado);

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



        //---------------------------Post

        // Post: api/Entity_TipoHabitacion/InsertRoom
        [HttpPost]
        public async Task<IActionResult> InsertRoom(Entity_Habitacion room)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Insertar_Habitacion", sql))
                {

                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_FK_Tipo_Habitacion", room.FK_Tipo_Habitacion);
                    cmd.Parameters.AddWithValue("@param_Estado", room.Estado);

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



        //----------------------------DELETE-----------------------------
        // PUT: api/Entity_Facilidad/PutEliminarFacilidad
        [HttpDelete("{PK_Habitacion}")]
        public async Task<ActionResult<Entity_Reserva>> PutEliminarFacilidad(int PK_Habitacion)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Eliminar_Habitacion", sql))
                {

                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_PK_Habitacion", PK_Habitacion);
                   
                    int rowsAffected = await cmd.ExecuteNonQueryAsync();

                    if (rowsAffected > 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        return NotFound("La habitacion tiene reservaciones pendientes");
                    }
                }
            }
        }




        private bool Entity_HabitacionExists(int id)
        {
            return _context.Entity_Habitacion.Any(e => e.PK_Habitacion == id);
        }
    }
}
