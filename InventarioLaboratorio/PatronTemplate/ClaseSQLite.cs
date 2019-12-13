﻿using System;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Data;

namespace InventarioLaboratorio.PatronTemplate
{
    public class ClaseSQLite : InterfaceMetodos
    {
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

        public void setcon()
        {
            con = new SQLiteConnection("Data Source=./dblocal.sqlite3;Version=3;New=False;Compress=true;");
        }
    }
}
