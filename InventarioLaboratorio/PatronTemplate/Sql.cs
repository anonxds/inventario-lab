using System;
using System.Net;
using System.Windows.Forms;

namespace InventarioLaboratorio.PatronTemplate
{
    public class Sql : InterfaceMetodos
    {
        ClaseSQLite lite = new ClaseSQLite();
        ClaseAzure _azute = new ClaseAzure();
        public static bool checkInternet()
        {
            try 
            {
                using (var client = new WebClient())
                using (client.OpenRead("http://www.google.com"))
                return true;
            }
            catch 
            {
                return false;
            }
        }

        public void dgrid(DataGridView dg, string query)
        {
            if (checkInternet() == true)
            {
                _azute.dgrid(dg, query);
            }
            else if (checkInternet() == false)
            {
                lite.dgrid(dg, query);
            }
        }

        public void exe(string query)
        {
            if (checkInternet() == true) 
            {
                _azute.exe(query);
            }
            else if (checkInternet() == false) 
            {
                lite.exe(query);
            }
        }

        public string obtenerDato(string consulta, string dato)
        {
            if (checkInternet() == true)
            {
             return  _azute.obtenerDato(consulta,dato);
            }
            else if (checkInternet() == false)
            {
              return lite.obtenerDato(consulta,dato);
            }
            return null;
        }

        public void populate(ComboBox cb, string query, string type)
        {
            if (checkInternet() == true)
            {
                _azute.populate(cb, query, type);
            }
            else if (checkInternet() == false)
            {
                lite.populate(cb,query,type);
            }
        }

        public void setcon()
        {
            throw new NotImplementedException();
        }
    }
}
