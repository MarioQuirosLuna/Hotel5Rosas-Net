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
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Entities_Hotel_5_Rosas.Modelos;

namespace Hotel_5_Rosas_Proyect.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "GET, POST, PUT, DELETE, OPTIONS")]
    [Route("api/[controller]/[action]")]
    [ApiController]

    public class Entity_PaginaController : Controller
    {
        private readonly DA_Hotel_5_Rosas_Pagina _context;

        public Entity_PaginaController(DA_Hotel_5_Rosas_Pagina context)
        {
            _context = context;
        }

        // GET: api/Entity_Pagina/GetPages
        [HttpGet]
        public async Task<IEnumerable<Entities_Hotel_5_Rosas.Entity_Pagina>> GetPages()
        {
            return await _context.Set<Entities_Hotel_5_Rosas.Entity_Pagina>().ToListAsync();
        }

        // GET: api/Entity_Pagina/GetHomePage
        [HttpGet]
        public async Task<Entity_PaginaHome> GetHomePage()
        {
            Entity_PaginaHome page = new Entity_PaginaHome();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Informacion_Home", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            page.Titulo = item["Titulo"].ToString();
                            page.Nombre = item["Nombre"].ToString();
                            page.Informacion = item["Informacion"].ToString();
                            page.Imagen = item["Imagen"].ToString();
                        }
                    }
                    return page;
                }
            }
        }

        // GET: api/Entity_Pagina/GetAboutUsPage
        [HttpGet]
        public async Task<Entity_PaginaSobreNosotros> GetAboutUsPage()
        {
            Entity_PaginaSobreNosotros page = new Entity_PaginaSobreNosotros();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Informacion_Sobre_Nosotros", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            page.Titulo = item["Titulo"].ToString();
                            page.Nombre = item["Nombre"].ToString();
                            page.Informacion = item["Informacion"].ToString();
                        }
                    }
                    return page;
                }
            }
        }


 
        // GET: api/Entity_Pagina/getFacilityData
        [HttpGet] 
        public List<Entities_Hotel_5_Rosas.Entity_Obtener_Facilidades> getFacilityData()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Facilidades";
            
            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Obtener_Facilidades> tipos = new List<Entity_Obtener_Facilidades>();
            while (reader.Read())
            {
                Entity_Obtener_Facilidades tipo = new Entity_Obtener_Facilidades();
                tipo.PK_Facilidad = (int)reader["PK_Facilidad"];
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Descripcion = (string)reader["Descripcion"];
                tipo.FK_Imagen = (int)reader["FK_Imagen"];
                tipo.Imagen = (string)reader["Imagen"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }



        // GET: api/Entity_Pagina/getTarifas
        [HttpGet]
        public  List<Entities_Hotel_5_Rosas.Modelos.Entity_Tarifas> getTarifas()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Caracteristicas_Habitacion";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_Tarifas> tipos = new List<Entity_Tarifas>();
            while (reader.Read())
            {
                Entity_Tarifas tipo = new Entity_Tarifas();
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Descripcion = (string)reader["Descripcion"];
                tipo.Tarifa = (decimal)reader["Tarifa"];
                tipo.Imagen = (string)reader["Imagen"];
                tipo.Caracteristicas = (string)reader["Caracteristicas"];
                tipo.Ofertas_Temporada = (string)reader["Ofertas_Temporada"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }

        // GET: api/Entity_Pagina/getComoLlegar
        [HttpGet]
        public List<Entities_Hotel_5_Rosas.Modelos.Entity_PaginaComoLLegar> getComoLlegar()
        {
            SqlConnection conexion = (SqlConnection)_context.Database.GetDbConnection();
            SqlCommand cmd = conexion.CreateCommand();
            conexion.Open();
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandText = "SP_Obtener_Informacion_Como_Llegar";

            SqlDataReader reader = cmd.ExecuteReader();
            List<Entity_PaginaComoLLegar> tipos = new List<Entity_PaginaComoLLegar>();
            while (reader.Read())
            {
                Entity_PaginaComoLLegar tipo = new Entity_PaginaComoLLegar();
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Titulo = (string)reader["Titulo"];
                tipo.Informacion = (string)reader["Informacion"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }


        // GET: api/Entity_Pagina/GetEasePage
        [HttpGet]
        public async Task<Entity_PaginaHome> GetEasePage()
        {
            Entity_PaginaHome page = new Entity_PaginaHome();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Informacion_Facilidades", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            page.Titulo = item["Titulo"].ToString();
                            page.Nombre = item["Nombre"].ToString();
                            page.Informacion = item["Informacion"].ToString();
                        }
                    }
                    return page;
                }
            }
        }


       



        //---------------------------------------PUTS Modificar-------------------------------------------

        // PUT: api/Entity_Pagina/PutModificarPagina
        [HttpPut]
        public async Task<ActionResult<Entity_Pagina>> PutModificarPagina(Entity_Pagina pagina)
        {
            await _context.Database
                .ExecuteSqlInterpolatedAsync($@"EXEC SP_Modificar_Pagina
                                                  @param_id={pagina.PK_Pagina}, @param_Nombre={pagina.Nombre}, 
                                            @param_Titulo={pagina.Titulo}, @param_Informacion={pagina.Informacion}");

            return Ok(pagina);
        }




        //--------------------------Home------------------------------------------------
        // PUT: api/Entity_Pagina/UpdateHome
        [HttpPut]
        public async Task<IActionResult> UpdateHome(Entity_PaginaHome page)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Pagina_Home", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Informacion", page.Informacion);
                    cmd.Parameters.AddWithValue("@param_Imagen", page.Imagen);

                

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



        //--------------------------Como Llegar------------------------------------------------
        // PUT: api/Entity_Pagina/UpdaHowToGet
        [HttpPut]
        public async Task<IActionResult> UpdateHowToGet(Entity_PaginaComoLLegar page)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Pagina_Como_Llegar", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Informacion", page.Informacion);

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


        //--------------------------Sobre nosotros------------------------------------------------
        // PUT: api/Entity_Pagina/UpdateAboutUs
        [HttpPut]
        public async Task<IActionResult> UpdateAboutUs(Entity_PaginaComoLLegar page)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Pagina_Sobre_Nosotros", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Informacion", page.Informacion);

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


        //--------------------------Facilidad------------------------------------------------
        // PUT: api/Entity_Pagina/UpdateEase
        [HttpPut]
        public async Task<IActionResult> UpdateEase(Entity_PaginaComoLLegar page)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Pagina_Facilidades", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Informacion", page.Informacion);

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


        //----------------------------------------------Contactenos----------------------------------------------
        // GET: api/Entity_Pagina/GetInformationContactUs
        [HttpGet]
        public async Task<Entity_PaginaHome> GetInformationContactUs()
        {
            Entity_PaginaHome page = new Entity_PaginaHome();
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Obtener_Informacion_Contactenos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    using (var item = await cmd.ExecuteReaderAsync())
                    {
                        if (await item.ReadAsync())
                        {
                            page.Titulo = item["Titulo"].ToString();
                            page.Nombre = item["Nombre"].ToString();
                            page.Informacion = item["Informacion"].ToString();
                        }
                    }
                    return page;
                }
            }
        }


        // PUT: api/Entity_Pagina/UpdateInformationContacUs
        [HttpPut]
        public async Task<IActionResult> UpdateInformationContacUs(Entity_Pagina page)
        {
            using (var sql = (SqlConnection)_context.Database.GetDbConnection())
            {
                using (var cmd = new SqlCommand("SP_Modificar_Pagina_Contactenos", sql))
                {
                    await sql.OpenAsync();
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@param_Informacion", page.Informacion);

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



        private bool Entity_PaginaExists(int id)
        {
            return _context.Entity_Pagina.Any(e => e.PK_Pagina == id);
        }
    }
}
