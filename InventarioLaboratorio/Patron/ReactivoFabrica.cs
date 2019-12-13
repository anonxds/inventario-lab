using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio.Patron
{
  abstract  class ReactivoFabrica
    {
        public abstract ReactivoInfo GetReactivo();
    }
}
