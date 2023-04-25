using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hotel_5_Rosas_Proyect.Data;
using Microsoft.OpenApi.Models;

namespace Hotel_5_Rosas_Proyect
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //CORS
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(builder =>
                {
                    builder.SetIsOriginAllowed(_ => true)
                           .AllowAnyHeader()
                           .AllowAnyMethod();
                });
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Hotel5Rosas", Version = "v1" });
            });

            services.AddControllers();

            services.AddDbContext<DA_Hotel_5_Rosas_Usuario>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Cliente>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Administrador>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Publicidad>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Pagina>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Galeria>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Temporada>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Telefono>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Correo>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Facilidad>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Hotel>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Reserva>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Habitacion>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_TipoHabitacion>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_Caracteristicas>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

            services.AddDbContext<DA_Hotel_5_Rosas_OfertaTemporada>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("SQL")));

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                ConfigureSwagger(app);
            });
        }

        private void ConfigureSwagger(IApplicationBuilder app)
        {
            // Habilitar middleware para servir la documentación generada por Swagger como un endpoint JSON.
            app.UseSwagger();

            // Habilitar middleware para servir swagger-ui (HTML, JS, CSS, etc.), especificando la ruta del archivo Swagger JSON.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nombre de la API");
            });

            // Redireccionar la URL base a la URL de Swagger
            app.Use(async (context, next) =>
            {
                if (context.Request.Path.Value == "/")
                {
                    context.Response.Redirect("/swagger");
                    return;
                }

                await next();
            });
        }
    }
}
