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
using System.Net.Mail;

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

        //------------------------------------------GETS-------------------------------
        // GET: api/Entity_Reserva/GetReservations
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Reserva>> GetReservations()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Reserva>().ToListAsync();
        }

        //----------------------------Available Room-----------------------------
        // GET: api/Entity_Habitacion/GetAvaibilityRoom
        [HttpGet("{startDate}/{endDate}/{roomType}")]
        public ActionResult<Entity_HabitacionReserva> GetAvaibilityRoom(DateTime startDate, DateTime endDate, int roomType)
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Habitacion_Disponible_Cliente]";
            cmd.Parameters.AddWithValue("@param_Fecha_Inicio", startDate);
            cmd.Parameters.AddWithValue("@param_Fecha_Fin", endDate);
            cmd.Parameters.AddWithValue("@param_Tipo_Habitacion", roomType);
            SqlDataReader reader = cmd.ExecuteReader();

            Entity_HabitacionReserva room = new Entity_HabitacionReserva();
            if (reader.HasRows)
            {
                reader.Read();
                room.PK_habitacion = (int)reader["PK_Habitacion"];
                room.Tipo_Habitacion = (string)reader["Nombre"];
                room.Numero_Habitacion = (int)reader["Numero_Habitacion"];
                room.Imagen = (string)reader["Imagen"];
                room.Descripcion = (string)reader["Descripcion"];
                room.Tarifa = (decimal)reader["Tarifa"];
                room.Oferta = (decimal)reader["Oferta"];
                room.Nombre_Temporada = (string)reader["Temporada"];

                conexion.Close();
                return Ok(room);
            }
            else {               
                conexion.Close();
                return NotFound();
            }

        }


        // GET: api/Entity_Reserva/getAllReservation
        [HttpGet]
        public List<Reservacion> GetAllReservation()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Reservaciones";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Reservacion> reservaciones = new List<Reservacion>();
            while (reader.Read())
            {
                Reservacion reservacion = new Reservacion();
                reservacion.PK_Reserva = (int)reader["PK_Reserva"];
                reservacion.Tipo_Habitacion = (string)reader["Tipo_Habitacion"];
                reservacion.Nombre_Cliente = (string)reader["Nombre_Cliente"];
                reservacion.Apellidos_Cliente = (string)reader["Apellidos_Cliente"];
                reservacion.Numero_Tarjeta = (string)reader["Numero_Tarjeta"];
                reservacion.Correo = (string)reader["Correo"];
                reservacion.Fecha_Transaccion = (DateTime)reader["Fecha_Transaccion"];
                reservacion.Fecha_Inicio = (DateTime)reader["Fecha_Inicio"];
                reservacion.Fecha_Fin = (DateTime)reader["Fecha_Fin"];
                reservacion.Tarifa_Total = (decimal)reader["Tarifa_Total"];

                reservaciones.Add(reservacion);
            }
            conexion.Close();

            return reservaciones;
        }

        // GET: api/Entity_Reserva/GetUniqueReservation
        [HttpGet("{PK_Reserva}")]
        public ActionResult<Reservacion> GetUniqueReservation(int PK_Reserva)
        {

            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Obtener_Una_Reservacion]";
            cmd.Parameters.Add("@param_PK_Reserva", System.Data.SqlDbType.Int).Value = PK_Reserva;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Reservacion> listReservacion = new List<Reservacion>();

            while (reader.Read())
            {
                Reservacion reservation = new Reservacion();
                reservation.PK_Reserva = (int)reader["PK_Reserva"];
                reservation.Tipo_Habitacion = (string)reader["Tipo_Habitacion"];
                reservation.Nombre_Cliente = (string)reader["Nombre_Cliente"];
                reservation.Apellidos_Cliente = (string)reader["Apellidos_Cliente"];
                reservation.Numero_Tarjeta = (string)reader["Numero_Tarjeta"];
                reservation.Correo = (string)reader["Correo"];
                reservation.Fecha_Transaccion = (DateTime)reader["Fecha_Transaccion"];
                reservation.Fecha_Inicio = (DateTime)reader["Fecha_Inicio"];
                reservation.Fecha_Fin = (DateTime)reader["Fecha_Fin"];
                reservation.Tarifa_Total = (decimal)reader["Tarifa_Total"];

                listReservacion.Add(reservation);
            }

            if (listReservacion.Count > 0)
            {
                return Ok(listReservacion[0]);
            }

            return BadRequest();

        }




        //----------------------------Save Reservation-----------------------------
        // POST: api/Entity_Reserva/SaveReservation
        [HttpPost]
        public ActionResult SaveReservation(Entity_Reserva reserva)
        {
            try
            {
                using (var connection = new SqlConnection(_context.Database.GetConnectionString()))
                {
                    using (var command = new SqlCommand("SP_Insertar_Reserva", connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Agregar parámetros al procedimiento almacenado
                        command.Parameters.AddWithValue("@param_FK_Habitacion", reserva.FK_Habitacion);
                        command.Parameters.AddWithValue("@param_Nombre_Cliente", reserva.Nombre_Cliente);
                        command.Parameters.AddWithValue("@param_Apellidos_Cliente", reserva.Apellidos_Cliente);
                        command.Parameters.AddWithValue("@param_Numero_Tarjeta", reserva.Numero_Tarjeta);
                        command.Parameters.AddWithValue("@param_Correo", reserva.Correo);
                        command.Parameters.AddWithValue("@param_Fecha_Transaccion", reserva.Fecha_Transaccion);
                        command.Parameters.AddWithValue("@param_Fecha_Inicio", reserva.Fecha_Inicio);
                        command.Parameters.AddWithValue("@param_Fecha_Fin", reserva.Fecha_Fin);
                        command.Parameters.AddWithValue("@param_Tarifa_Total", reserva.Tarifa_Total);

                        // Agregar el parámetro de salida para capturar el ID retornado
                        var outputParameter = new SqlParameter("@ReturnValue", SqlDbType.Int)
                        {
                            Direction = ParameterDirection.ReturnValue
                        };
                        command.Parameters.Add(outputParameter);

                        // Abrir la conexión y ejecutar el procedimiento almacenado
                        connection.Open();
                        command.ExecuteScalar();

                        // Obtener el ID retornado por el procedimiento almacenado
                        var reservaId = outputParameter.Value;

                        //Send Email
                        string SendEmail = "hotel5rosas@gmail.com";
                        string password = "qoeibqtzyjikyaze";
                        MailMessage mailMessage = new MailMessage(SendEmail, reserva.Correo, "Reservación realizada en Hotel5Rosas",
                            "<!DOCTYPE html>\r\n<html>\r\n<head>\r\n    <style>\r\n        body {\r\n            font-family: Arial, sans-serif;\r\n            font-size: 14px;\r\n        }\r\n        table {\r\n            border-collapse: collapse;\r\n            width: 100%;\r\n        }\r\n        th, td {\r\n            padding: 8px;\r\n            text-align: left;\r\n            border-bottom: 1px solid #ddd;\r\n        }\r\n        th {\r\n            background-color: #f2f2f2;\r\n        }\r\n    </style>\r\n</head>\r\n<body>\r\n    <h2>Reservación realizada con éxito</h2>\r\n    <table>\r\n        <tr>\r\n            <th>Nombre</th>\r\n            <td>"+reserva.Nombre_Cliente+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Apellidos</th>\r\n            <td>"+reserva.Apellidos_Cliente+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Habitación</th>\r\n            <td>"+reserva.FK_Habitacion+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Fecha de transacción</th>\r\n            <td>"+reserva.Fecha_Transaccion+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Fecha de inicio</th>\r\n            <td>"+reserva.Fecha_Inicio+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Fecha de fin</th>\r\n            <td>"+reserva.Fecha_Fin+"</td>\r\n        </tr>\r\n        <tr>\r\n            <th>Tarifa total</th>\r\n            <td>"+reserva.Tarifa_Total+"</td>\r\n        </tr>\r\n    </table>\r\n</body>\r\n</html>\r\n");
                        mailMessage.IsBodyHtml = true;

                        SmtpClient smtpClient = new SmtpClient("smtp.gmail.com");
                        smtpClient.EnableSsl = true;
                        smtpClient.UseDefaultCredentials = false;
                        smtpClient.Host = "smtp.gmail.com";
                        smtpClient.Port = 587;
                        smtpClient.Credentials = new System.Net.NetworkCredential(SendEmail, password);

                        smtpClient.Send(mailMessage);
                        smtpClient.Dispose();

                        return Ok(reservaId);
                    }
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }



        //----------------------------DELETE-----------------------------

        // Delete: api/Entity_Reserva/PutEliminarReserva
        [HttpDelete("{PK_Reserva}")]
        public async Task <ActionResult<Entity_Reserva>> PutEliminarReserva(int PK_Reserva)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Eliminar_Reserva
                                                  @param_Id={PK_Reserva}");

            return Ok();
        }

         


        private bool Entity_ReservaExists(int id)
        {
            return _context.Entity_Reserva.Any(e => e.PK_Reserva == id);
        }
    }
}
