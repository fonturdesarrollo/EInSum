using System;
using System.Collections;
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
    public partial class InventarioEntrada : Seguridad.SeguridadAuditoria
    {
        protected new void  Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarAlmacen();
            }
        }
        private void CargarTipoInsumo()
        {
            ddlTipoInsumo.Items.Clear();
            ddlTipoInsumo.Items.Add(new ListItem("--Seleccione el tipo de insumo--", ""));
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
                    ddlTipoInsumo.DataSource = cmd.ExecuteReader();
                    ddlTipoInsumo.DataTextField = "NombreTipoInsumo";
                    ddlTipoInsumo.DataValueField = "TipoInsumoID";
                    ddlTipoInsumo.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoInsumoDetalle()
        {
            ddlTipoInsumoDetalle.Items.Clear();
            ddlTipoInsumoDetalle.Items.Add(new ListItem("--Seleccione el detalle del tipo de insumo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if(ddlTipoInsumo.SelectedValue != "")
            {
                strQuery = "select * From TipoInsumoDetalle Where TipoInsumoID = " + ddlTipoInsumo.SelectedValue + " Order By NombreTipoInsumoDetalle";

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strQuery;
                        cmd.Connection = con;
                        con.Open();
                        ddlTipoInsumoDetalle.DataSource = cmd.ExecuteReader();
                        ddlTipoInsumoDetalle.DataTextField = "NombreTipoInsumoDetalle";
                        ddlTipoInsumoDetalle.DataValueField = "TipoInsumoDetalleID";
                        ddlTipoInsumoDetalle.DataBind();
                        con.Close();
                    }
                }
            }

        }

        private void CargarAlmacen()
        {
            ddAlmacen.Items.Clear();
            ddAlmacen.Items.Add(new ListItem("--Seleccione el almacen--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Almacen Where IndicaPrincipal = 1" ;

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddAlmacen.DataSource = cmd.ExecuteReader();
                    ddAlmacen.DataTextField = "NombreAlmacen";
                    ddAlmacen.DataValueField = "AlmacenID";
                    ddAlmacen.DataBind();
                    con.Close();
                }
            }
        }

        protected void ddAlmacen_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInventarioAlmacen();
            CargarTipoInsumo();
        }

        private void CargarInventarioAlmacen()
        {
            try
            {
                int tipoInsumoID = 0;
                int tipoInsumoDetalleID = 0;

                if (ddlTipoInsumo.SelectedValue != "" && ddlTipoInsumo.SelectedValue !="0")
                {
                    tipoInsumoID = Convert.ToInt32(ddlTipoInsumo.SelectedValue);
                }

                if (ddlTipoInsumoDetalle.SelectedValue !="" && ddlTipoInsumoDetalle.SelectedValue != "0")
                {
                    tipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
                }
                DataSet ds = InventarioEntrada.ObtenerInventarioEntrada(Convert.ToInt32(ddAlmacen.SelectedValue), tipoInsumoID,tipoInsumoDetalleID);
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void CargarUnidadMedida()
        {
            ddlUnidadMedida.Items.Clear();
            ddlUnidadMedida.Items.Add(new ListItem("--Seleccione la unidad de medida--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From UnidadMedida";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlUnidadMedida.DataSource = cmd.ExecuteReader();
                    ddlUnidadMedida.DataTextField = "NombreUnidadMedida";
                    ddlUnidadMedida.DataValueField = "UnidadMedidaID";
                    ddlUnidadMedida.DataBind();
                    con.Close();
                }
            }
        }
        protected void ddlTipoInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipoInsumoDetalle();
            CargarInventarioAlmacen();
        }

        protected void ddlTipoInsumoDetalle_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarUnidadMedida();
            CargarInventarioAlmacen();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInventarioEntrada();
        }

        private void ProcesoInventarioEntrada()
        {
            CInventarioEntrada objetoInventarioEntrada = new CInventarioEntrada();
            objetoInventarioEntrada.InventarioEntradaID = 0;
            objetoInventarioEntrada.TipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
            objetoInventarioEntrada.UnidadMedidaID =  Convert.ToInt32(ddlUnidadMedida.SelectedValue);
            objetoInventarioEntrada.CantidadIngreso = Convert.ToInt32(txtCantidad.Text);
            objetoInventarioEntrada.CantidadEgreso = 0;
            objetoInventarioEntrada.AlmacenID = Convert.ToInt32(ddAlmacen.SelectedValue);
            objetoInventarioEntrada.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
            objetoInventarioEntrada.NumeroOrdenObservacion = txtNumeroOrden.Text.ToUpper();
            if (InventarioEntrada.InsertarInventarioEntrada(objetoInventarioEntrada) > 0)
            {
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó insumo: " + ddlTipoInsumoDetalle.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                messageBox.ShowMessage("Registro actualizado");
                CargarInventarioAlmacen();
            }
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            txtCantidad.Text = string.Empty;
            CargarAlmacen();
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();
            ddlUnidadMedida.Items.Clear();
            ddlUnidadMedida.Items.Add(new ListItem("--Seleccione la unidad de medida--", ""));
            ddlTipoInsumoDetalle.Items.Clear();
            ddlTipoInsumoDetalle.Items.Add(new ListItem("--Seleccione el detalle del tipo de insumo--", ""));
            ddlTipoInsumo.Items.Clear();
            ddlTipoInsumo.Items.Add(new ListItem("--Seleccione el tipo de insumo--", ""));
        }
    }
}