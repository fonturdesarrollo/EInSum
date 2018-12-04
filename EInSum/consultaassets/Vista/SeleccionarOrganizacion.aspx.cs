using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeleccionarOrganizacion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                LimpiarVariablesSession();
                CargarDatosSolicitante();
            }
        }
        private void CargarDatosSolicitante()
        {
            if(Session["SolicitanteID"] != null && Session["SolicitanteID"].ToString() !="")
            {
                SqlDataReader dr = Solicitante.ObtenerDatosSolicitante(Convert.ToInt32(Session["SolicitanteID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblTitulo.Text = "Seleccionar organización [ Solicitante: " + dr["CedulaSolicitante"].ToString() + " " + dr["NombreSolicitante"].ToString() + " " + dr["ApellidoSolicitante"].ToString() + "]";
                        lblTitulo2.Text = "Tipo de solicitud: [" + Session["NombreTipoSolicitud"] + "]";
                    }
                }
                dr.Close();
            }
            else
            {
                Response.Redirect("SeleccionarTipoSolicitud.aspx");
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguientePaso();
        }
        private void SiguientePaso()
        {
            if (EsOrganizacionValida())
            {
                Response.Redirect("Organizacion.aspx");
            }
            else
            {
                messageBox.ShowMessage("Debe colocar el RIF de una organización válida");
            }
        }
        private bool EsOrganizacionValida()
        {
            int codigoOrganizacionRegistrada =0;
            bool resultado = false;

            //Verificar que el RIF este registrado en el sistema
            codigoOrganizacionRegistrada = Organizacion.CodigoOrganizacionRegistrada(txtRifOrganzacion.Text);
            if (codigoOrganizacionRegistrada > 0)
            {
                Session["OrganizacionID"] = codigoOrganizacionRegistrada;
                resultado = true;
            }
            else
            {
                Session.Remove("OrganizacionID");
                Session["OrganizacionID"] = "0";
                Session["RifOrganizacion"] = txtRifOrganzacion.Text.ToUpper();
                resultado = true;
            }
            return resultado;
        }
        private void LimpiarVariablesSession()
        {
            Session.Remove("OrganizacionID");
            Session.Remove("RifOrganizacion");
        }
    }
}