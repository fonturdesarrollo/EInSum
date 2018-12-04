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
    public partial class InventarioAsignacion : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarAlmacen();
            }
        }
        private void CargarAlmacen()
        {
            ddAlmacenSecundario.Items.Clear();
            ddAlmacenSecundario.Items.Add(new ListItem("--Seleccione el almacen--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Almacen Where IndicaPrincipal = 0";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddAlmacenSecundario.DataSource = cmd.ExecuteReader();
                    ddAlmacenSecundario.DataTextField = "NombreAlmacen";
                    ddAlmacenSecundario.DataValueField = "AlmacenID";
                    ddAlmacenSecundario.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarInventarioAlmacen()
        {
            try
            {
                int tipoInsumoID = 0;
                int tipoInsumoDetalleID = 0;

                if (ddlTipoInsumo.SelectedValue != "" && ddlTipoInsumo.SelectedValue != "0")
                {
                    tipoInsumoID = Convert.ToInt32(ddlTipoInsumo.SelectedValue);
                }

                if (ddlTipoInsumoDetalle.SelectedValue != "" && ddlTipoInsumoDetalle.SelectedValue != "0")
                {
                    tipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
                }
                DataSet ds = InventarioAsignacion.ObtenerInventarioAsignacion(Convert.ToInt32(ddAlmacenSecundario.SelectedValue), tipoInsumoID, tipoInsumoDetalleID);
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
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

            if (ddlTipoInsumo.SelectedValue != "")
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

        protected void ddAlmacenSecundario_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarInventarioAlmacen();
            CargarTipoInsumo();
        }
        private void ProcesoInventarioAsignacion()
        {
            try
            {
                if(EsTodoCorrecto())
                {
                    CInventarioAsignacion objetoInventarioAsignacion = new CInventarioAsignacion();
                    objetoInventarioAsignacion.InventarioAsignacionID = 0;
                    objetoInventarioAsignacion.TipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
                    objetoInventarioAsignacion.UnidadMedidaID = Convert.ToInt32(ddlUnidadMedida.SelectedValue);
                    objetoInventarioAsignacion.CantidadIngresoAsignacion = Convert.ToInt32(txtCantidad.Text);
                    objetoInventarioAsignacion.CantidadEngresoAsignacion = 0;
                    objetoInventarioAsignacion.AlmacenID = Convert.ToInt32(ddAlmacenSecundario.SelectedValue);
                    objetoInventarioAsignacion.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    objetoInventarioAsignacion.NumeroOrdenObservacion = txtNumeroOrden.Text.ToUpper();
                    if (InventarioAsignacion.InsertarInventarioAsignacion(objetoInventarioAsignacion) > 0)
                    {
                        //Realiza el egreso de la tabla InventarioEntrada
                        //*********************************************************************************
                        CInventarioEntrada objetoInventarioEntrada = new CInventarioEntrada();
                        objetoInventarioEntrada.InventarioEntradaID = 0;
                        objetoInventarioEntrada.TipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
                        objetoInventarioEntrada.UnidadMedidaID = Convert.ToInt32(ddlUnidadMedida.SelectedValue);
                        objetoInventarioEntrada.CantidadIngreso = 0;
                        objetoInventarioEntrada.CantidadEgreso = Convert.ToInt32(txtCantidad.Text);
                        objetoInventarioEntrada.AlmacenID = 1;
                        objetoInventarioEntrada.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                        objetoInventarioEntrada.NumeroOrdenObservacion = txtNumeroOrden.Text.ToUpper();
                        InventarioEntrada.InsertarInventarioEntrada(objetoInventarioEntrada);
                        //*********************************************************************************

                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó insumo a estado: " + ddlTipoInsumoDetalle.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Registro actualizado");
                        CargarInventarioAlmacen();
                    }
                  }
                }
            catch (Exception)
            {
                throw;
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoInventarioAsignacion();
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            int totalItems = 0;  
            SqlDataReader dr;
            dr = InventarioAsignacion.ObtenerInsumoAlmacenPrincipal(Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue));
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    totalItems += Convert.ToInt32(dr["TotalDisponible"]);
                }
                if(Convert.ToInt32(txtCantidad.Text) > totalItems)
                {
                    resultado = false;
                    messageBox.ShowMessage("La cantidad a asignar supera la cantidad en el inventario para este item en el almacén principal");
                }
            }
            else
            {
                resultado = false;
                messageBox.ShowMessage("No existe inventario para este item en el almacén principal");
            }
            return resultado;
        }
    }
}