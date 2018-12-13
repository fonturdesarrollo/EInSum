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
    public partial class ModeloVehiculo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                gridDetalle.Visible = true;
                gridDetalle2.Visible = false;
                CargarMarcaVehiculo();
                CargarTipoVehiculo();
                CargarTipoCaucho();
                CargarTipoAceite();
                CargarTipoBateria();
                CargarGrid();
            }
        }
        private void CargarGrid()
        {
            try
            {
                int codigoMarca = 0;
                if(ddlMarcaVehiculo.SelectedValue !="")
                {
                    codigoMarca = Convert.ToInt32(ddlMarcaVehiculo.SelectedValue);
                }
                DataSet ds = ModeloVehiculo.ObtenerModelos(codigoMarca);
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
                gridDetalle2.DataSource = dt;
                gridDetalle2.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarMarcaVehiculo()
        {
            ddlMarcaVehiculo.Items.Clear();
            ddlMarcaVehiculo.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione la Marca--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM MarcaVehiculo ORDER BY NombreMarcaVehiculo";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlMarcaVehiculo.DataSource = cmd.ExecuteReader();
                    ddlMarcaVehiculo.DataTextField = "NombreMarcaVehiculo";
                    ddlMarcaVehiculo.DataValueField = "MarcaVehiculoID";
                    ddlMarcaVehiculo.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoVehiculo()
        {
            ddlTipoVehiculo.Items.Clear();
            ddlTipoVehiculo.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el tipo de vehiculo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM TipoVehiculo ORDER BY NombreTipoVehiculo";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoVehiculo.DataSource = cmd.ExecuteReader();
                    ddlTipoVehiculo.DataTextField = "NombreTipoVehiculo";
                    ddlTipoVehiculo.DataValueField = "TipoVehiculoID";
                    ddlTipoVehiculo.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoCaucho()
        {
            ddlTipoCaucho.Items.Clear();
            ddlTipoCaucho.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el tipo de cauchos--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM TipoInsumoDetalle WHERE TipoInsumoID = 1 ORDER BY NombreTipoInsumoDetalle";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoCaucho.DataSource = cmd.ExecuteReader();
                    ddlTipoCaucho.DataTextField = "NombreTipoInsumoDetalle";
                    ddlTipoCaucho.DataValueField = "TipoInsumoDetalleID";
                    ddlTipoCaucho.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoAceite()
        {
            ddlTipoAceite.Items.Clear();
            ddlTipoAceite.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el tipo de aceite--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM TipoInsumoDetalle WHERE TipoInsumoID = 3 ORDER BY NombreTipoInsumoDetalle";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoAceite.DataSource = cmd.ExecuteReader();
                    ddlTipoAceite.DataTextField = "NombreTipoInsumoDetalle";
                    ddlTipoAceite.DataValueField = "TipoInsumoDetalleID";
                    ddlTipoAceite.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoBateria()
        {
            ddlTipoBateria.Items.Clear();
            ddlTipoBateria.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el tipo de bateria--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM TipoInsumoDetalle WHERE TipoInsumoID = 2 ORDER BY NombreTipoInsumoDetalle";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoBateria.DataSource = cmd.ExecuteReader();
                    ddlTipoBateria.DataTextField = "NombreTipoInsumoDetalle";
                    ddlTipoBateria.DataValueField = "TipoInsumoDetalleID";
                    ddlTipoBateria.DataBind();
                    con.Close();
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoGuardar();
        }
        private void ProcesoGuardar()
        {
            try
            {
                CMarcaModeloVehiculo objetoMMVehiculo = new CMarcaModeloVehiculo();
                objetoMMVehiculo.ModeloVehiculoID = 0;
                objetoMMVehiculo.MarcaVehiculoID = Convert.ToInt32(ddlMarcaVehiculo.SelectedValue);
                objetoMMVehiculo.NombreModeloVehiculo = txtModelo.Text.ToUpper();
                objetoMMVehiculo.TipoVehiculoID = Convert.ToInt32(ddlTipoVehiculo.SelectedValue);
                objetoMMVehiculo.TipoCauchoID = Convert.ToInt32(ddlTipoCaucho.SelectedValue);
                objetoMMVehiculo.CantidadCauchos = Convert.ToInt32(txtCantidadCauchos.Text.Trim());
                objetoMMVehiculo.TipoAceiteID = Convert.ToInt32(ddlTipoAceite.SelectedValue);
                objetoMMVehiculo.CantidadLitros = Convert.ToInt32(txtLitros.Text.Trim());
                objetoMMVehiculo.TipoBateriaID = Convert.ToInt32(ddlTipoBateria.SelectedValue);
                objetoMMVehiculo.Capacidad = Convert.ToInt32(txtCapacidad.Text.Trim());

                if (ModeloVehiculo.InsertarModeloVehiculo(objetoMMVehiculo) > 0)
                {
                    messageBox.ShowMessage("Registro agregado");
                    CargarGrid();
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void ddlMarcaVehiculo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGrid();
            gridDetalle.Visible = false;
            gridDetalle2.Visible = true;
        }
        private void NuevoRegistro()
        {
            CargarMarcaVehiculo();
            CargarTipoVehiculo();
            CargarTipoCaucho();
            CargarTipoAceite();
            CargarTipoBateria();
            CargarGrid();
            txtCantidadCauchos.Text = string.Empty;
            txtCapacidad.Text = string.Empty;
            txtLitros.Text = string.Empty;
            txtModelo.Text = string.Empty;
            gridDetalle.Visible = true;
            gridDetalle2.Visible = false;
        }

        protected void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        private void ActualizarLista()
        {
            try
            {
                List<CMarcaModeloVehiculo> objetoLista = new List<CMarcaModeloVehiculo>();
                string sResultado = ValidarDatos(ref objetoLista);
                foreach (CMarcaModeloVehiculo prod in objetoLista)
                {
                    ModeloVehiculo.InsertarModeloVehiculo(prod);
                    messageBox.ShowMessage("Modelo actualizado");
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private string ValidarDatos(ref List<CMarcaModeloVehiculo> objetoAsignarEstatus)
        {
            try
            {
                string sResultado = "";
                CMarcaModeloVehiculo objetoAsignaEstatus = null;
                int j = 1;
                foreach (GridViewRow dr in this.gridDetalle2.Rows)
                {
                    objetoAsignaEstatus = new CMarcaModeloVehiculo();
                    objetoAsignaEstatus.ModeloVehiculoID = Utils.utils.ToInt(((Label)dr.FindControl("lblModeloID")).Text);
                    objetoAsignaEstatus.MarcaVehiculoID = Utils.utils.ToInt(((Label)dr.FindControl("lblMarcaID")).Text);
                    objetoAsignaEstatus.NombreModeloVehiculo = Utils.utils.ToString(((TextBox)dr.FindControl("txtModeloGrid")).Text);
                    objetoAsignaEstatus.TipoVehiculoID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlTipoVehiculoGrid")).Text);
                    objetoAsignaEstatus.TipoCauchoID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlTipoCauchoGrid")).Text);
                    objetoAsignaEstatus.CantidadCauchos = Utils.utils.ToInt(((TextBox)dr.FindControl("txCantidadCauchoGrid")).Text);
                    objetoAsignaEstatus.TipoAceiteID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlTipoAceiteGrid")).Text);
                    objetoAsignaEstatus.CantidadLitros = Utils.utils.ToInt(((TextBox)dr.FindControl("txLitrosGrid")).Text);
                    objetoAsignaEstatus.TipoBateriaID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlTipoBateriaGrid")).Text);
                    objetoAsignaEstatus.Capacidad = Utils.utils.ToInt(((TextBox)dr.FindControl("txtCapacidadGrid")).Text);
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
        protected void gridDetalle2_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    var result = ModeloVehiculo.EliminarModelo(Convert.ToInt32(e.CommandArgument.ToString()));
                    messageBox.ShowMessage(result);
                    CargarGrid();
                }
                else if (e.CommandName == "GuardarCambiosGrid")
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