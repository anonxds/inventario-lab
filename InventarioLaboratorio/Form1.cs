using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioLaboratorio.PatronTemplate;

namespace InventarioLaboratorio
{
    public partial class Login : Form
    {
        //Inicio del Patron Singleton
        private static Login _instanciaLogin;

        public static Login ObtenerInstanciaLogin()
        {
            if (_instanciaLogin == null || _instanciaLogin.IsDisposed)
            {
                _instanciaLogin = new Login();
            }
            _instanciaLogin.BringToFront();
            return _instanciaLogin;
        }
        //Fin del Patron Singleton

        private Login()
        {
            InitializeComponent();
            txtContresena.PasswordChar = '*';
        }

        public static string TipoUsuario = "";
        Sql sql = new Sql();

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtUsuario.Text == "Admin" && txtContresena.Text == "Lab01")
                {
                    String TipoUsuario = "Administrador";
                    FrmCatalogo formCatalogo = new FrmCatalogo(TipoUsuario);
                    formCatalogo.Show();
                    this.Hide();
                    Limpiar limpiar = new Limpiar();
                    limpiar.BorrarCampos(this);
                }
                else
                {
                    SqlConnection con = new SqlConnection("Server=tcp:karinaitt.database.windows.net,1433;Initial Catalog=Laboratorio;Persist Security Info=False;User ID=karina;Password=Jona6812;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
                    string consulta = string.Format("select * from Usuario where NomUsr = '{0}' and Contrasena = '{1}'", txtUsuario.Text, txtContresena.Text);
                    SqlCommand cmd = new SqlCommand(consulta, con);
                    SqlDataReader reader;
                    SqlDataAdapter sda = new SqlDataAdapter(consulta, con);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);

                    if (dt.Rows.Count == 1)
                    {
                        TipoUsuario = sql.obtenerDato(consulta, "TipoUsr");
                        FrmCatalogo formCatalogo = new FrmCatalogo(TipoUsuario);
                        formCatalogo.Show();
                        this.Hide();
                        Limpiar limpiar = new Limpiar();
                        limpiar.BorrarCampos(this);
                    }
                    else
                    {
                        MessageBox.Show("Asegúrese de que los datos sean correctos", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    }
                }
            }
            catch
            {
                MessageBox.Show("Por favor checar la conexion de internet");
            }
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
