using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioLaboratorio.Busquedas
{
   abstract class BusquedasP
    {

        public abstract void Buscar(DataGridView dgv, string nombre,TextBox txt);
        public void plantilla(DataGridView dgv, string nombre, TextBox txt)
        {
            Buscar(dgv,nombre,txt);
        }
       
    }
}
