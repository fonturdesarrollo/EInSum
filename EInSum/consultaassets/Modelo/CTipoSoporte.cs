using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoSoporte
    {
        public CTipoSoporte()
        {
        }
        private int _tipoSoporteID;
        private string _nombreTipoSoporte;
        public CTipoSoporte(int _tipoSoporteID, string _nombreTipoSoporte)
        {
            this.TipoSoporteID = _tipoSoporteID;
            this.NombreTipoSoporte = _nombreTipoSoporte;
        }

       public int TipoSoporteID
        {
            get
            {
                return _tipoSoporteID;
            }

            set
            {
                _tipoSoporteID = value;
            }
        }

        public string NombreTipoSoporte
        {
            get
            {
                return _nombreTipoSoporte;
            }

            set
            {
                _nombreTipoSoporte = value;
            }
        }
    }
}