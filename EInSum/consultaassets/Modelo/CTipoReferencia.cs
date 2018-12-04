using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoReferencia
    {
        public CTipoReferencia()
        {
        }
        private int _tipoReferenciaSolicitudID;
        private string _nombreTipoReferenciaSolicitud;
        public CTipoReferencia(int _tipoReferenciaSolicitudID, string _nombreTipoReferenciaSolicitud)
        {
            this.TipoReferenciaSolicitudID = _tipoReferenciaSolicitudID;
            this.NombreTipoReferenciaSolicitud = _nombreTipoReferenciaSolicitud;
        }

        public int TipoReferenciaSolicitudID
        {
            get
            {
                return _tipoReferenciaSolicitudID;
            }

            set
            {
                _tipoReferenciaSolicitudID = value;
            }
        }

        public string NombreTipoReferenciaSolicitud
        {
            get
            {
                return _nombreTipoReferenciaSolicitud;
            }

            set
            {
                _nombreTipoReferenciaSolicitud = value;
            }
        }
    }
}