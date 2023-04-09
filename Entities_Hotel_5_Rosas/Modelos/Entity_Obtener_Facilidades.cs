using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities_Hotel_5_Rosas
{
    public class Entity_Obtener_Facilidades
    {
        public int PK_Facilidad { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int FK_Imagen { get; set; }
        public string Imagen { get; set; }

    }
}
