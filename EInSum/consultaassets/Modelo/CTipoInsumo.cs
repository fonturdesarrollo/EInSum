using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CTipoInsumo
    {
        public CTipoInsumo()
        {
        }
        private int _tipoInsumoID;
        private string _nombreTipoInsumo;
        private int _tipoInsumoDetalleID;
        private string _nombreTipoInsumoDetalle;
        public CTipoInsumo(int _tipoInsumoID, string _nombreTipoInsumo, int _tipoInsumoDetalleID, string _nombreTipoInsumoDetalle)
        {
            this.TipoInsumoID = _tipoInsumoID;
            this.NombreTipoInsumo = _nombreTipoInsumo;
            this.TipoInsumoDetalleID = _tipoInsumoDetalleID;
            this.NombreTipoInsumoDetalle = _nombreTipoInsumoDetalle;
        }

        public int TipoInsumoID
        {
            get
            {
                return _tipoInsumoID;
            }

            set
            {
                _tipoInsumoID = value;
            }
        }

        public string NombreTipoInsumo
        {
            get
            {
                return _nombreTipoInsumo;
            }

            set
            {
                _nombreTipoInsumo = value;
            }
        }

        public int TipoInsumoDetalleID
        {
            get
            {
                return _tipoInsumoDetalleID;
            }

            set
            {
                _tipoInsumoDetalleID = value;
            }
        }

        public string NombreTipoInsumoDetalle
        {
            get
            {
                return _nombreTipoInsumoDetalle;
            }

            set
            {
                _nombreTipoInsumoDetalle = value;
            }
        }
    }
}