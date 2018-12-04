using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTIpoAtencion
    {
        public CTIpoAtencion()
        {
        }
        private int _tipoAtencionBrindadaID;
        private string _nombreTipoAtencionBrindada;
        public CTIpoAtencion(int _tipoAtencionBrindadaID, string _nombreTipoAtencionBrindada)
        {
            this.TipoAtencionBrindadaID = _tipoAtencionBrindadaID;
            this.NombreTipoAtencionBrindada = _nombreTipoAtencionBrindada;
        }

        public int TipoAtencionBrindadaID
        {
            get
            {
                return _tipoAtencionBrindadaID;
            }

            set
            {
                _tipoAtencionBrindadaID = value;
            }
        }

        public string NombreTipoAtencionBrindada
        {
            get
            {
                return _nombreTipoAtencionBrindada;
            }

            set
            {
                _nombreTipoAtencionBrindada = value;
            }
        }
    }
}