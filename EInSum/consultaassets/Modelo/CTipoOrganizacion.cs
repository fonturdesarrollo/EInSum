using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoOrganizacion
    {
        public CTipoOrganizacion()
        {
        }
        private int _tipoOrganizacionID;
        private string _nombreTipoOrganizacion;
        public CTipoOrganizacion(int _tipoOrganizacionID, string _nombreTipoOrganizacion)
        {
            this.TipoOrganizacionID = _tipoOrganizacionID;
            this.NombreTipoOrganizacion = _nombreTipoOrganizacion;
        }

        public int TipoOrganizacionID
        {
            get
            {
                return _tipoOrganizacionID;
            }

            set
            {
                _tipoOrganizacionID = value;
            }
        }

        public string NombreTipoOrganizacion
        {
            get
            {
                return _nombreTipoOrganizacion;
            }

            set
            {
                _nombreTipoOrganizacion = value;
            }
        }
    }
}