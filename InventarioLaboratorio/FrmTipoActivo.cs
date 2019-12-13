using MetroFramework.Forms;
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
    public partial class lblLstMaterial : Form
    { 

        public lblLstMaterial()
        {
            InitializeComponent(); 
        }
        public lblLstMaterial(String texto)
        {
            InitializeComponent();
            lblNomUsuario.Text = texto;
        }

        Sql sql = new Sql();
        Limpiar limpiar = new Limpiar();

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            if (lstTipo.Text == "Estado")
            {
                try
                {
                    string consulta = string.Format("insert into ListaEquipo(Equipo) values('{0}')", txtTipo.Text);
                    sql.exe(consulta);

                    MessageBox.Show("La información se a guardado correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lstTipo.Text == "Material")
            {
                try
                {
                    string consulta = string.Format("insert into ListaMaterial(Material) values('{0}')", txtTipo.Text);
                    sql.exe(consulta);

                    MessageBox.Show("La información se a guardado correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lstTipo.Text == "Reactivo")
            {
                try
                {
                    string consulta = string.Format("insert into ListaReactivo(Reactivo) values('{0}')", txtTipo.Text);
                    sql.exe(consulta);

                    MessageBox.Show("La información se a guardado correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else if (lstTipo.Text == "Ubicacion")
            {
                try
                {
                    string consulta = string.Format("insert into ListaLaboratorio(Laboratorio) values('{0}')", txtTipo.Text);
                    sql.exe(consulta);

                    MessageBox.Show("La información se a guardado correctamente", "Datos guardados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (lstTipo.Text == "Estado")
            {
                try
                {
                    string consulta = string.Format("Update ListaEquipo set Equipo='{0}' where Id={1}", txtTipo.Text, txtID.Text);
                    sql.exe(consulta);
                    MessageBox.Show("Dato modificado con exito", "Dato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Material")
            {
                try
                {
                    string consulta = string.Format("Update ListaMaterial set Material='{0}' where Id={1}", txtTipo.Text, txtID.Text);
                    sql.exe(consulta);
                    MessageBox.Show("Dato modificado con exito", "Dato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Reactivo")
            {
                try
                {
                    string consulta = string.Format("Update ListaReactivo set Reactivo='{0}' where Id={1}", txtTipo.Text, txtID.Text);
                    sql.exe(consulta);
                    MessageBox.Show("Dato modificado con exito", "Dato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Ubicacion")
            {
                try
                {
                    string consulta = string.Format("Update ListaLaboratorio set Laboratorio='{0}' where Id={1}", txtTipo.Text, txtID.Text);
                    sql.exe(consulta);
                    MessageBox.Show("Dato modificado con exito", "Dato modificado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    limpiar.BorrarCampos(this);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (lstTipo.Text == "Estado")
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Borrar dato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string consulta = string.Format("Delete from ListaEquipo where Id={0}", txtID.Text);
                        sql.exe(consulta);
                        MessageBox.Show("Dato eliminado con exito", "Dato eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar.BorrarCampos(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Material")
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Borrar dato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string consulta = string.Format("Delete from ListaMaterial where Id={0}", txtID.Text);
                        sql.exe(consulta);
                        MessageBox.Show("Dato eliminado con exito", "Dato eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar.BorrarCampos(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Reactivo")
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Borrar dato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string consulta = string.Format("Delete from ListaReactivo where Id={0}", txtID.Text);
                        sql.exe(consulta);
                        MessageBox.Show("Dato eliminado con exito", "Dato eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar.BorrarCampos(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else if (lstTipo.Text == "Ubicacion")
            {
                try
                {
                    if (MessageBox.Show("¿Esta seguro que desea eliminar el usuario?", "Borrar dato", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        string consulta = string.Format("Delete from ListaLaboratorio where Id={0}", txtID.Text);
                        sql.exe(consulta);
                        MessageBox.Show("Dato eliminado con exito", "Dato eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        limpiar.BorrarCampos(this);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

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

        private void lblLstMaterial_Load(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = Login.TipoUsuario;
        }

        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstTipo.Text == "Estado")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaEquipo");
            }
            else if (lstTipo.Text == "Material")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaMaterial");
            }
            else if (lstTipo.Text == "Reactivo")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaReactivo");
            }
            else if (lstTipo.Text == "Ubicacion")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaLaboratorio");
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            if (lstTipo.Text == "Estado")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaEquipo");
            }
            else if (lstTipo.Text == "Material")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaMaterial");
            }
            else if (lstTipo.Text == "Reactivo")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaReactivo");
            }
            else if (lstTipo.Text == "Ubicacion")
            {
                sql.dgrid(dgvLstTipo, "select * from ListaLaboratorio");
            }
        }

        private void dgvLstTipo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                txtID.Text = dgvLstTipo.CurrentRow.Cells[0].Value.ToString();
                txtTipo.Text = dgvLstTipo.CurrentRow.Cells[1].Value.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio el siguiente error: " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
