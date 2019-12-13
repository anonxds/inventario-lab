using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace InventarioLaboratorio.PatronTemplate
{
    public class ClaseAzure : InterfaceMetodos
    {

        private SqlConnection con;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private SqlDataAdapter db;

        public void populate(ComboBox cb, string query, string type)
        {
            setcon();
            cb.Items.Clear();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();

            DataTable dt = new DataTable();
            SqlDataAdapter db = new SqlDataAdapter(cmd);
            db.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cb.Items.Add(dr[type]).ToString();
            }
            con.Close();
        }
        public void dgrid(DataGridView dg, string query)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            setcon();
            con.Open();
            cmd = con.CreateCommand();
            db = new SqlDataAdapter(query, con);
            ds.Reset();
            db.Fill(ds);
            dt = ds.Tables[0];
            dg.DataSource = dt;
            con.Close();
        }

        public void exe(string query)
        {
            setcon();
            con.Open();
            cmd = con.CreateCommand();
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public string obtenerDato(string consulta, string dato)
        {
            setcon();
            cmd = con.CreateCommand();
            cmd.CommandText = consulta;
            SqlDataReader reader;
            con.Open();
            reader = cmd.ExecuteReader();

            string userRole = string.Empty;
            while (reader.Read())
            {
                userRole = reader[dato].ToString();
            }
            con.Close();
            return userRole;
        }

        public void setcon()
        {
            con = new SqlConnection("Server=tcp:karinaitt.database.windows.net,1433;Initial Catalog=Laboratorio;Persist Security Info=False;User ID=karina;Password=Jona6812;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");

        }
    }
}
