using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class COrganizacion
    {
        public COrganizacion()
        {
        }
        private int _organizacionID;
        private string _rifOrganizacion;
        private string _nombreOrganizacion;
        private int _tipoOrganizacionID;
        private int _parroquiaID;
        private string _telefonoOrganizacion;
        private int _seguridadUsuarioDatosID;
        private string _fechaRegistroOrganizacion;
        private int _empresaSucursalID;
        public COrganizacion(int _organizacionID, string _rifOrganizacion, string _nombreOrganizacion, int _tipoOrganizacionID, int _parroquiaID, string _telefonoOrganizacion, int _seguridadUsuarioDatosID, string _fechaRegistroOrganizacion, int _empresaSucursalID)
        {
            this.OrganizacionID = _organizacionID;
            this.RifOrganizacion = _rifOrganizacion;
            this.NombreOrganizacion = _nombreOrganizacion;
            this.TipoOrganizacionID = _tipoOrganizacionID;
            this.TelefonoOrganizacion = _telefonoOrganizacion;
            this.ParroquiaID = _parroquiaID;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.FechaRegistroOrganizacion = _fechaRegistroOrganizacion;
            this.EmpresaSucursalID = _empresaSucursalID;
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

        public string TelefonoOrganizacion
        {
            get
            {
                return _telefonoOrganizacion;
            }

            set
            {
                _telefonoOrganizacion = value;
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

        public string FechaRegistroOrganizacion
        {
            get
            {
                return _fechaRegistroOrganizacion;
            }

            set
            {
                _fechaRegistroOrganizacion = value;
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
    }
}