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
using Entities_Hotel_5_Rosas.Modelos;
using Microsoft.Data.SqlClient;
using System.Data;

namespace Hotel_5_Rosas_Proyect.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Entity_ReservaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Reserva _context;

        public Entity_ReservaController(DA_Hotel_5_Rosas_Reserva context)
        {
            _context = context;
        }

        // GET: api/Entity_Reserva/GetReservations
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Reserva>> GetReservations()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Reserva>().ToListAsync();
        }

        //----------------------------Available Room-----------------------------
        // GET: api/Entity_Reserva/GetAvalaibleRoom
        [HttpGet]
        public ActionResult<Entity_HabitacionReserva> GetAvalaibleRoom(DateTime beginDate, DateTime endDate, int tipeRoom) {
            using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
            {
                using (var command = new SqlCommand("SP_Habitacion_Disponible", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    // Agregar parámetros al procedimiento almacenado
                    command.Parameters.AddWithValue("@param_Fecha_Inicio", beginDate);
                    command.Parameters.AddWithValue("@param_Fecha_Fin", endDate);
                    command.Parameters.AddWithValue("@param_Tipo_Habitacion", tipeRoom);
                    // Agregar más parámetros según sea necesario

                    // Abrir la conexión y ejecutar el procedimiento almacenado
                    connection.Open();
                    var reader = command.ExecuteReader();

                    // Procesar los resultados del procedimiento almacenado
                    Entity_HabitacionReserva room = new Entity_HabitacionReserva();
                    if (reader.HasRows)
                    {
                        reader.Read();
                        // Acceder a los valores de las columnas devueltas por el procedimiento almacenado
                        room.PK_habitacion = (int)reader["PK_Habitacion"];
                        room.Tipo_Habitacion = (string)reader["Nombre"];
                        room.Numero_Habitacion = (int)reader["Numero_Habitacion"];
                        room.Imagen = (string)reader["Imagen"];
                        room.Descripcion = (string)reader["Descripcion"];
                        room.Tarifa = (decimal)reader["Tarifa"];
                        room.Oferta = (decimal)reader["Oferta"];
                        room.Nombre_Temporada = (string)reader["Nombre"];
                        // Acceder a más columnas según sea necesario
                    }
                    reader.Close();
                    return Ok(room);
                }
            }

        }

        //----------------------------DELETE-----------------------------

        // PUT: api/Entity_Reserva/PutEliminarReserva
        [HttpPut("{PK_Reserva}")]
        public async Task <ActionResult<Entity_Reserva>> PutEliminarReserva(int PK_Reserva)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Eliminar_Reserva
                                                  @param_Id={PK_Reserva}");

            return Ok("Ok");
        } 


        private bool Entity_ReservaExists(int id)
        {
            return _context.Entity_Reserva.Any(e => e.PK_Reserva == id);
        }
    }
}
