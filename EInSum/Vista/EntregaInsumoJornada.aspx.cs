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
    public partial class EntregaInsumoJornada : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEstado();
                CargarJornadasAbiertas();
            }
        }
        private void CargarEstado()
        {
            ddEstado.Items.Clear();
            ddEstado.Items.Add(new ListItem("--Seleccione el estado--", ""));
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
                    ddEstado.DataSource = cmd.ExecuteReader();
                    ddEstado.DataTextField = "NombreEstado";
                    ddEstado.DataValueField = "EstadoID";
                    ddEstado.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarAlmacen()
        {
            ddlAlmacen.Items.Clear();
            ddlAlmacen.Items.Add(new ListItem("--Seleccione el almacen--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";
            if(ddEstado.SelectedValue !="")
            {
                strQuery = "select * From Almacen Where IndicaPrincipal = 0 AND EstadoID = " + ddEstado.SelectedValue;

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strQuery;
                        cmd.Connection = con;
                        con.Open();
                        ddlAlmacen.DataSource = cmd.ExecuteReader();
                        ddlAlmacen.DataTextField = "NombreAlmacen";
                        ddlAlmacen.DataValueField = "AlmacenID";
                        ddlAlmacen.DataBind();
                        con.Close();
                    }
                }
            }

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInsertarEntregaInsumos();
        }
        private void ProcesoInsertarEntregaInsumos()
        {
            CEntregaInsumoJornada objetoEntregaInsumoJornada = new CEntregaInsumoJornada();
            objetoEntregaInsumoJornada.EntregaInsumoID = 0;
            objetoEntregaInsumoJornada.FechaJornada = txtFechaJornada.Text;
            objetoEntregaInsumoJornada.NombreJornada = txtDescripcionJornada.Text.ToUpper();
            objetoEntregaInsumoJornada.EstadoID = Convert.ToInt32(ddEstado.SelectedValue);
            objetoEntregaInsumoJornada.DireccionEntregaInsumo = txtDireccionJornada.Text.ToUpper();
            objetoEntregaInsumoJornada.EstatusEntregaInsumo = "Abierta";
            objetoEntregaInsumoJornada.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
            objetoEntregaInsumoJornada.AlmacenID = Convert.ToInt32(ddlAlmacen.SelectedValue);

            if (EntregaInsumoJornada.InsertarEntregaInsumoJornada(objetoEntregaInsumoJornada) > 0)
            {
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nueva jornada de entrega: " + txtDescripcionJornada.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                messageBox.ShowMessage("Registro actualizado");
                NuevoRegistro();
                CargarJornadasAbiertas();
            }
            else
            {
                messageBox.ShowMessage("No se actualizó el registro.");
            }
        }
        private void CargarJornadasAbiertas()
        {
            try
            {

                DataSet ds = EntregaInsumoJornada.ObtenerJornadas("Abierta");
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void NuevoRegistro()
        {
            txtFechaJornada.Text = string.Empty;
            txtDescripcionJornada.Text = string.Empty;
            txtDireccionJornada.Text = string.Empty;
            CargarEstado();
        }

        protected void ddEstado_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarAlmacen();
        }
    }
}