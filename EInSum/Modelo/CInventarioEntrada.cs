using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CInventarioEntrada
    {
        public CInventarioEntrada()
        {
        }

        public CInventarioEntrada(int inventarioEntradaID, int tipoInsumoDetalleID, int unidadMedidaID, int cantidadIngreso, int cantidadEgreso, int almacenID, int seguridadUsuarioDatosID, string numeroOrdenObservacion)
        {
            InventarioEntradaID = inventarioEntradaID;
            TipoInsumoDetalleID = tipoInsumoDetalleID;
            UnidadMedidaID = unidadMedidaID;
            CantidadIngreso = cantidadIngreso;
            CantidadEgreso = cantidadEgreso;
            AlmacenID = almacenID;
            SeguridadUsuarioDatosID = seguridadUsuarioDatosID;
            NumeroOrdenObservacion = numeroOrdenObservacion;
        }

        public int InventarioEntradaID { get; set; }
        public int TipoInsumoDetalleID { get; set; }
        public int UnidadMedidaID { get; set; }
        public int CantidadIngreso { get; set; }
        public int CantidadEgreso { get; set; }
        public int AlmacenID { get; set; }
        public int SeguridadUsuarioDatosID { get; set; }
        public string NumeroOrdenObservacion { get; set; }
    }
}