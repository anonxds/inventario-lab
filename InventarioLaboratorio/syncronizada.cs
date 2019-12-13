using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio
{
    class syncronizada
    {
        public  List<string> Reactivo()
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
                        ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Numero"]) + "+" + Convert.ToString(r["Clasificacion"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["Caducidad"]) + "+" + Convert.ToString(r["Catalogo"]) + "+" + Convert.ToString(r["Unidad"]) + "+" + Convert.ToString(r["Observaciones"]));
                        //material       ImportedFiles.Add(Convert.ToString(r["Material"]) + "+" + Convert.ToString(r["Tipo"]) + "+" + Convert.ToString(r["Capacidad"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["Observaciones"]));
                        //usuario      ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["NomUsr"]) + "+" + Convert.ToString(r["Contrasena"]) + "+" + Convert.ToString(r["TipoUsr"]));
                        //equipo ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Marca"]) + "+" + Convert.ToString(r["Modelo"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["NumITT"]) + "+" + Convert.ToString(r["NumSEP"]) + "+" + Convert.ToString(r["ManualDP"]) + "+"+ Convert.ToString(r["NumSerie"]) +"+"+Convert.ToString(r["Observaciones"]));
                    }
                }
            }
            return ImportedFiles;
        }
        public  List<string> equipo()
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"select * from Equipo";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                         ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Marca"]) + "+" + Convert.ToString(r["Modelo"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["NumITT"]) + "+" + Convert.ToString(r["NumSEP"]) + "+" + Convert.ToString(r["ManualOP"]) + "+"+ Convert.ToString(r["NumSerie"]) +"+"+Convert.ToString(r["Observaciones"]));



                    }
                }
            }
            return ImportedFiles;
        }
        public  List<string> Usuario()
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"select * from Usuario";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                              ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["NomUsr"]) + "+" + Convert.ToString(r["Contrasena"]) + "+" + Convert.ToString(r["TipoUsr"]));
                        //equipo ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Marca"]) + "+" + Convert.ToString(r["Modelo"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["NumITT"]) + "+" + Convert.ToString(r["NumSEP"]) + "+" + Convert.ToString(r["ManualDP"]) + "+"+ Convert.ToString(r["NumSerie"]) +"+"+Convert.ToString(r["Observaciones"]));

                    }
                }
            }
            return ImportedFiles;
        }
        public  List<string> Material()
        {
            List<string> ImportedFiles = new List<string>();
            using (SQLiteConnection connect = new SQLiteConnection(@"Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;"))
            {
                connect.Open();
                using (SQLiteCommand fmd = connect.CreateCommand())
                {
                    fmd.CommandText = @"select * from Material";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();
                    while (r.Read())
                    {
                               ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Tipo"]) + "+" + Convert.ToString(r["Capacidad"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["Observaciones"]));
                        //usuario      ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["NomUsr"]) + "+" + Convert.ToString(r["Contrasena"]) + "+" + Convert.ToString(r["TipoUsr"]));
                        //equipo ImportedFiles.Add(Convert.ToString(r["Nombre"]) + "+" + Convert.ToString(r["Marca"]) + "+" + Convert.ToString(r["Modelo"]) + "+" + Convert.ToString(r["Estado"]) + "+" + Convert.ToString(r["Laboratorio"]) + "+" + Convert.ToString(r["NumITT"]) + "+" + Convert.ToString(r["NumSEP"]) + "+" + Convert.ToString(r["ManualDP"]) + "+"+ Convert.ToString(r["NumSerie"]) +"+"+Convert.ToString(r["Observaciones"]));
                    }
                }
            }
            return ImportedFiles;
        }
    }
}
