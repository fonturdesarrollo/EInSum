using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CMarcaModeloVehiculo
    {
        public CMarcaModeloVehiculo()
        {
            
        }
        public int MarcaVehiculoID { get; set; }
        public string NombreMarcaVehiculo { get; set; }
        public int ModeloVehiculoID { get; set; }
        public string NombreModeloVehiculo { get; set; }
        public int TipoVehiculoID { get; set; }
        public int TipoCauchoID { get; set; }
        public int CantidadCauchos { get; set; }
        public int TipoAceiteID { get; set; }
        public int TipoBateriaID { get; set; }
        public int CantidadLitros { get; set; }
        public int Capacidad { get; set; }
    }
}