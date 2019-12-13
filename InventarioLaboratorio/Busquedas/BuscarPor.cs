using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioLaboratorio.Busquedas
{
    class BuscarPor : BusquedasP
    {
        public override void Buscar(DataGridView dgv, string nombre,TextBox txt)
        {
            (dgv.DataSource as DataTable).DefaultView.RowFilter = string.Format("["+nombre+"] like '%{0}%'", txt.Text);

        }
    }
}
