using System;
using System.Windows.Forms;

namespace InventarioLaboratorio.PatronTemplate
{
    interface InterfaceMetodos
    {
        void exe(string query);
        void setcon();
        void dgrid(DataGridView dg, string query);
        string obtenerDato(string consulta, string dato);
        void populate(ComboBox cb, string query, string type);
     
    }
}
