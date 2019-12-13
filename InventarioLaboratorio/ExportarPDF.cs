using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InventarioLaboratorio
{
    class ExportarPDF
    {
        public void exportarDataGVaPDF(DataGridView dgv, string nombre_archivo)
        {
            try
            {
                BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ROMAN, BaseFont.CP1250, BaseFont.EMBEDDED);
                //Caracteristicas de la letra y formato del pdf
                PdfPTable pdftabla = new PdfPTable(dgv.Columns.Count);
                pdftabla.DefaultCell.Padding = 3;
                pdftabla.WidthPercentage = 100;
                pdftabla.HorizontalAlignment = Element.ALIGN_LEFT;
                pdftabla.DefaultCell.BorderWidth = 1;

                iTextSharp.text.Font text = new iTextSharp.text.Font(bf, 10, iTextSharp.text.Font.NORMAL);
                //Agregar encabezado
                foreach (DataGridViewColumn columna in dgv.Columns)
                {
                    PdfPCell celda = new PdfPCell(new Phrase(columna.HeaderText, text));
                    celda.BackgroundColor = new iTextSharp.text.BaseColor(240, 240, 240);
                    pdftabla.AddCell(celda);
                }

                //Agregar fila de datos
                foreach (DataGridViewRow fila in dgv.Rows)
                {
                    foreach (DataGridViewCell celda in fila.Cells)
                    {
                        pdftabla.AddCell(new Phrase(celda.Value.ToString(), text));
                    }
                }

                //Guardar Archivo
                var guardarArchivo = new SaveFileDialog();
                guardarArchivo.FileName = nombre_archivo;
                guardarArchivo.DefaultExt = ".pdf";
                if (guardarArchivo.ShowDialog() == DialogResult.OK)
                {
                    using (FileStream stream = new FileStream(guardarArchivo.FileName, FileMode.Create))
                    {
                        Document pdfdoc = new Document(PageSize.A4, 10f, 10f, 10f, 0f);
                        PdfWriter.GetInstance(pdfdoc, stream);
                        pdfdoc.Open();
                        pdfdoc.Add(pdftabla);
                        pdfdoc.Close();
                        stream.Close();
                    }
                }

                MessageBox.Show("Archivo guardado correctamente", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocurrio un error " + ex, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
