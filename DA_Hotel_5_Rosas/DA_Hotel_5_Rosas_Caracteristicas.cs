﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities_Hotel_5_Rosas;

namespace Hotel_5_Rosas_Proyect.Data
{
    public class DA_Hotel_5_Rosas_Caracteristicas : DbContext
    {
        public DA_Hotel_5_Rosas_Caracteristicas (DbContextOptions<DA_Hotel_5_Rosas_Caracteristicas> options)
            : base(options)
        {
        }

        public DbSet<Entities_Hotel_5_Rosas.Entity_Caracteristicas> Entity_Caracteristicas { get; set; }
    }
}
