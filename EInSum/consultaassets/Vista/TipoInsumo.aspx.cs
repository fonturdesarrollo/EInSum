using Seguridad;
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
    public partial class TipoInsumo : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarTipoInsumo();
            }
        }
        private void CargarTipoInsumo()
        {
            ddlInsumo.Items.Clear();
            ddlInsumo.Items.Add(new ListItem("--Seleccione el tipo de insumo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoInsumo ORDER BY TipoInsumoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlInsumo.DataSource = cmd.ExecuteReader();
                    ddlInsumo.DataTextField = "NombreTipoInsumo";
                    ddlInsumo.DataValueField = "TipoInsumoID";
                    ddlInsumo.DataBind();
                    con.Close();
                }
            }
        }
        private void ProcesoTipoInsumo()
        {
            int codigoTipoInsumo;
            try
            {
                if(EsTodoCorrecto("TipoInsumo"))
                {
                    CTipoInsumo objetoTipoInsumo = new CTipoInsumo();
                    objetoTipoInsumo.TipoInsumoID = Convert.ToInt32(hdnTipoInsumoID.Value);
                    objetoTipoInsumo.NombreTipoInsumo = txtNombreInsumo.Text.ToUpper().Trim();

                    codigoTipoInsumo = TipoInsumo.InsertarTipoInsumo(objetoTipoInsumo);
                    if(codigoTipoInsumo > 0)
                    {
                        CargarTipoInsumo();
                        messageBox.ShowMessage("Registro actualizado.");
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo de insumo: " + txtNombreInsumo.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message); 
            }   
        }
        private void ProcesoDetalleTipoInsumo()
        {
            int codigoDetalleTipoInsumo;
            try
            {
                if (EsTodoCorrecto("TipoInsumoDetalle"))
                {
                    CTipoInsumo objetoTipoInsumo = new CTipoInsumo();
                    objetoTipoInsumo.TipoInsumoID = Convert.ToInt32(ddlInsumo.SelectedValue);
                    objetoTipoInsumo.NombreTipoInsumoDetalle = txtNombreDetalleInsumo.Text.ToUpper().Trim();

                    codigoDetalleTipoInsumo = TipoInsumo.InsertarDetalleTipoInsumo(objetoTipoInsumo);
                    if (codigoDetalleTipoInsumo > 0)
                    {
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo tipo detalle de insumo: " + txtNombreDetalleInsumo.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        txtNombreDetalleInsumo.Text = "";
                        CargarDetalleTipoInsumo();
                        messageBox.ShowMessage("Registro actualizado.");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
        }
        private bool EsTodoCorrecto(string tipoValidacion)
        {
            bool resultado = true;
            switch (tipoValidacion)
            {
                case "TipoInsumo":
                    if(txtNombreInsumo.Text == "")
                    {
                        resultado = false;
                        messageBox.ShowMessage("Debe colocar el nombre del tipo de insumo.");
                    }
                    break;
                case "TipoInsumoDetalle":
                    if (ddlInsumo.SelectedValue == "")
                    {
                        resultado = false;
                        messageBox.ShowMessage("Debe seleccionar el tipo de insumo.");
                    }
                    else if(txtNombreDetalleInsumo.Text =="")
                    {
                        resultado = false;
                        messageBox.ShowMessage("Debe colocar el nombre del detalle tipo de insumo.");
                    }
                    break;
                default:
                    break;
            }
            return resultado;
        }
        private void CargarDetalleTipoInsumo()
        {
            try
            {
                DataSet ds = TipoInsumo.ObtenerDetalleTipoInsumo(Convert.ToInt32(ddlInsumo.SelectedValue));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void ddlInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarDetalleTipoInsumo();
        }

        protected void btnGuardarInsumo_Click(object sender, EventArgs e)
        {
            ProcesoTipoInsumo();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ProcesoDetalleTipoInsumo();
        }
    }
}