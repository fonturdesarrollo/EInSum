using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoRemitido
    {
        public CTipoRemitido()
        {
        }
        private int _tipoRemitidoID;
        private string _nombreTipoRemitido;
        public CTipoRemitido(int _tipoRemitidoID, string _nombreTipoRemitido)
        {
            this.TipoRemitidoID = _tipoRemitidoID;
            this.NombreTipoRemitido = _nombreTipoRemitido;
        }

        public int TipoRemitidoID
        {
            get
            {
                return _tipoRemitidoID;
            }

            set
            {
                _tipoRemitidoID = value;
            }
        }

        public string NombreTipoRemitido
        {
            get
            {
                return _nombreTipoRemitido;
            }

            set
            {
                _nombreTipoRemitido = value;
            }
        }
    }
}