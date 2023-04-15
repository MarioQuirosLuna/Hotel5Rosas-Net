using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas.Modelos
{
    public class Entity_Estado_Habitacion
    {

        [Key]
        public int PK_Habitacion { get; set; }
        public int Numero_Habitacion { get; set; }
        public string Nombre { get; set; }
        public string Estado_Del_Dia { get; set; }


    }
}
