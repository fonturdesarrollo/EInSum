using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class CBeneficiario
    {
        public CBeneficiario()
        {
        }
        private int _organizacionBeneficiarioID;
        private int _tipoBeneficiarioID;
        private double _cedulaBeneficiario;
        private string _nombreBeneficiario;
        private int _parroquiaID;
        private string _telefonoBeneficiario;
        private string _direccionBeneficiario;
        private string _emailBeneficiario;
        private int _seguridadUsuarioDatosID;
        public CBeneficiario(int _organizacionBeneficiarioID, int _tipoBeneficiarioID, double _cedulaBeneficiario, string _nombreBeneficiario, int _parroquiaID, string _telefonoBeneficiario, string _direccionBeneficiario, string _emailBeneficiario, int _seguridadUsuarioDatosID)
        {
            this.OrganizacionBeneficiarioID = _organizacionBeneficiarioID;
            this.TipoBeneficiarioID = _tipoBeneficiarioID;
            this.CedulaBeneficiario = _cedulaBeneficiario;
            this.NombreBeneficiario = _nombreBeneficiario;
            this.ParroquiaID = _parroquiaID;
            this.TelefonoBeneficiario = _telefonoBeneficiario;
            this.DireccionBeneficiario = _direccionBeneficiario;
            this.EmailBeneficiario = _emailBeneficiario;
            this.SeguridadUsuarioDatosID = _seguridadUsuarioDatosID;
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

        public int TipoBeneficiarioID
        {
            get
            {
                return _tipoBeneficiarioID;
            }

            set
            {
                _tipoBeneficiarioID = value;
            }
        }

        public double CedulaBeneficiario
        {
            get
            {
                return _cedulaBeneficiario;
            }

            set
            {
                _cedulaBeneficiario = value;
            }
        }

        public string NombreBeneficiario
        {
            get
            {
                return _nombreBeneficiario;
            }

            set
            {
                _nombreBeneficiario = value;
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

        public string TelefonoBeneficiario
        {
            get
            {
                return _telefonoBeneficiario;
            }

            set
            {
                _telefonoBeneficiario = value;
            }
        }

        public string DireccionBeneficiario
        {
            get
            {
                return _direccionBeneficiario;
            }

            set
            {
                _direccionBeneficiario = value;
            }
        }

        public string EmailBeneficiario
        {
            get
            {
                return _emailBeneficiario;
            }

            set
            {
                _emailBeneficiario = value;
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
    }
}