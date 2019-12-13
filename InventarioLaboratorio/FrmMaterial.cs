using InventarioLaboratorio.Busquedas;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InventarioLaboratorio.PatronTemplate;

namespace InventarioLaboratorio
{
    public partial class FrmMaterial : Form
    {
        public FrmMaterial()
        {
            InitializeComponent();
            lblTipoUsuario.Text = Login.TipoUsuario;
        }

        public FrmMaterial(String texto)
        {
            InitializeComponent();
            lblNomUsuario.Text = texto;
        }
        Sql s = new Sql();
        Categorias cat = new Categorias();
        Busquedas.BusquedasP p = new Busquedas.BuscarPor();

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }

        private void lstTipo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lblTipo_Click(object sender, EventArgs e)
        {

        }

        private void lblEstado_Click(object sender, EventArgs e)
        {

        }

        private void lstEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
           
            string query = string.Format("Select Id, Nombre, Tipo, Capacidad, Estado, Laboratorio, Observaciones from Material where Tipo = '{0}' and  Laboratorio = '{1}' ", lstTipo.Text,lstLaboratorio.Text);
            s.dgrid(dgvMaterial, query);

            // dgvMaterial.DataSource = MaterialBD.BuscarMaterial(lstTipo.Text, lstLaboratorio.Text);
            lblNombre.Visible = true;
            txtNombre.Visible = true;
            lblCapacidad.Visible = true;
            txtCapadad.Visible = true;
            lblEstado.Visible = true;
            textEstado.Visible = true;
            lblObs.Visible = true;
            txtObs.Visible = true;
            btnExportar.Enabled = true;
            btnExportarPDF.Enabled = true;
        }

        private void lstLaboratorio_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmCatalogo formCatalogo = new FrmCatalogo(TipoUsuario);
            formCatalogo.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaMaterial AltasMaterial = AltaMaterial.ObtenerInstanciaMaterial();
            AltasMaterial.Show();
        }

        private void FrmMaterial_Load(object sender, EventArgs e)
        {
            lblTipoUsuario.Text = Login.TipoUsuario;
            if (lblTipoUsuario.Text == "Revisor")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = false;
            }
            if (lblTipoUsuario.Text == "Operador")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
            }
            if (lblTipoUsuario.Text == "Administrador")
            {
                btnAgregar.Enabled = true;
                btnEditar.Enabled = true;
            }
        //    s.populate(lstLaboratorio, "Select * from ListaLaboratorio", "Laboratorio");
          //  s.populate(lstTipo, "Select * from Material", "Material");

        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            Login CerrarSesion = Login.ObtenerInstanciaLogin();
            CerrarSesion.Show();
            this.Hide();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            ModificarMaterial mm = new ModificarMaterial();
            if (dgvMaterial.SelectedRows.Count > 0)
            {
                mm.txtMatId.Text = dgvMaterial.CurrentRow.Cells[0].Value.ToString();
                mm.txtMatNombre.Text = dgvMaterial.CurrentRow.Cells[1].Value.ToString();
                mm.lstTipo.Text = dgvMaterial.CurrentRow.Cells[2].Value.ToString();
                mm.txtMatCapacidad.Text = dgvMaterial.CurrentRow.Cells[3].Value.ToString();
                mm.lstMatEstado.Text = dgvMaterial.CurrentRow.Cells[4].Value.ToString();
                mm.lstLaboratorio.Text = dgvMaterial.CurrentRow.Cells[5].Value.ToString();
                mm.txtMatObs.Text = dgvMaterial.CurrentRow.Cells[6].Value.ToString();

                mm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Asegúrese de seleccionar una fila", "Dato no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar exportarExcel = new Exportar();
            exportarExcel.ExportarDataGridViewExcel(dgvMaterial);
        }

        private void txtNombre_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvMaterial, "Nombre", txtNombre);
        }

        private void txtCapadad_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvMaterial, "Capacidad", txtCapadad);
        }

        private void textEstado_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvMaterial, "Estado", textEstado);
        }

        private void txtObs_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvMaterial, "Observaciones", txtObs);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF exportarPDF = new ExportarPDF();
            exportarPDF.exportarDataGVaPDF(dgvMaterial, "InventarioMaterial");
        }
    }
}
