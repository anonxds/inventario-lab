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
    public partial class FrmReactivos : Form
    {
        public FrmReactivos()
        {
            InitializeComponent();
           
        }

        public FrmReactivos(String texto)
        {
            InitializeComponent();
            lblNomUsuario.Text = texto;
        }

        BusquedasP p = new BuscarPor();
        public Reactivo ReactivoSeleccionado { get; set; }
        public Reactivo ReactivoActual { get; set; }

        private void btnVolver_Click(object sender, EventArgs e)
        {
            String TipoUsuario = lblNomUsuario.Text;
            FrmCatalogo formCatalogo = new FrmCatalogo(TipoUsuario);
            formCatalogo.Show();
            this.Hide();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            AltaReactivo AltasReactivo = AltaReactivo.ObtenerInstanciaReactivo();
            AltasReactivo.Show();
        }

        private void dgvReactivo_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            lblIndicadorCad.Visible = true;
            lblComparacionCad.Text = dgvReactivo.CurrentRow.Cells[5].Value.ToString();

            DateTime parsedDate = DateTime.Parse(lblComparacionCad.Text);
            lblComparacionCad.Text = Convert.ToString(parsedDate);

            string elaboradoString = lblComparacionCad.Text;
            DateTime elab = DateTime.Parse(elaboradoString);
            int util = 60;
            DateTime Hoy = DateTime.Today;
            DateTime Vence = elab.AddDays(util);
            TimeSpan VidaUtil = Vence.Subtract(Hoy);
            string elaboradoVence = "";
            if (Convert.ToInt32(VidaUtil.Days) > 0)
            {
                elaboradoVence = Convert.ToString(VidaUtil.Days);
            }
            else
            {
                elaboradoVence = "Vencido " + VidaUtil.Days;
            }
            lblIndicadorCad.Text = ("El producto fue elaborado el   " + elaboradoString + "  Vence el día  " + Vence + "   Resto de vida útil  " + elaboradoVence + "  Días");
        }
        Sql s = new Sql();

        private void FrmReactivos_Load(object sender, EventArgs e)
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
            s.populate(lstLaboratorio, "Select * from ListaLaboratorio","Laboratorio");
            s.populate(lstTipo, "Select * from ListaReactivo", "Reactivo");
        }

        public void filtro(string lab, string tipo)
        {
            Sql s = new Sql();
            string query = string.Format("select Id, Nombre, Numero, Clasificacion, Laboratorio, Caducidad, Catalogo, Unidad, Observaciones from Reactivo where Laboratorio = '{0}' and Clasificacion = '{1}'",lab,tipo);          
                    s.dgrid(dgvReactivo,query);
             
        }
        private void btnBuscar_Click(object sender, EventArgs e)
        {
            filtro(lstLaboratorio.Text,lstTipo.Text);
         //   filtro();
       //    dgvReactivo.DataSource = ReactivoDB.BuscarReactivo(lstLaboratorio.Text, lstTipo.Text);

            lblNombre.Visible = true;
            txtReacNom.Visible = true;
            lblNumero.Visible = true;
            txtReacNum.Visible = true;
            lblCaducidad.Visible = true;
            txtBscCad.Visible = true;
            lblCatalogo.Visible = true;
            txtReacCat.Visible = true;
            lblUnidad.Visible = true;
            txtReacUni.Visible = true;
            lblObservacion.Visible = true;
            txtReacObs.Visible = true;
            btnExportar.Enabled = true;
            btnExportarPDF.Enabled = true;
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {

            ModificarReactivo ModRea = new ModificarReactivo();
            if (dgvReactivo.SelectedRows.Count > 0)
            {
                ModRea.txtReacID.Text = dgvReactivo.CurrentRow.Cells[0].Value.ToString();
                ModRea.txtReacNom.Text = dgvReactivo.CurrentRow.Cells[1].Value.ToString();
                ModRea.txtReacNum.Text = dgvReactivo.CurrentRow.Cells[2].Value.ToString();
                ModRea.lstClasificacion.Text = dgvReactivo.CurrentRow.Cells[3].Value.ToString();
                ModRea.lstLaboratorio.Text = dgvReactivo.CurrentRow.Cells[4].Value.ToString();
                ModRea.txtReacCad.Text = dgvReactivo.CurrentRow.Cells[5].Value.ToString();
                ModRea.txtReacCat.Text = dgvReactivo.CurrentRow.Cells[6].Value.ToString();
                ModRea.txtReacUni.Text = dgvReactivo.CurrentRow.Cells[7].Value.ToString();
                ModRea.txtReacObs.Text = dgvReactivo.CurrentRow.Cells[8].Value.ToString();

                ModRea.ShowDialog();
            }
            else
            {
                MessageBox.Show("Asegúrese de seleccionar una fila", "Dato no seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void lblCerrarSesion_Click(object sender, EventArgs e)
        {
            Login CerrarSesion = Login.ObtenerInstanciaLogin();
            CerrarSesion.Show();
            this.Hide();
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            Exportar exportarExcel = new Exportar();
            exportarExcel.ExportarDataGridViewExcel(dgvReactivo);
        }
        
        private void txtReacNom_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Nombre", txtReacNom);
        }

        private void txtReacNum_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Numero", txtReacNum);
        }

        private void txtBscCad_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Caducidad", txtBscCad);
        }

        private void txtReacCat_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Catalogo", txtReacCat);
        }

        private void txtReacUni_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Unidad", txtReacUni);
        }

        private void txtReacObs_TextChanged(object sender, EventArgs e)
        {
            p.Buscar(dgvReactivo, "Observaciones", txtReacObs);
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            ExportarPDF exportarPDF = new ExportarPDF();
            exportarPDF.exportarDataGVaPDF(dgvReactivo, "InventarioReactivos");
        }

        private void lblIndicadorCad_Click(object sender, EventArgs e)
        {
        }
    }
}
