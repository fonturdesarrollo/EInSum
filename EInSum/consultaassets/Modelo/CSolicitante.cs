using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class CSolicitante
    {
        public CSolicitante()
        {
        }
        private int _solicitanteID;
        private string _cedulaSolicitante;
        private string _nombresolicitante;
        private string _apellidoSolicitante;
        private string _sexo;
        private string _celularSolicitante;
        private string _telefonoLocalSolicitante;
        private string _telefonoOficinalSolicitante;
        private string _correoElectronicoSolicitante;
        private int _parroquiaID;
        private int _indicaCarnetPatria;
        private string _serialCarnetPatria;
        private string _codigoCarnetPatria;
        private string _fechaRegistroSolicitante;
        private int _seguridadUsuarioDatosID;
        private int _empresaSucursalID;
        public CSolicitante(int _solicitanteID, string _cedulaSolicitante ,string _nombresolicitante, string _apellidoSolicitante, string _sexo, string _celularSolicitante, string _telefonoLocalSolicitante, string _telefonoOficinalSolicitante, string _correoElectronicoSolicitante, int _parroquiaID,  int _indicaCarnetPatria, string _serialCarnetPatria, string _codigoCarnetPatria, string _fechaRegistroSolicitante, int _seguridadUsuarioDatosID, int _empresaSucursalID)
        {
            this.SolicitanteID = _solicitanteID;
            this.CedulaSolicitante = _cedulaSolicitante;
            this.Nombresolicitante = _nombresolicitante;
            this.ApellidoSolicitante = _apellidoSolicitante;
            this.Sexo = _sexo;
            this.CelularSolicitante = _celularSolicitante;
            this.TelefonoLocalSolicitante = _telefonoLocalSolicitante;
            this.TelefonoOficinalSolicitante = _telefonoOficinalSolicitante;
            this.CorreoElectronicoSolicitante = _correoElectronicoSolicitante;
            this.ParroquiaID = _parroquiaID;
            this.IndicaCarnetPatria = _indicaCarnetPatria;
            this.SerialCarnetPatria = _serialCarnetPatria;
            this.CodigoCarnetPatria = _codigoCarnetPatria;
            this.FechaRegistroSolicitante = _fechaRegistroSolicitante;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
            this.EmpresaSucursalID = _empresaSucursalID;
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
        public string CedulaSolicitante
        {
            get
            {
                return _cedulaSolicitante;
            }

            set
            {
                _cedulaSolicitante = value;
            }
        }

        public string Nombresolicitante
        {
            get
            {
                return _nombresolicitante;
            }

            set
            {
                _nombresolicitante = value;
            }
        }

        public string ApellidoSolicitante
        {
            get
            {
                return _apellidoSolicitante;
            }

            set
            {
                _apellidoSolicitante = value;
            }
        }

        public string Sexo
        {
            get
            {
                return _sexo;
            }

            set
            {
                _sexo = value;
            }
        }

        public string CelularSolicitante
        {
            get
            {
                return _celularSolicitante;
            }

            set
            {
                _celularSolicitante = value;
            }
        }

        public string TelefonoLocalSolicitante
        {
            get
            {
                return _telefonoLocalSolicitante;
            }

            set
            {
                _telefonoLocalSolicitante = value;
            }
        }

        public string TelefonoOficinalSolicitante
        {
            get
            {
                return _telefonoOficinalSolicitante;
            }

            set
            {
                _telefonoOficinalSolicitante = value;
            }
        }

        public string CorreoElectronicoSolicitante
        {
            get
            {
                return _correoElectronicoSolicitante;
            }

            set
            {
                _correoElectronicoSolicitante = value;
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

        public int IndicaCarnetPatria
        {
            get
            {
                return _indicaCarnetPatria;
            }

            set
            {
                _indicaCarnetPatria = value;
            }
        }

        public string SerialCarnetPatria
        {
            get
            {
                return _serialCarnetPatria;
            }

            set
            {
                _serialCarnetPatria = value;
            }
        }

        public string CodigoCarnetPatria
        {
            get
            {
                return _codigoCarnetPatria;
            }

            set
            {
                _codigoCarnetPatria = value;
            }
        }

        public string FechaRegistroSolicitante
        {
            get
            {
                return _fechaRegistroSolicitante;
            }

            set
            {
                _fechaRegistroSolicitante = value;
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
    }

}