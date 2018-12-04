using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Atensoli
{
    public class ModuloGeneral
    {
        public static int CodigoTipoRemitenteSegunNombre(string nombreRemitente)
        {
            int codigo = 0;
            switch (nombreRemitente)
            {
                case "Cobranzas":
                    codigo = 2;
                    break;
                case "Financiamiento":
                    codigo = 3;
                    break;
                case "Movilidad":
                    codigo = 4;
                    break;
                case "Legal":
                    codigo = 5;
                    break;
                case "TecnicaAutomotriz":
                    codigo = 6;
                    break;
                case "OAC":
                    codigo = 7;
                    break;
            }
            return codigo;
        }
    }
}