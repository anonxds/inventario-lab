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
using InventarioLaboratorio.PatronTemplate;

namespace InventarioLaboratorio
{
    public partial class FrmCatalogo : Form
    {
        public FrmCatalogo()
        {
            InitializeComponent();
            string consulta = string.Format("Select * from Usuario where TipoUsr ='{0}'", lblTipoUsuario.Text);
        }

        public FrmCatalogo(String texto)
        {
            InitializeComponent();
            lblNomUsuario.Text = texto;
        }

        private void btnReactivo_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmReactivos formReactivo = new FrmReactivos(TipoUsuario);
            formReactivo.Show();
            this.Hide();
        }

        private void btnEquipo_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FmEquipo formEquipo = new FmEquipo(TipoUsuario);
            formEquipo.Show();
            this.Hide();
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            Login CerrarSesion = Login.ObtenerInstanciaLogin();
            CerrarSesion.Show();
            this.Hide();
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmMaterial formMaterial = new FrmMaterial(TipoUsuario);
            formMaterial.Show();
            this.Hide();
        }

        private void btnUsuario_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmUsuarios frmUsuarios = new FrmUsuarios(TipoUsuario);
            frmUsuarios.Show();
            this.Hide();
        }

        private void btnTipo_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            lblLstMaterial frmTipoActivo = new lblLstMaterial(TipoUsuario);
            frmTipoActivo.Show();
            this.Hide();
        }

        private void FrmCatalogo_Load(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = Login.TipoUsuario;
            if (lblTipoUsuario.Text == "Revisor")
            {
                btnUsuario.Enabled = false;
                btnTipo.Enabled = false;
            }
            if (lblTipoUsuario.Text == "Operador")
            {
                btnUsuario.Enabled = false;
                btnTipo.Enabled = false;
            }
            if (lblTipoUsuario.Text == "Administrador")
            {
                btnTipo.Enabled = true;
                btnUsuario.Enabled = true;
            }
        }
        syncronizada syc = new syncronizada();
        private void btnsync_Click(object sender, EventArgs e)
        {
            try
            {
                ClaseAzure az = new ClaseAzure();
                int elementosreactivo = syc.Reactivo().Count();
                int elementosequipo = syc.equipo().Count();
                int elementosmaterial = syc.Material().Count();
                int elementosusuairo = syc.Usuario().Count();
               for (int i = 0; i <= elementosreactivo - 1; i++)
                {
                    string[] lista = syc.Reactivo().ElementAt(i).ToString().Split('+');
                    string _reactivo = string.Format("Insert Into Reactivo(Nombre, Numero, Clasificacion, Laboratorio, Caducidad, Catalogo, Unidad, Observaciones) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')",
                      lista[0], lista[1], lista[2], lista[3], lista[4], lista[5], lista[6], lista[7]);
                    az.exe(_reactivo);
                }
                for (int i = 0; i <= elementosequipo - 1; i++)
                {
                    string[] lista = syc.equipo().ElementAt(i).ToString().Split('+');
                    string _equipo = string.Format("Insert Into Equipo(Nombre, Marca, Modelo, Estado, Laboratorio, NumITT, NumSEP, ManualOP, NumSerie, Observaciones) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}', '{8}', '{9}')",
                    lista[0], lista[1], lista[2], lista[3], lista[4], lista[5], lista[6], lista[7], lista[8], lista[9]);
                    az.exe(_equipo);

                }
                for (int i = 0; i <= elementosusuairo - 1; i++)
                {
                    string[] lista = syc.Usuario().ElementAt(i).ToString().Split('+');
                    string _usuario = string.Format("insert into Usuario (Nombre, NomUsr, Contrasena, TipoUsr) values('{0}', '{1}', '{2}', '{3}')", lista[0], lista[1], lista[2], lista[3]);
                    az.exe(_usuario);

                }
                for (int i = 0; i <= elementosmaterial - 1; i++)
                {
                    string[] lista = syc.Material().ElementAt(i).ToString().Split('+');
                    string _material = string.Format("Insert Into Material (Nombre, Tipo, Capacidad, Estado, Laboratorio, Observaciones) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}')", lista[0], lista[1], lista[2], lista[3], lista[4], lista[5]);
                    az.exe(_material);
                }
                ClaseSQLite lite = new ClaseSQLite();
                string borrarR = string.Format("delete from Reactivo");
                string borrarE = string.Format("delete from Equipo");
                string borrarU = string.Format("delete from Usuario");
                string borrarM = string.Format("delete from Material");
                lite.exe(borrarR);
                lite.exe(borrarE);
                lite.exe(borrarU);
                lite.exe(borrarM);
                MessageBox.Show("Información sincronizada con exito", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch
            {
                MessageBox.Show("Hubo un error contacte al administrador");
            }
            }

    }
}
