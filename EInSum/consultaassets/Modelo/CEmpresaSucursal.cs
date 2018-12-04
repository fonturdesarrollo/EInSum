using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CEmpresaSucursal
    {
        public CEmpresaSucursal()
        {
        }
        private int _empresaSucursalID;
        private int _empresaID;
        private string _nombreSucursal;
        private string _direccionSucursal;
        private string _telefonoSucursal;

        public CEmpresaSucursal(int _empresaSucursalID, int _empresaID, string _nombreSucursal, string _direccionSucursal, string _telefonoSucursal)
        {
            this.EmpresaSucursalID = _empresaSucursalID;
            this.EmpresaID = _empresaID;
            this.NombreSucursal = _nombreSucursal;
            this.DireccionSucursal = _direccionSucursal;
            this.TelefonoSucursal = _telefonoSucursal;
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

        public int EmpresaID
        {
            get
            {
                return _empresaID;
            }

            set
            {
                _empresaID = value;
            }
        }

        public string NombreSucursal
        {
            get
            {
                return _nombreSucursal;
            }

            set
            {
                _nombreSucursal = value;
            }
        }

        public string DireccionSucursal
        {
            get
            {
                return _direccionSucursal;
            }

            set
            {
                _direccionSucursal = value;
            }
        }

        public string TelefonoSucursal
        {
            get
            {
                return _telefonoSucursal;
            }

            set
            {
                _telefonoSucursal = value;
            }
        }
    }
}