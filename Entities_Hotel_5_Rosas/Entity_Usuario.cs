using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{

    [Table("Usuario", Schema = "USUARIOS")]

    public class Entity_Usuario
    {

        [Key]
        public int PK_Usuario { get; set; }
        public string Nombre { get; set; }
        public string Apellidos { get; set; }

    }
}
