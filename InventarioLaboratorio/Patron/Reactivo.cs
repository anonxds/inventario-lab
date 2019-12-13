using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio.Patron
{
   abstract class ReactivoInfo
    {
       
        public abstract string Nombre { get; set; }
        public abstract string Numero { get; set; }
        public abstract string Clasificacion { get; set; }
        public abstract string Laboratorio { get; set; }
        public abstract string Caducidad { get; set; }
        public abstract string Catalogo { get; set; }
        public abstract string Unidad { get; set; }
        public abstract string Observacion { get; set; }

    }
}
