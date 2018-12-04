using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CSeguimientoOAC
    {
        public CSeguimientoOAC()
        {

        }
        private int _solicitudSeguimientoID;
        private int _solicitudID;
        private int _tipoAccionID;
        private int _gerenciaID;
        private string _observacionSeguimiento;
        private int _seguridadUsuarioDatosID;
        private int _tipoRemitidoID;
        private int _tipoInstruccionSeguimientoID;
        public CSeguimientoOAC(int _solicitudSeguimientoID, int _solicitudID, int _tipoAccionID, int _gerenciaID, string _observacionSeguimiento, int _seguridadUsuarioDatosID, int _tipoRemitidoID, int _tipoInstruccionSeguimientoID)
        {
            this.SolicitudSeguimientoID = _solicitudSeguimientoID;
            this.SolicitudID = _solicitudID;
            this.TipoAccionID = _tipoAccionID;
            this.GerenciaID = _gerenciaID;
            this.ObservacionSeguimiento = _observacionSeguimiento;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.TipoRemitidoID = _tipoRemitidoID;
            this.TipoInstruccionSeguimientoID = _tipoInstruccionSeguimientoID;

        }


        public int SolicitudSeguimientoID
        {
            get
            {
                return _solicitudSeguimientoID;
            }

            set
            {
                _solicitudSeguimientoID = value;
            }
        }

        public int SolicitudID
        {
            get
            {
                return _solicitudID;
            }

            set
            {
                _solicitudID = value;
            }
        }

        public int TipoAccionID
        {
            get
            {
                return _tipoAccionID;
            }

            set
            {
                _tipoAccionID = value;
            }
        }

        public int GerenciaID
        {
            get
            {
                return _gerenciaID;
            }

            set
            {
                _gerenciaID = value;
            }
        }

        public string ObservacionSeguimiento
        {
            get
            {
                return _observacionSeguimiento;
            }

            set
            {
                _observacionSeguimiento = value;
            }
        }

        public int SeguridadUsuarioDatosID
        {
            get
            {
                return _seguridadUsuarioDatosID;
            }

            set
            {
                _seguridadUsuarioDatosID = value;
            }
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
        public int TipoInstruccionSeguimientoID
        {
            get
            {
                return _tipoInstruccionSeguimientoID;
            }

            set
            {
                _tipoInstruccionSeguimientoID = value;
            }
        }
    }
}