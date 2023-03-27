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

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
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
            });
        }
    }
}
