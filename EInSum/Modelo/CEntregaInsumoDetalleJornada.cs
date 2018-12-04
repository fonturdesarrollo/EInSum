using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CEntregaInsumoDetalleJornada
    {
        public CEntregaInsumoDetalleJornada()
        {

        }

        public CEntregaInsumoDetalleJornada(int entregaInsumoDetalleID, int entregaInsumoID, string placa, int tipoInsumoDetalleID, int unidadMedidaID, int cantidadEntregaInsumo, int seguridadUsuarioDatosID)
        {
            EntregaInsumoDetalleID = entregaInsumoDetalleID;
            EntregaInsumoID = entregaInsumoID;
            Placa = placa;
            TipoInsumoDetalleID = tipoInsumoDetalleID;
            UnidadMedidaID = unidadMedidaID;
            CantidadEntregaInsumo = cantidadEntregaInsumo;
            SeguridadUsuarioDatosID = seguridadUsuarioDatosID;
        }

        public int EntregaInsumoDetalleID { get; set; }
        public int EntregaInsumoID { get; set; }
        public string Placa { get; set; }
        public int TipoInsumoDetalleID { get; set; }
        public int UnidadMedidaID { get; set; }
        public int CantidadEntregaInsumo { get; set; }
        public int SeguridadUsuarioDatosID { get; set; }

    }

}