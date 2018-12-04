using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    public class CCliente
    {
        private int _clienteID;
        private int _cedulaCliente;
        private string _nombreCliente;
        private string _telefonoCliente;
        private string _direccionCliente;
        private string _emailCliente;

        public CCliente(int _clienteID, int _cedulaCliente, string _nombreCliente, string _telefonoCliente, string _direccionCliente, string _emailCliente)
        {
            this._clienteID = _clienteID;
            this._cedulaCliente = _cedulaCliente;
            this._nombreCliente = _nombreCliente;
            this._telefonoCliente = _telefonoCliente;
            this._direccionCliente = _direccionCliente;
            this._emailCliente = _emailCliente;
        }
        public int ClienteID
        {
            get
            {
                return _clienteID;
            }

            set
            {
                _clienteID = value;
            }
        }

        public int CedulaCliente
        {
            get
            {
                return _cedulaCliente;
            }

            set
            {
                _cedulaCliente = value;
            }
        }

        public string NombreCliente
        {
            get
            {
                return _nombreCliente;
            }

            set
            {
                _nombreCliente = value;
            }
        }

        public string TelefonoCliente
        {
            get
            {
                return _telefonoCliente;
            }

            set
            {
                _telefonoCliente = value;
            }
        }

        public string DireccionCliente
        {
            get
            {
                return _direccionCliente;
            }

            set
            {
                _direccionCliente = value;
            }
        }

        public string EmailCliente
        {
            get
            {
                return _emailCliente;
            }

            set
            {
                _emailCliente = value;
            }
        }

        public CCliente()
        {

        }

    }
}