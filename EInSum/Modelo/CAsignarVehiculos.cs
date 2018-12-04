using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CAsignarVehiculos
    {

        public CAsignarVehiculos()
        {
        }
        private int _organizacionAsignarVehiculoID;
        private int _organizacionID;
        private int _organizacionBeneficiarioID;
        private string _placa;
        private int _tipoVehiculoID;
        private string _serialCarroceria;
        private int _puestos;
        private int _añoVehiculo;
        private int _tipoPrestacionServicioVehiculoID;
        private int _seguridadUsuarioDatosID;
        private string _serialMotor;
        private int _colorID;
        private string _ruta;
        private int _modeloVehiculoID;
        private int _codigoEstado;

        public CAsignarVehiculos(int _organizacionAsignarVehiculoID, int _organizacionID, int _organizacionBeneficiarioID, string _placa, int _tipoVehiculoID, string _serialCarroceria, int _puestos, int _añoVehiculo, int _tipoPrestacionServicioVehiculoID, int _seguridadUsuarioDatosID, string _serialMotor, int _colorID, string _ruta, int _modeloVehiculoID, int _codigoEstado)
        {
            this.OrganizacionAsignarVehiculoID = _organizacionAsignarVehiculoID;
            this.OrganizacionID = _organizacionID;
            this.OrganizacionBeneficiarioID = _organizacionBeneficiarioID;
            this.Placa = _placa;
            this.TipoVehiculoID = _tipoVehiculoID;
            this.SerialCarroceria = _serialCarroceria;
            this.Puestos = _puestos;
            this.AñoVehiculo = _añoVehiculo;
            this.TipoPrestacionServicioVehiculoID = _tipoPrestacionServicioVehiculoID;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.SerialMotor = _serialMotor;
            this.ColorID = _colorID;
            this.Ruta = _ruta;
            this.ModeloVehiculoID = _modeloVehiculoID;
            this.CodigoEstado = _codigoEstado;
        }

        public int OrganizacionAsignarVehiculoID
        {
            get
            {
                return _organizacionAsignarVehiculoID;
            }

            set
            {
                _organizacionAsignarVehiculoID = value;
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

        public int OrganizacionBeneficiarioID
        {
            get
            {
                return _organizacionBeneficiarioID;
            }

            set
            {
                _organizacionBeneficiarioID = value;
            }
        }

        public string Placa
        {
            get
            {
                return _placa;
            }

            set
            {
                _placa = value;
            }
        }

        public int TipoVehiculoID
        {
            get
            {
                return _tipoVehiculoID;
            }

            set
            {
                _tipoVehiculoID = value;
            }
        }

        public string SerialCarroceria
        {
            get
            {
                return _serialCarroceria;
            }

            set
            {
                _serialCarroceria = value;
            }
        }

        public int Puestos
        {
            get
            {
                return _puestos;
            }

            set
            {
                _puestos = value;
            }
        }

        public int AñoVehiculo
        {
            get
            {
                return _añoVehiculo;
            }

            set
            {
                _añoVehiculo = value;
            }
        }

        public int TipoPrestacionServicioVehiculoID
        {
            get
            {
                return _tipoPrestacionServicioVehiculoID;
            }

            set
            {
                _tipoPrestacionServicioVehiculoID = value;
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
        public string SerialMotor
        {
            get
            {
                return _serialMotor;
            }

            set
            {
                _serialMotor = value;
            }
        }
        public int ColorID
        {
            get
            {
                return _colorID;
            }

            set
            {
                _colorID = value;
            }
        }
        public string Ruta
        {
            get
            {
                return _ruta;
            }

            set
            {
                _ruta = value;
            }
        }
        public int ModeloVehiculoID
        {
            get
            {
                return _modeloVehiculoID;
            }

            set
            {
                _modeloVehiculoID = value;
            }
        }
        public int CodigoEstado
        {
            get
            {
                return _codigoEstado;
            }

            set
            {
                _codigoEstado = value;
            }
        }
    }
}