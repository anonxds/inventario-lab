using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioLaboratorio.PatronTemplate;

namespace InventarioLaboratorio
{
    public partial class FrmUsuarios : Form
    {
        public FrmUsuarios()
        {
            InitializeComponent();
        }
        public FrmUsuarios(String texto)
        {
            InitializeComponent();
            lblNomUsuario.Text = texto;
        }

        Sql sql = new Sql();
        Limpiar limpiar = new Limpiar();
        
        private void btnVolver_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmCatalogo frmCatalogo = new FrmCatalogo(TipoUsuario);
            frmCatalogo.Show();
            this.Hide();
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            Login CerrarSesion = Login.ObtenerInstanciaLogin();
            CerrarSesion.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = string.Format("insert into Usuario (Nombre, NomUsr, Contrasena, TipoUsr) values('{0}', '{1}', '{2}', '{3}')", txtNombre.Text, txtNomUsr.Text, txtContrasena.Text, lstTipo.Text);
                sql.exe(consulta);

                MessageBox.Show("La información se a guardado correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);

                limpiar.BorrarCampos(this);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = Login.TipoUsuario;

            sql.dgrid(dgvUsuario, "select * from Usuario");
        }

        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTipo.Text == "")
            {
                lblDescripcion.Text = "";
            }
            if (lstTipo.Text == "Administrador")
            {
                lblDescripcion.Text = "El usuario tendrá acceso a todas las funciones";
            }
            if (lstTipo.Text == "Operador")
            {
                lblDescripcion.Text = "El usuario podrá dar de alta y modificar los Reactivos, Materiales y el Equipo" + "\n" + "pero no podrá acceder a Usuarios ni Administrar";
            }
            if (lstTipo.Text == "Revisor")
            {
                lblDescripcion.Text = "El usuario podrá dar de alta Reactivos, Materiales y el Equipo pero no podrá" + "\n" + "modificarlos ni acceder a Usuarios ni Administrar";
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                string consulta = string.Format("Update Usuario set Nombre='{0}', NomUsr='{1}', Contrasena='{2}', TipoUsr='{3}' where Id={4}",
                txtNombre.Text, txtNomUsr.Text, txtContrasena.Text, lstTipo.Text, txtID.Text);
                sql.exe(consulta);

                MessageBox.Show("Usuario modificado con exito", "Dato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                limpiar.BorrarCampos(this);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Borrar dato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string consulta = string.Format("Delete from Usuario where Id={0}", txtID.Text);
                    sql.exe(consulta);
                    MessageBox.Show("Usuario eliminado con exito", "Dato eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }              
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dgvUsuario_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgvUsuario.CurrentRow.Cells[0].Value.ToString();
                txtNombre.Text = dgvUsuario.CurrentRow.Cells[1].Value.ToString();
                txtNomUsr.Text = dgvUsuario.CurrentRow.Cells[2].Value.ToString();
                lstTipo.Text = dgvUsuario.CurrentRow.Cells[3].Value.ToString();
                txtContrasena.Text = dgvUsuario.CurrentRow.Cells[4].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            sql.dgrid(dgvUsuario, "select * from Usuario");
        }
    }
}
