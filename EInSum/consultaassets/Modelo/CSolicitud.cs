using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CSolicitud
    {
        public CSolicitud()
        {
        }
        private int _solicitudID;
        private int _tipoSolicitudID;
        private int _tipoSolicitanteID;
        private int _solicitanteID;
        private string _nombreCargoSolicitante;
        private int _organizacionID;
        private int _tipoAtencionBrindadaID;
        private int _tipoReferenciaSolicitud;
        private int _tipoUnidadID;
        private int _tipoInsumoDetalleID;
        private int _tipoRemitidoID;
        private int _tipoFormaAtencionID;
        private string _observacionesSolicitante;
        private string _observacionesAnalista;
        private int _seguridadUsuarioDatosID;
        private int _empresaSucursalID;
        private int _solicitudEstatusID;
        private int _solicitudPadreID;
        public CSolicitud(int _solicitudID, int _tipoSolicitudID, int _tipoSolicitanteID, int _solicitanteID, string _nombreCargoSolicitante, int _organizacionID, int _tipoAtencionBrindadaID, int _tipoReferenciaSolicitud, int _tipoUnidadID, int _tipoInsumoDetalleID, int _tipoRemitidoID, int _tipoFormaAtencionID, string _observacionesSolicitante, string _observacionesAnalista, int _seguridadUsuarioDatosID, int _empresaSucursalID, int _solicitudEstatusID, int _solicitudPadreID)
        {
            this.TipoSolicitudID = _tipoSolicitudID;
            this.TipoSolicitanteID = _tipoSolicitanteID;
            this.SolicitanteID = _solicitanteID;
            this.NombreCargoSolicitante = _nombreCargoSolicitante;
            this.OrganizacionID = _organizacionID;
            this.TipoAtencionBrindadaID = _tipoAtencionBrindadaID;
            this.TipoReferenciaSolicitud = _tipoReferenciaSolicitud;
            this.TipoUnidadID = _tipoUnidadID;
            this.TipoInsumoDetalleID = _tipoInsumoDetalleID;
            this.TipoRemitidoID = _tipoRemitidoID;
            this.TipoFormaAtencionID = _tipoFormaAtencionID;
            this.ObservacionesSolicitante = _observacionesSolicitante;
            this.ObservacionesAnalista = _observacionesAnalista;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.EmpresaSucursalID = _empresaSucursalID;
            this.SolicitudEstatusID = _solicitudEstatusID;
            this.SolicitudPadreID = _solicitudPadreID;
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

        public int SolicitanteID
        {
            get
            {
                return _solicitanteID;
            }

            set
            {
                _solicitanteID = value;
            }
        }

        public string NombreCargoSolicitante
        {
            get
            {
                return _nombreCargoSolicitante;
            }

            set
            {
                _nombreCargoSolicitante = value;
            }
        }

        public int OrganizacionID
        {
            get
            {
                return _organizacionID;
            }

            set
            {
                _organizacionID = value;
            }
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

        public int TipoReferenciaSolicitud
        {
            get
            {
                return _tipoReferenciaSolicitud;
            }

            set
            {
                _tipoReferenciaSolicitud = value;
            }
        }

        public int TipoUnidadID
        {
            get
            {
                return _tipoUnidadID;
            }

            set
            {
                _tipoUnidadID = value;
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

        public int TipoFormaAtencionID
        {
            get
            {
                return _tipoFormaAtencionID;
            }

            set
            {
                _tipoFormaAtencionID = value;
            }
        }

        public string ObservacionesSolicitante
        {
            get
            {
                return _observacionesSolicitante;
            }

            set
            {
                _observacionesSolicitante = value;
            }
        }

        public string ObservacionesAnalista
        {
            get
            {
                return _observacionesAnalista;
            }

            set
            {
                _observacionesAnalista = value;
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

        public int EmpresaSucursalID
        {
            get
            {
                return _empresaSucursalID;
            }

            set
            {
                _empresaSucursalID = value;
            }
        }
        public int SolicitudEstatusID
        {
            get
            {
                return _solicitudEstatusID;
            }

            set
            {
                _solicitudEstatusID = value;
            }
        }
        public int SolicitudPadreID
        {
            get
            {
                return _solicitudPadreID;
            }

            set
            {
                _solicitudPadreID = value;
            }
        }
    }
}