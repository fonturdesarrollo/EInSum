using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class SeleccionarTipoSolicitante : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session.Remove("TipoSolicitanteID");
                if (EsSolicitanteRegistrado())
                {
                    CargarDatosSolicitante();
                    CargarTipoSolicitante();
                }
                else
                {
                    Response.Redirect("SeleccionarSolicitante.aspx");
                }
            }
        }
        private bool EsSolicitanteRegistrado()
        {

            if (Session["SolicitanteID"] != null && Session["SolicitanteID"].ToString() !="")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private void CargarDatosSolicitante()
        {
            if (Session["SolicitanteID"] != null && Session["SolicitanteID"].ToString() != "")
            {
                SqlDataReader dr = Solicitante.ObtenerDatosSolicitante(Convert.ToInt32(Session["SolicitanteID"]));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        lblTitulo.Text = "Tipo de solicitante [" + dr["CedulaSolicitante"].ToString() + " " + dr["NombreSolicitante"].ToString() + " " + dr["ApellidoSolicitante"].ToString() + "]";
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
        private void CargarTipoSolicitante()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from TipoSolicitante order by TipoSolicitanteID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlTipoSolicitante.DataSource = cmd.ExecuteReader();
                ddlTipoSolicitante.DataTextField = "NombreTipoSolicitante";
                ddlTipoSolicitante.DataValueField = "TipoSolicitanteID";
                ddlTipoSolicitante.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            ProcesoTipoSolicitante();
        }
        private void ProcesoTipoSolicitante()
        {
            Session["TipoSolicitanteID"] = ddlTipoSolicitante.SelectedValue;
            switch (Convert.ToInt32(ddlTipoSolicitante.SelectedValue))
            {
                case 1:
                    Session["OrganizacionID"] = "0";
                    Response.Redirect("Solicitud.aspx");
                    break;
                default:
                    Response.Redirect("SeleccionarOrganizacion.aspx");
                    break;
            }
        }

    }
}