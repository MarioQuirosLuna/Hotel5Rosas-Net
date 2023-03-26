using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Cliente", Schema = "USUARIOS")]

    public class Entity_Cliente
    {


        [Key]
        public int PK_Cliente { get; set; }
        public int FK_Usuario { get; set; }
        public string Numero_Tarjeta { get; set; }
        public string Correo { get; set; }


    }
}
