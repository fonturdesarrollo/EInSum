using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CInventarioAsignacion
    {
        public CInventarioAsignacion()
        {
        }

        public CInventarioAsignacion(int inventarioAsignacionID, int tipoInsumoDetalleID, int almacenID, int cantidadIngresoAsignacion, int cantidadEngresoAsignacion, int unidadMedidaID, int seguridadUsuarioDatosID, string numeroOrdenObservacion)
        {
            InventarioAsignacionID = inventarioAsignacionID;
            TipoInsumoDetalleID = tipoInsumoDetalleID;
            AlmacenID = almacenID;
            CantidadIngresoAsignacion = cantidadIngresoAsignacion;
            CantidadEngresoAsignacion = cantidadEngresoAsignacion;
            UnidadMedidaID = unidadMedidaID;
            SeguridadUsuarioDatosID = seguridadUsuarioDatosID;
            NumeroOrdenObservacion = numeroOrdenObservacion;
        }

        public int InventarioAsignacionID { get; set; }
        public int TipoInsumoDetalleID { get; set; }
        public int AlmacenID { get; set; }
        public int CantidadIngresoAsignacion { get; set; }
        public int CantidadEngresoAsignacion { get; set; }
        public int UnidadMedidaID { get; set; }
        public int SeguridadUsuarioDatosID { get; set; }
        public string NumeroOrdenObservacion { get; set; }

    }
}