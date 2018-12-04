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

namespace Atensoli
{
    public partial class Solicitud : Seguridad.SeguridadAuditoria
    {
        private static int codigoSolicitud = 0;
        private static DataTable dtGrid;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                if(dtGrid != null)
                {
                    dtGrid.Clear();
                }
                codigoSolicitud = 0;
                DataTable dt = new DataTable();
                dt.Columns.AddRange(new DataColumn[2] { new DataColumn("Tipo"), new DataColumn("TipoSoporteID") });
                ViewState["Soporte"] = dt;
                this.BindGrid();
                CargarPadre();
                CargarTipoAtencionBrindada();
                CargarTipoReferencia();
                CargarTipoUnidad();
                CargarTipoRemitido();
                CargarFormaAtencion();
                CargarTipoSoporte();
                CargarDatosSolicitante();
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
                        lblTitulo.Text = "Datos de la solicitud [ Solicitante: " + dr["CedulaSolicitante"].ToString() + " " + dr["NombreSolicitante"].ToString() + " " + dr["ApellidoSolicitante"].ToString() + "]";
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
        protected void BindGrid()
        {
            grdSoporte.DataSource = (DataTable)ViewState["Soporte"];
            grdSoporte.DataBind();
        }
        private bool EsSoporteFisicoAgregado()
        {
            bool resultado = false;
            if(dtGrid !=null)
            {
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    DataRow dr = dtGrid.Rows[i];
                    if (dr["TipoSoporteID"].ToString() == ddlTipoSoporte.SelectedValue)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
        private void AgregarTipoSoporteFisico()
        {

            CargarCombosAlEnviarFormulario();
            if(EsSoporteFisicoAgregado() == false)
            {
                if (ddlTipoSoporte.SelectedValue != "")
                {
                    dtGrid = (DataTable)ViewState["Soporte"];
                    dtGrid.Rows.Add(ddlTipoSoporte.SelectedItem, ddlTipoSoporte.SelectedValue);
                    ViewState["Soporte"] = dtGrid;
                    this.BindGrid();
                    grdSoporte.DataBind();
                }
                else
                {
                    messageBox.ShowMessage("Debe seleccionar de la lista un tipo de soporte");
                }
            }
            else
            {
                messageBox.ShowMessage("Ya agregó a la lista este tipo de documento [" + ddlTipoSoporte.SelectedItem +"]");
            }

        }
        //***********************************************************************************
        //PROCESO PARA COMBOS ANIDADOS:

        //COMBO ANIDADO NUMERO 1 (SE CARGA DESDE EL SERVIDOR)
        private void CargarPadre()
        {
            ddlPadre.Items.Clear();
            ddlPadre.Items.Add(new ListItem("--Seleccione el tipo de insumo--", ""));
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
                    ddlPadre.DataSource = cmd.ExecuteReader();
                    ddlPadre.DataTextField = "NombreTipoInsumo";
                    ddlPadre.DataValueField = "TipoInsumoID";
                    ddlPadre.DataBind();
                    con.Close();
                }
            }
        }
        //*********************************************************************************

