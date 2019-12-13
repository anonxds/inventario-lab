using InventarioLaboratorio.PatronTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioLaboratorio
{
    
    public partial class pruebadeconexion : Form
    {

        public pruebadeconexion()
        {
            InitializeComponent();

            Sql s = new Sql();
        }
        public static List<string> GetImportedFileList()
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"select * from Reactivo";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                        ImportedFiles.Add(Convert.ToString(r["Nombre"]) +","+ Convert.ToString(r["Numero"]) + "," + Convert.ToString(r["Clasificacion"]) + "," + Convert.ToString(r["Laboratorio"]) + "," + Convert.ToString(r["Caducidad"]) + "," + Convert.ToString(r["Catalogo"]) + "," + Convert.ToString(r["Unidad"]) + "," + Convert.ToString(r["Observaciones"]));
                        //material       ImportedFiles.Add(Convert.ToString(r["Material"]) + "," + Convert.ToString(r["Tipo"]) + "," + Convert.ToString(r["Capacidad"]) + "," + Convert.ToString(r["Estado"]) + "," + Convert.ToString(r["Laboratorio"]) + "," + Convert.ToString(r["Observaciones"]));
                        //usuario      ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "," + Convert.ToString(r["NomUsr"]) + "," + Convert.ToString(r["Contrasena"]) + "," + Convert.ToString(r["TipoUsr"]));
                        //equipo ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "," + Convert.ToString(r["Marca"]) + "," + Convert.ToString(r["Modelo"]) + "," + Convert.ToString(r["Estado"]) + "," + Convert.ToString(r["Laboratorio"]) + "," + Convert.ToString(r["NumITT"]) + "," + Convert.ToString(r["NumSEP"]) + "," + Convert.ToString(r["ManualDP"]) + ","+ Convert.ToString(r["NumSerie"]) +","+Convert.ToString(r["Observaciones"]));

                    

                    }
                }
            }
            return ImportedFiles;
        }




        private void button1_Click(object sender, EventArgs e)
        {
            string[] lista = GetImportedFileList().ElementAt(1).ToString().Split(',');
            button1.Text = lista[4].ToString();
        }
        private SQLiteConnection con;
        private SQLiteCommand cmd;
        private SQLiteDataReader dr;
        private SQLiteDataAdapter db;

        public void dgrid(DataGridView dg, string query)
        {
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            setcon();
            con.Open();
            cmd = con.CreateCommand();
            db = new SQLiteDataAdapter(query, con);
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
            SQLiteDataReader reader;
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
            SQLiteDataAdapter db = new SQLiteDataAdapter(cmd);
            db.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                cb.Items.Add(dr[type]).ToString();
            }
            con.Close();

        }

        private void setcon()
        {
            con = new SQLiteConnection("Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;");
        }
    }
}
