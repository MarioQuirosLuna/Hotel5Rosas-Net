using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Administrador", Schema = "USUARIOS")]

    public class Entity_Administrador
    {
        [Key]
        public int PK_Administrador { get; set; }
        public int FK_Usuario { get; set; }
        public string Nombre_Usuario { get; set; }
        public string Constrasenna { get; set; }

    }
}