        //COMBO ANIDADO NUMERO 2 (SE CARGA EN EL CLIENTE CON JSON MEDIANTE LA FUNCION CargarHijo())
        [System.Web.Services.WebMethod]
        public static ArrayList CargarHijo(int padreID)
        {
            ArrayList list = new ArrayList();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if (padreID != 0)
            {
                strQuery = "select * From TipoInsumoDetalle  WHERE TipoInsumoID   = @padreID  ORDER BY NombreTipoInsumoDetalle";
            }
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@padreID", padreID);
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["NombreTipoInsumoDetalle"].ToString(),
                       sdr["TipoInsumoDetalleID"].ToString()
                        ));
                    }
                    con.Close();
                    return list;
                }
            }
        }
        //*********************************************************************************
        //COMBOS ANIDADOS (FUNCIONES ADICIONALES)
        private void CargarCombosAlEnviarFormulario()
        {
            //ESTA FUNCION SE DEBE COLOCAR EN EL BOTON O EVENTO QUE ENVIA EL FORMULARIO
            // YA SEA PARA GUARDAR O PARA VALIDAR ALGUN CONTROL PORQUE DEBIDO A QUE EL TERCER COMBO SE CARGA EN CLIENTE SE PIERDE SU ID AL ENVIAR
            if(ddlPadre.SelectedValue !="")
            {
                string padre = Request.Form[ddlPadre.UniqueID];
                string hijo = Request.Form[ddlHijo.UniqueID];

                PopulateDropDownList(CargarHijo(int.Parse(padre)), ddlHijo);
                if(hijo != "0"  && hijo != null)
                {
                    ddlHijo.Items.FindByValue(hijo).Selected = true;
                }
                else
                {
                    ddlHijo.Items.Clear();
                }
                
            }
            else
            {
                ddlHijo.Items.Clear();
            }

        }
        private void PopulateDropDownList(ArrayList list, DropDownList ddl)
        {
            ddl.DataSource = list;
            ddl.DataTextField = "Text";
            ddl.DataValueField = "Value";
            ddl.DataBind();
        }
        //FIN DE COMBOS ANIDADOS
        //*********************************************************************************

        private void CargarTipoAtencionBrindada()
        {
            ddlTipoAtencionBrindada.Items.Clear();
            ddlTipoAtencionBrindada.Items.Add(new ListItem("--Seleccione el tipo de atención--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoAtencionBrindada ORDER BY TipoAtencionBrindadaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoAtencionBrindada.DataSource = cmd.ExecuteReader();
                    ddlTipoAtencionBrindada.DataTextField = "NombreTipoAtencionBrindada";
                    ddlTipoAtencionBrindada.DataValueField = "TipoAtencionBrindadaID";
                    ddlTipoAtencionBrindada.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoReferencia()
        {
            ddlTipoReferenciaSolicitud.Items.Clear();
            ddlTipoReferenciaSolicitud.Items.Add(new ListItem("--Seleccione el tipo de referencia--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoReferenciaSolicitud ORDER BY TipoReferenciaSolicitudID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoReferenciaSolicitud.DataSource = cmd.ExecuteReader();
                    ddlTipoReferenciaSolicitud.DataTextField = "NombreTipoReferenciaSolicitud";
                    ddlTipoReferenciaSolicitud.DataValueField = "TipoReferenciaSolicitudID";
                    ddlTipoReferenciaSolicitud.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoUnidad()
        {
            ddlTipoUnidad.Items.Clear();
            ddlTipoUnidad.Items.Add(new ListItem("--Seleccione el tipo de unidad--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoUnidad ORDER BY TipoUnidadID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoUnidad.DataSource = cmd.ExecuteReader();
                    ddlTipoUnidad.DataTextField = "NombreTipoUnidad";
                    ddlTipoUnidad.DataValueField = "TipoUnidadID";
                    ddlTipoUnidad.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoRemitido()
        {
            ddlTipoRemitido.Items.Clear();
            ddlTipoRemitido.Items.Add(new ListItem("--Seleccione a quien será remitido--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoRemitido ORDER BY TipoRemitidoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoRemitido.DataSource = cmd.ExecuteReader();
                    ddlTipoRemitido.DataTextField = "NombreTipoRemitido";
                    ddlTipoRemitido.DataValueField = "TipoRemitidoID";
                    ddlTipoRemitido.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarFormaAtencion()
        {
            ddlTipoFormaAtencion.Items.Clear();
            ddlTipoFormaAtencion.Items.Add(new ListItem("--Seleccione la forma de atención--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoFormaAtencion ORDER BY TipoFormaAtencionID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoFormaAtencion.DataSource = cmd.ExecuteReader();
                    ddlTipoFormaAtencion.DataTextField = "NombreTipoFormaAtencion";
                    ddlTipoFormaAtencion.DataValueField = "TipoFormaAtencionID";
                    ddlTipoFormaAtencion.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoSoporte()
        {
            ddlTipoSoporte.Items.Clear();
            ddlTipoSoporte.Items.Add(new ListItem("--Seleccione el tipo de soporte fisico--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoSoporte ORDER BY TipoSoporteID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoSoporte.DataSource = cmd.ExecuteReader();
                    ddlTipoSoporte.DataTextField = "NombreTipoSoporte";
                    ddlTipoSoporte.DataValueField = "TipoSoporteID";
                    ddlTipoSoporte.DataBind();
                    con.Close();
                }
            }
        }
        private void ProcesoSolicitud()
        {
            try
            {
                if (EsTodoCorrecto())
                {
                    CSolicitud objetoSolicitud = new CSolicitud();

                    objetoSolicitud.SolicitudID = codigoSolicitud;
                    objetoSolicitud.TipoSolicitudID = Convert.ToInt32(Session["TipoSolicitudID"]);
                    objetoSolicitud.TipoSolicitanteID = Convert.ToInt32(Session["TipoSolicitanteID"]);
                    objetoSolicitud.SolicitanteID = Convert.ToInt32(Session["SolicitanteID"]);
                    if (txtNombreCargoSolicitante.Text != "")
                    {
                        objetoSolicitud.NombreCargoSolicitante = txtNombreCargoSolicitante.Text.ToUpper();
                    }
                    else
                    {
                        objetoSolicitud.NombreCargoSolicitante = "N/A";
                    }
                    if (Session["OrganizacionID"].ToString() != "0"  && Session["OrganizacionID"] != null)
                    {
                        objetoSolicitud.OrganizacionID = Convert.ToInt32(Session["OrganizacionID"]);
                    }
                    else
                    {
                        objetoSolicitud.OrganizacionID = 0;
                    }
                    objetoSolicitud.TipoAtencionBrindadaID = Convert.ToInt32(ddlTipoAtencionBrindada.SelectedValue);
                    objetoSolicitud.TipoReferenciaSolicitud = Convert.ToInt32(ddlTipoReferenciaSolicitud.SelectedValue);
                    if (ddlTipoUnidad.SelectedValue != "")
                    {
                        objetoSolicitud.TipoUnidadID = Convert.ToInt32(ddlTipoUnidad.SelectedValue);
                    }
                    else
                    {
                        objetoSolicitud.TipoUnidadID = 0;
                    }

                    if (ddlHijo.SelectedValue != "0" && ddlHijo.SelectedValue != "")
                    {
                        objetoSolicitud.TipoInsumoDetalleID = Convert.ToInt32(ddlHijo.SelectedValue);
                    }
                    else
                    {
                        objetoSolicitud.TipoInsumoDetalleID = 0;
                    }
                    objetoSolicitud.TipoRemitidoID = Convert.ToInt32(ddlTipoRemitido.SelectedValue);
                    objetoSolicitud.TipoFormaAtencionID = Convert.ToInt32(ddlTipoFormaAtencion.SelectedValue);
                    if (txtObservacionesSolicitante.Text != "")
                    {
                        objetoSolicitud.ObservacionesSolicitante = txtObservacionesSolicitante.Text.ToUpper().Trim();
                    }
                    else
                    {
                        objetoSolicitud.ObservacionesSolicitante = "N/D";
                    }
                    if (txtObservacionesAnalista.Text != "")
                    {
                        objetoSolicitud.ObservacionesAnalista = txtObservacionesAnalista.Text.ToUpper().Trim();
                    }
                    else
                    {
                        objetoSolicitud.ObservacionesAnalista = "N/D";
                    }
                    objetoSolicitud.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);
                    objetoSolicitud.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);

                    //Si la solicitud es resuelta en sitio el estatus queda en finalizada
                    if (ddlTipoRemitido.SelectedValue =="1")
                    {
                        objetoSolicitud.SolicitudEstatusID = 6;
                    }
                    else
                    {
                        objetoSolicitud.SolicitudEstatusID = 1;
                    }
                    objetoSolicitud.SolicitudPadreID = 0;
                    codigoSolicitud = Solicitud.InsertarSolicitud(objetoSolicitud);
                    if (codigoSolicitud > 0)
                    {
                        Session["SolicitudID"] = codigoSolicitud;
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nueva solicitud número: " + codigoSolicitud + " codigo de solicitante: " + Session["SolicitanteID"].ToString(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        codigoSolicitud = 0;
                        Response.Redirect("SolicitudResultado.aspx");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }


        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            CargarCombosAlEnviarFormulario();
            if (ddlPadre.SelectedValue != "")
            {
                if(ddlHijo.SelectedValue == "0" || ddlHijo.SelectedValue == "" )
                {
                    resultado = false;
                    messageBox.ShowMessage("Debe seleccionar el detalle del tipo de insumo.");
                }
            }
            if (Session["SolicitanteID"].ToString() == "0" && Session["OrganizacionID"] == null)
            {
                resultado = false;
                Response.Redirect("SeleccionarTipoSolicitud.aspx");
            }
            return resultado;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoSolicitud();
        }


        protected void btnNueva_Click(object sender, EventArgs e)
        {
            Session.Remove("SolicitanteID");
            Session.Remove("OrganizacionID");
            Session.Remove("TipoSolicitudID");
            Session.Remove("TipoSolicitanteID");
            Session.Remove("CedulaSaime");
            Session.Remove("NombreSaime");
            Session.Remove("ApellidoSaime");
            Response.Redirect("SeleccionarTipoSolicitud.aspx");
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarTipoSoporteFisico();
        }

        protected void grdSoporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtGrid.Rows[i];
                if (dr["TipoSoporteID"].ToString() == e.CommandArgument.ToString())
                {
                    dr.Delete();
                    ViewState["Soporte"] = dtGrid;
                    this.BindGrid();
                    grdSoporte.DataBind();
                }
            }
        }
    }
}