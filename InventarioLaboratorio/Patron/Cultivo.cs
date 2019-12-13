using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio.Patron
{
    class Cultivo : ReactivoInfo
    {
       
        private string _Nombre;
        private string _Numero;
        private string _Clasificacion;
        private string _Laboratorio;
        private string _Caducidad;
        private string _Catalogo;
        private string _Unidad;
        private string _Observacion;

        public Cultivo(string Nombre, string Numero, string Clasificacion, string Laboratorio, string Caducidad, string Catalogo, string Unidad, string Observacion)
        {
            
            _Nombre = Nombre;
            _Numero = Numero;
            _Clasificacion = Clasificacion;
            _Laboratorio = Laboratorio;
            _Caducidad = Caducidad;
            _Catalogo = Catalogo;
            _Unidad = Unidad;
            _Observacion = Observacion;
        }

       
        public override string Nombre { get => _Nombre; set => _Nombre = value; }
        public override string Numero { get => _Numero; set => _Numero = value; }
        public override string Clasificacion { get => _Clasificacion; set => _Clasificacion = value; }
        public override string Laboratorio { get => _Laboratorio; set => _Laboratorio = value; }
        public override string Caducidad { get => _Caducidad; set => _Caducidad = value; }
        public override string Catalogo { get => _Catalogo; set => _Catalogo = value; }
        public override string Unidad { get => _Unidad; set => _Unidad = value; }
        public override string Observacion { get => _Observacion; set => _Observacion = value; }
    }
}
