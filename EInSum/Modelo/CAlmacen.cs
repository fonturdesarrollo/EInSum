using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CAlmacen
    {
        public CAlmacen()
        {

        }

        public CAlmacen(int almacenID, string nombreAlmacen, int estadoID, string direccionAlmacen, int seguridadUsuarioDatosID)
        {
            AlmacenID = almacenID;
            NombreAlmacen = nombreAlmacen;
            EstadoID = estadoID;
            DireccionAlmacen = direccionAlmacen;
            SeguridadUsuarioDatosID = seguridadUsuarioDatosID;
        }

        public int AlmacenID { get; set; }
        public string NombreAlmacen { get; set; }
        public int EstadoID { get; set; }
        public string DireccionAlmacen { get; set; }
        public int SeguridadUsuarioDatosID { get; set; }
    }
}