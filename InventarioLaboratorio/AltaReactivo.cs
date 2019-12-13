using InventarioLaboratorio.Patron;
using InventarioLaboratorio.PatronTemplate;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioLaboratorio
{
    public partial class AltaReactivo : Form
    {
        //Inicio del Patron Singleton

        private static AltaReactivo _instanciaReactivo;

        public static AltaReactivo ObtenerInstanciaReactivo()
        {
            if (_instanciaReactivo == null || _instanciaReactivo.IsDisposed)
            {
                _instanciaReactivo = new AltaReactivo();
            }
            _instanciaReactivo.BringToFront();
            return _instanciaReactivo;
        }
        //Fin del Patron Singleton

        private AltaReactivo()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Hide();
            Limpiar limpiar = new Limpiar();
            limpiar.BorrarCampos(this);
        }
   

        //Agregar datos
        private void btnAgregarRc_Click(object sender, EventArgs e)
        {
            try
            {
                //Se crea objeto
                Reactivo r = new Reactivo();

                r.Nombre = txtReacNom.Text;
                r.Numero = txtReacNum.Text;
                r.Clasificacion = lstClasificacion.Text;
                r.Laboratorio = lstLaboratorio.Text;
                r.Caducidad = txtReacCad.Text;
                r.Catalogo = txtReacCat.Text;
                r.Unidad = txtReacUni.Text;
                r.Observacion = txtReacObs.Text;

                //Patron fabrica
                ReactivoFabrica fac = null;

                switch (r.Clasificacion)
                {
                    case "Medio de cultivo":
                        fac = new FCultivo(r.Nombre, r.Numero, r.Clasificacion, r.Laboratorio, r.Caducidad, r.Catalogo, r.Unidad, r.Observacion);
                        break;
                    case "Reactivo Congelador":
                        fac = new FCongelador(r.Nombre, r.Numero, r.Clasificacion, r.Laboratorio, r.Caducidad, r.Catalogo, r.Unidad, r.Observacion);

                        break;
                    case "Reactivo Refrigerador":
                        fac = new FRefrigerador(r.Nombre, r.Numero, r.Clasificacion, r.Laboratorio, r.Caducidad, r.Catalogo, r.Unidad, r.Observacion);

                        break;
                }
                Sql s = new Sql();
                ReactivoInfo rec = fac.GetReactivo();
                string query = string.Format("Insert Into Reactivo(Nombre, Numero, Clasificacion, Laboratorio, Caducidad, Catalogo, Unidad, Observaciones) values ('{0}', '{1}', '{2}', '{3}', '{4}', '{5}', '{6}', '{7}')", rec.Nombre, rec.Numero, rec.Clasificacion, rec.Laboratorio, rec.Caducidad, rec.Catalogo, rec.Unidad, rec.Observacion);
                s.exe(query);


                //Patron fabrica
                int Agr = 2;//ReactivoDB.AgregarReactivo(r);

                if (Agr > 0)
                {
                    MessageBox.Show("Datos guardados correctamente", "Dato guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Hide();

                    Limpiar limpiar = new Limpiar();
                    limpiar.BorrarCampos(this);
                }
                else
                {
                    MessageBox.Show("Error al guardar la infomación", "Dato no guardado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            catch
            {
                MessageBox.Show("Error al guardar la infomación", "Dato no guardado", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void AltaReactivo_Load(object sender, EventArgs e)
        {
       
        }
    }
}
