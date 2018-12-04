using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoSolicitud
    {
       public CTipoSolicitud()
        {
        }
        private int _tipoSolicitudID;
        private string _nombreTipoSolicitud;
        private string _descripcionTipoSolicitud;
        public CTipoSolicitud(int _tipoSolicitudID, string _nombreTipoSolicitud, string _descripcionTipoSolicitud)
        {
            this.TipoSolicitudID = _tipoSolicitudID;
            this.NombreTipoSolicitud = _nombreTipoSolicitud;
            this.DescripcionTipoSolicitud = _descripcionTipoSolicitud;
        }

        public int TipoSolicitudID
        {
            get
            {
                return _tipoSolicitudID;
            }

            set
            {
                _tipoSolicitudID = value;
            }
        }

        public string NombreTipoSolicitud
        {
            get
            {
                return _nombreTipoSolicitud;
            }

            set
            {
                _nombreTipoSolicitud = value;
            }
        }
        public string DescripcionTipoSolicitud
        {
            get
            {
                return _descripcionTipoSolicitud;
            }

            set
            {
                _descripcionTipoSolicitud = value;
            }
        }
    }
}