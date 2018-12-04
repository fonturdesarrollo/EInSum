using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CEntregaInsumoJornada
    {
        public CEntregaInsumoJornada()
        {

        }

        public CEntregaInsumoJornada(int entregaInsumoID, string fechaJornada, string nombreJornada, int estadoID, string direccionEntregaInsumo, int seguridadUsuarioDatosID, string estatusEntregaInsumo, int almacenID)
        {
            EntregaInsumoID = entregaInsumoID;
            FechaJornada = fechaJornada;
            NombreJornada = nombreJornada;
            EstadoID = estadoID;
            DireccionEntregaInsumo = direccionEntregaInsumo;
            SeguridadUsuarioDatosID = seguridadUsuarioDatosID;
            EstatusEntregaInsumo = estatusEntregaInsumo;
            AlmacenID = almacenID;
        }

        public int EntregaInsumoID { get; set; }
        public string FechaJornada { get; set; }
        public string NombreJornada { get; set; }
        public int EstadoID { get; set; }
        public string DireccionEntregaInsumo { get; set; }
        public int SeguridadUsuarioDatosID { get; set; }
        public string EstatusEntregaInsumo { get; set; }
        public int AlmacenID { get; set; }
    }
}