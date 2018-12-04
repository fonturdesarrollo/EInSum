using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoSolicitante
    {
        public CTipoSolicitante()
        {
        }
        private int _tipoSolicitanteID;
        private string _nombreTipoSolicitante;
        public CTipoSolicitante(int _tipoSolicitanteID, string _nombreTipoSolicitante)
        {
            this.TipoSolicitanteID = _tipoSolicitanteID;
            this.NombreTipoSolicitante = _nombreTipoSolicitante;
        }

        public int TipoSolicitanteID
        {
            get
            {
                return _tipoSolicitanteID;
            }

            set
            {
                _tipoSolicitanteID = value;
            }
        }

        public string NombreTipoSolicitante
        {
            get
            {
                return _nombreTipoSolicitante;
            }

            set
            {
                _nombreTipoSolicitante = value;
            }
        }
    }
}