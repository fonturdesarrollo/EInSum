using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Cellper
{
    
public class CEmpresa
    {
        private int _empresaID;
        private string _RIFEmpresa;
        private string _nombreEmpresa;
        private string _direccionEmpresa;
        private string telefonoEmpresa;
        private string _EMailEmpresa;
        private string _webEmpresa;
        private string _twitterEmpresa;
        private string _instagramEmpresa;
        private string _facebookEmpresa;
        private string _logoEmpresa;
        private int _estatusEmpresaID;

        public CEmpresa()
        {
        }
        public CEmpresa(int _empresaID, string _RIFEmpresa, string _nombreEmpresa, string _direccionEmpresa, string telefonoEmpresa, string _EMailEmpresa, string _webEmpresa, string _twitterEmpresa, string _instagramEmpresa, string _facebookEmpresa, string _logoEmpresa, int _estatusEmpresaID)
        {
            this.EmpresaID = _empresaID;
            this.RIFEmpresa = _RIFEmpresa;
            this.NombreEmpresa = _nombreEmpresa;
            this.DireccionEmpresa = _direccionEmpresa;
            this.TelefonoEmpresa = telefonoEmpresa;
            this.EMailEmpresa = _EMailEmpresa;
            this.WebEmpresa = _webEmpresa;
            this.TwitterEmpresa = _twitterEmpresa;
            this.InstagramEmpresa = _instagramEmpresa;
            this.FacebookEmpresa = _facebookEmpresa;
            this.LogoEmpresa = _logoEmpresa;
            this._estatusEmpresaID = _estatusEmpresaID;
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

        public string RIFEmpresa
        {
            get
            {
                return _RIFEmpresa;
            }

            set
            {
                _RIFEmpresa = value;
            }
        }

        public string NombreEmpresa
        {
            get
            {
                return _nombreEmpresa;
            }

            set
            {
                _nombreEmpresa = value;
            }
        }

        public string DireccionEmpresa
        {
            get
            {
                return _direccionEmpresa;
            }

            set
            {
                _direccionEmpresa = value;
            }
        }

        public string TelefonoEmpresa
        {
            get
            {
                return telefonoEmpresa;
            }

            set
            {
                telefonoEmpresa = value;
            }
        }

        public string EMailEmpresa
        {
            get
            {
                return _EMailEmpresa;
            }

            set
            {
                _EMailEmpresa = value;
            }
        }

        public string WebEmpresa
        {
            get
            {
                return _webEmpresa;
            }

            set
            {
                _webEmpresa = value;
            }
        }

        public string TwitterEmpresa
        {
            get
            {
                return _twitterEmpresa;
            }

            set
            {
                _twitterEmpresa = value;
            }
        }

        public string InstagramEmpresa
        {
            get
            {
                return _instagramEmpresa;
            }

            set
            {
                _instagramEmpresa = value;
            }
        }

        public string FacebookEmpresa
        {
            get
            {
                return _facebookEmpresa;
            }

            set
            {
                _facebookEmpresa = value;
            }
        }

        public string LogoEmpresa
        {
            get
            {
                return _logoEmpresa;
            }

            set
            {
                _logoEmpresa = value;
            }
        }
        public int EstatusEmpresaID
        {
            get
            {
                return _estatusEmpresaID;
            }

            set
            {
                _estatusEmpresaID = value;
            }
        }

    }
}