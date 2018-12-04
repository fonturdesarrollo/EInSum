using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class COrganizacion
    {
        public COrganizacion()
        {
        }
        private int _organizacionID;
        private int _tipoOrganizacionID;
        private string _rifOrganizacion;
        private string _nombreOrganizacion;
        private int _parroquiaID;
        private string _telefonoLocalOrganizacion;
        private string _telefonoCelularOrganizacion;
        private string _emailOrganizacion;
        private string _direccionOrganizacion;
        private int _cedulaPresidente;
        private string _nombrePresidente;
        private int _seguridadUsuarioDatosID;
        private int _bloqueID;
        private int _ejeID;

        public COrganizacion(int _organizacionID, int _tipoOrganizacionID, string _rifOrganizacion, string _nombreOrganizacion, int _parroquiaID, string _telefonoLocalOrganizacion, string _telefonoCelularOrganizacion, string _emailOrganizacion, string _direccionOrganizacion, int _cedulaPresidente, string _nombrePresidente, int _seguridadUsuarioDatosID, int _bloqueID, int _ejeID)
        {
            this.OrganizacionID = _organizacionID;
            this.TipoOrganizacionID = _tipoOrganizacionID;
            this.RifOrganizacion = _rifOrganizacion;
            this.NombreOrganizacion = _nombreOrganizacion;
            this.ParroquiaID = _parroquiaID;
            this.TelefonoLocalOrganizacion = _telefonoLocalOrganizacion;
            this.TelefonoCelularOrganizacion = _telefonoCelularOrganizacion;
            this.EmailOrganizacion = _emailOrganizacion;
            this.DireccionOrganizacion = _direccionOrganizacion;
            this.CedulaPresidente = _cedulaPresidente;
            this.NombrePresidente = _nombrePresidente;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.BloqueID = _bloqueID;
            this.EjeID = _ejeID;
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

        public string RifOrganizacion
        {
            get
            {
                return _rifOrganizacion;
            }

            set
            {
                _rifOrganizacion = value;
            }
        }

        public string NombreOrganizacion
        {
            get
            {
                return _nombreOrganizacion;
            }

            set
            {
                _nombreOrganizacion = value;
            }
        }

        public int ParroquiaID
        {
            get
            {
                return _parroquiaID;
            }

            set
            {
                _parroquiaID = value;
            }
        }

        public string TelefonoLocalOrganizacion
        {
            get
            {
                return _telefonoLocalOrganizacion;
            }

            set
            {
                _telefonoLocalOrganizacion = value;
            }
        }

        public string TelefonoCelularOrganizacion
        {
            get
            {
                return _telefonoCelularOrganizacion;
            }

            set
            {
                _telefonoCelularOrganizacion = value;
            }
        }

        public string EmailOrganizacion
        {
            get
            {
                return _emailOrganizacion;
            }

            set
            {
                _emailOrganizacion = value;
            }
        }

        public string DireccionOrganizacion
        {
            get
            {
                return _direccionOrganizacion;
            }

            set
            {
                _direccionOrganizacion = value;
            }
        }

        public int CedulaPresidente
        {
            get
            {
                return _cedulaPresidente;
            }

            set
            {
                _cedulaPresidente = value;
            }
        }

        public string NombrePresidente
        {
            get
            {
                return _nombrePresidente;
            }

            set
            {
                _nombrePresidente = value;
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
        public int BloqueID
        {
            get
            {
                return _bloqueID;
            }

            set
            {
                _bloqueID = value;
            }
        }
        public int EjeID
        {
            get
            {
                return _ejeID;
            }

            set
            {
                _ejeID = value;
            }
        }
    }
}