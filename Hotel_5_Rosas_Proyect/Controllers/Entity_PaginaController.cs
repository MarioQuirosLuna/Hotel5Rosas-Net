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
using Microsoft.Extensions.Configuration;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Microsoft.AspNetCore.Mvc.RazorPages;

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
        public async Task<List<Entities_Hotel_5_Rosas.Entity_Obtener_Facilidades>> getFacilityData()
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
                tipo.Nombre = (string)reader["Nombre"];
                tipo.Descripcion = (string)reader["Descripcion"];
                tipo.Imagen = (byte[])reader["Imagen"];
                tipos.Add(tipo);
            }
            conexion.Close();

            return tipos;
        }




        private bool Entity_PaginaExists(int id)
        {
            return _context.Entity_Pagina.Any(e => e.PK_Pagina == id);
        }
    }
}
