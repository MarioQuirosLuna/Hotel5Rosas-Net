using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    [Table("Hotel", Schema = "HOTEL")]
    public class Entity_Hotel
    {
        [Key]
        public int PK_Hotel { get; set; }
        public string Nombre { get; set; }
    }
}
