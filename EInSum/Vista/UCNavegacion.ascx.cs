using Seguridad.Clases;
using System;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vista
{
    public partial class UCNavegacion : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            EstablecerSeguridad();
        }
        private void EstablecerSeguridad()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(this.Session["UserId"].ToString());
            if (objetoSeguridad.EsUsuarioAdministrador() == false)
            {
                ColocarEnlacesInvisibles();
                lnkCambiarClave.Visible = true;

                //=============================================================
                //BENEFICIARIOS
                //=============================================================

                if (objetoSeguridad.EsAccesoPermitido(1052) == true)
                {
                    lnkRegistrarOrganzizaciones.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1053) == true)
                {
                    lnkRegistrarBeneficiarios.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1054) == true)
                {
                    lnkAsignarVehiculos.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1055) == true)
                {
                    lnkAsignarEje.Visible = true;
                }
                //=============================================================
                //OPERATIVO
                //=============================================================
                if (objetoSeguridad.EsAccesoPermitido(1023) == true)
                {
                    lnkJornada.Visible = true;
                }

                //=============================================================

                //=============================================================
                //INVENTARIO
                //=============================================================
                if (objetoSeguridad.EsAccesoPermitido(1023) == true)
                {
                    lnkEntradaInventario.Visible = true;
                }

                //=============================================================

                //=============================================================
                //OPCIONES ESPECIALES
                //=============================================================

                if (objetoSeguridad.EsAccesoPermitido(1056) == true)
                {
                    lnkMarca.Visible = true;
                }
                if (objetoSeguridad.EsAccesoPermitido(1057) == true)
                {
                    lnkModelo.Visible = true;
                }


            }
        }
        private void ColocarEnlacesInvisibles()
        {
            foreach (Control ctrl in Controls)
            {
                if (ctrl.GetType().Name == "HyperLink")
                {
                    HyperLink hl = (HyperLink)ctrl;
                    hl.Visible = false;
                }
            }
        }
    }
}