using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities_Hotel_5_Rosas;

namespace Hotel_5_Rosas_Proyect.Data
{
    public class DA_Hotel_5_Rosas_Galeria : DbContext
    {
        public DA_Hotel_5_Rosas_Galeria (DbContextOptions<DA_Hotel_5_Rosas_Galeria> options)
            : base(options)
        {
        }

        public DbSet<Entities_Hotel_5_Rosas.Entity_Imagen> Entity_Imagen { get; set; }

        public DbSet<Entities_Hotel_5_Rosas.Entity_Galeria> Entity_Galeria { get; set; }
    }
}
