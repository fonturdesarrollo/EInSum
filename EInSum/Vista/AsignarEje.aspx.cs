using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eisum
{
    public partial class AsignarEje : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEstado();
                CargarBloque();
            }
        }
        private void CargarEstado()
        {
            ddlEstado.Items.Clear();
            ddlEstado.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el estado--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Estado ORDER BY NombreEstado";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstado.DataSource = cmd.ExecuteReader();
                    ddlEstado.DataTextField = "NombreEstado";
                    ddlEstado.DataValueField = "EstadoID";
                    ddlEstado.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarBloque()
        {
            ddlBloque.Items.Clear();
            ddlBloque.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el bloque--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "Select * From Bloque order by BloqueID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlBloque.DataSource = cmd.ExecuteReader();
                ddlBloque.DataTextField = "NombreBloque";
                ddlBloque.DataValueField = "BloqueID";
                ddlBloque.DataBind();
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
        private void CargarDetalleOrganizacion()
        {
            try
            {
                gridDetalle.Visible = true;
                DataSet ds = Organizacion.ObtenerDatosOrganizacionPorEstadoBloque(Convert.ToInt32(ddlEstado.SelectedValue) , Convert.ToInt32(ddlBloque.SelectedValue));
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void ddlBloque_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlEstado.SelectedValue !="")
            {
                CargarDetalleOrganizacion();
            }
            else
            {
                messageBox.ShowMessage("Debe seleccionar el estado");
            }
        }
        private void ActualizarLista()
        {
            try
            {
                int contadorRegistros = 0;
                List<COrganizacion> objetoLista = new List<COrganizacion>();
                string sResultado = ValidarDatos(ref objetoLista);
                foreach (COrganizacion prod in objetoLista)
                {
                    contadorRegistros = contadorRegistros + 1;
                    Organizacion.ActualizarEjeOrganizacion(prod);

                }
                if (contadorRegistros > 0)
                {
                    messageBox.ShowMessage("Lista actualizada.");
                }
                else
                {
                    messageBox.ShowMessage("No existen registros por actualizar");
                }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private string ValidarDatos(ref List<COrganizacion> objetoAsignarEstatus)
        {
            try
            {
                string sResultado = "";
                COrganizacion objetoAsignaEstatus = null;
                int j = 1;
                foreach (GridViewRow dr in this.gridDetalle.Rows)
                {
                    objetoAsignaEstatus = new COrganizacion();
                    objetoAsignaEstatus.OrganizacionID = Utils.utils.ToInt(((Label)dr.FindControl("lblCodigoOrganizacion")).Text);
                    objetoAsignaEstatus.EjeID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlEje")).SelectedValue);
                    sResultado = "Estatus <br>";
                    objetoAsignarEstatus.Add(objetoAsignaEstatus);
                    j++;
                }

                return sResultado;
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
                return "";
            }
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "GuardarCambiosGrid")
                {
                    ActualizarLista();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}