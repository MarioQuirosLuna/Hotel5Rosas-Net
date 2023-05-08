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

    public class Entity_AdministradorController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Administrador _context;

        public Entity_AdministradorController(DA_Hotel_5_Rosas_Administrador context)
        {
            _context = context;
        }



        // GET: api/Entity_Administrador/checkAdminstrator
        [HttpGet("{Nombre}/{constrasenna}")]
        public ActionResult<Entity_HabitacionReserva> checkAdminstrator(string Nombre, string Constrasenna)
        {

            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "[SP_Confirmar_Administrador]";
            cmd.Parameters.Add("@param_NombreUsuario", System.Data.SqlDbType.VarChar,30).Value = Nombre;
            cmd.Parameters.Add("@param_Contrasena", System.Data.SqlDbType.VarChar,30).Value = Constrasenna;
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Administrador> listAdministrator = new List<Entity_Administrador>();

            while (reader.Read())
            {
                Entity_Administrador administrator = new Entity_Administrador();
                administrator.PK_Administrador = (int)reader["PK_Administrador"];
                administrator.FK_Usuario = (int)reader["FK_Usuario"];
                administrator.Nombre_Usuario = (string)reader["Nombre_Usuario"];
                administrator.Constrasenna = (string)reader["Constrasenna"];
                listAdministrator.Add(administrator);
            }

            if(listAdministrator.Count > 0)
            {
                return Ok(listAdministrator[0]);
            }

            return BadRequest();

        }






        // GET: api/Entity_Administrador/GetAdmins
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Administrador>> GetAdmins()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Administrador>().ToListAsync();
        }

        private bool Entity_AdministradorExists(int id)
        {
            return _context.Entity_Administrador.Any(e => e.PK_Administrador == id);
        }
    }
}
