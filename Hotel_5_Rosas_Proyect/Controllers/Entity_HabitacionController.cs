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


        private bool Entity_HabitacionExists(int id)
        {
            return _context.Entity_Habitacion.Any(e => e.PK_Habitacion == id);
        }
    }
}
