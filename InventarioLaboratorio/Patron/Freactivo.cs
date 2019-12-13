using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio.Patron
{
    class FCultivo : ReactivoFabrica
    {
       
        private string Nombre;
        private string Numero;
        private string Clasificacion;
        private string Laboratorio;
        private string Caducidad;
        private string Catalogo;
        private string Unidad;
        private string Observacion;

        public FCultivo( string nombre, string numero, string clasificacion, string laboratorio, string caducidad, string catalogo, string unidad, string observacion)
        {
          
            Nombre = nombre;
            Numero = numero;
            Clasificacion = clasificacion;
            Laboratorio = laboratorio;
            Caducidad = caducidad;
            Catalogo = catalogo;
            Unidad = unidad;
            Observacion = observacion;
        }

        public override ReactivoInfo GetReactivo()
        {
            return new Cultivo(Nombre,Numero,Clasificacion,Laboratorio,Caducidad,Catalogo,Unidad,Observacion);
        }
    }
}
