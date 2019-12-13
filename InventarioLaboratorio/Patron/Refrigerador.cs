using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventarioLaboratorio.Patron
{
    class Refrigerador : ReactivoInfo
    {
        
        public String _Nombre;
        public String _Numero;
        public String _Clasificacion;
        public String _Laboratorio;
        public String _Caducidad;
        public String _Catalogo;
        public String _Unidad;
        public String _Observacion;

        public Refrigerador( string Nombre, string Numero, string Clasificacion, string Laboratorio, string Caducidad, string Catalogo, string Unidad, string Observacion)
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
    class FRefrigerador : ReactivoFabrica
    {
      
        public String Nombre;
        public String Numero;
        public String Clasificacion;
        public String Laboratorio;
        public String Caducidad;
        public String Catalogo;
        public String Unidad;
        public String Observacion;

        public FRefrigerador( string nombre, string numero, string clasificacion, string laboratorio, string caducidad, string catalogo, string unidad, string observacion)
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
            return new Refrigerador(Nombre, Numero, Clasificacion, Laboratorio, Caducidad, Catalogo, Unidad, Observacion);
        }
    }
}
