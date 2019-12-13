using InventarioLaboratorio.PatronTemplate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio
{
    class Categorias
    {
        Sql sql = new Sql();
        private SqlConnection con = new SqlConnection("Server=tcp:karinaitt.database.windows.net,1433;Initial Catalog=Laboratorio;Persist Security Info=False;User ID=karina;Password=Jona6812;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        public DataTable CargarComboLaboratorio()
        {
            SqlDataAdapter da = new SqlDataAdapter("CargarComboBox", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboEquipo()
        {
            SqlDataAdapter da = new SqlDataAdapter("CargarComboBoxEquipo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboMaterial()
        {
            SqlDataAdapter da = new SqlDataAdapter("CargarComboBoxMaterial", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }

        public DataTable CargarComboReactivo()
        {
            SqlDataAdapter da = new SqlDataAdapter("CargarComboBoxReactivo", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
    }
}
