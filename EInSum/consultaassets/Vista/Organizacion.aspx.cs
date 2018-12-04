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
    public partial class Organizacion : Seguridad.SeguridadAuditoria
    {
        public static int codigoOrganizacion = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablecerEstadoInicial();
                CargarTipoOrganizacion();
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
                        lblTitulo.Text = "Datos de la Organización [ Solicitante: " + dr["CedulaSolicitante"].ToString() + " " + dr["NombreSolicitante"].ToString() + " " + dr["ApellidoSolicitante"].ToString() + "]";
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
        //***********************************************************************************
        //PROCESO PARA COMBOS ANIDADOS:

        //COMBO ANIDADO NUMERO 1 (SE CARGA DESDE EL SERVIDOR)
        private void CargarPadre()
        {
            ddlPadre.Items.Clear();
            ddlPadre.Items.Add(new ListItem("--Seleccione el estado--", ""));
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
                    ddlPadre.DataSource = cmd.ExecuteReader();
                    ddlPadre.DataTextField = "NombreEstado";
                    ddlPadre.DataValueField = "EstadoID";
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
                strQuery = "select * From Municipio  WHERE EstadoID   = @padreID  ORDER BY NombreMunicipio";
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
                       sdr["NombreMunicipio"].ToString(),
                       sdr["MunicipioID"].ToString()
                        ));
                    }
                    con.Close();
                    return list;
                }
            }
        }
        //*********************************************************************************

        //COMBO ANIDADO NUMERO 3 (SE CARGA EN EL CLIENTE CON JSON MEDIANTE LA FUNCION CargarNieto())
        [System.Web.Services.WebMethod]
        public static ArrayList CargarNieto(int nietoID)
        {
            ArrayList list = new ArrayList();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Parroquia Where MunicipioID  = @nietoID  ORDER BY NombreParroquia";
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@nietoID", nietoID);
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    SqlDataReader sdr = cmd.ExecuteReader();
                    while (sdr.Read())
                    {
                        list.Add(new ListItem(
                       sdr["NombreParroquia"].ToString(),
                       sdr["ParroquiaID"].ToString()
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
            string padre = Request.Form[ddlPadre.UniqueID];
            string hijo = Request.Form[ddlHijo.UniqueID];
            string nieto = Request.Form[ddlNieto.UniqueID];

            if (ddlPadre.SelectedValue != "")
            {
                PopulateDropDownList(CargarHijo(int.Parse(padre)), ddlHijo);
                PopulateDropDownList(CargarNieto(int.Parse(hijo)), ddlNieto);
                if (hijo != "0" && hijo != null)
                {
                    ddlHijo.Items.FindByValue(hijo).Selected = true;
                }
                else
                {
                    ddlHijo.Items.Clear();
                }
                if (nieto != "0" && nieto != null)
                {
                    ddlNieto.Items.FindByValue(nieto).Selected = true;
                }
                else
                {
                    ddlNieto.Items.Clear();
                }
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
        private void EstablecerEstadoInicial()
        {
            codigoOrganizacion = 0;
            if (EstablecerOrganizacion() == false && EstablecerOrganizacionNueva() == false)
            {
                Response.Redirect("SeleccionarOrganizacion.aspx");
            }
        }
        private bool EstablecerOrganizacion()
        {
            bool resultado = false;
            try
            {
                if (Convert.ToInt32(Session["OrganizacionID"]) > 0)
                {
                    SqlDataReader dr = Organizacion.ObtenerDatosOrganizacion(Convert.ToInt32(Session["OrganizacionID"]));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            codigoOrganizacion = Convert.ToInt32(Session["OrganizacionID"]);
                            txtRifOrganizacion.Text = dr["RifOrganizacion"].ToString();
                            txtNombreOrganizacion.Text = dr["NombreOrganizacion"].ToString();
                            ddTipoOrganizacion.SelectedValue = dr["TipoOrganizacionID"].ToString();
                            txtTelefonoOrganizacion.Text = dr["TelefonoOrganizacion"].ToString();
                            ddlPadre.Items.Add(new ListItem(dr["NombreEstado"].ToString(), ""));
                            ddlHijo.Items.Add(new ListItem(dr["NombreMunicipio"].ToString(), ""));
                            ddlNieto.Items.Add(new ListItem(dr["NombreParroquia"].ToString(), ""));
                            SoloLecturaRegistrado();
                            resultado = true;
                        }
                    }
                    dr.Close();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message);
            }
            return resultado;
        }
        private bool EstablecerOrganizacionNueva()
        {
            bool resultado = false;
            try
            {
                if (Session["RifOrganizacion"] != null && Session["RifOrganizacion"].ToString() != "")
                {
                    CargarPadre();
                    codigoOrganizacion = 0;
                    txtRifOrganizacion.Text = Session["RifOrganizacion"].ToString();
                    SoloLecturaNuevo();
                    resultado = true;
                }
                else
                {
                    resultado = false;
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message);
            }
            return resultado;

        }
        private void SoloLecturaRegistrado()
        {
            txtRifOrganizacion.Enabled = false;
            txtNombreOrganizacion.Enabled = false;
            ddTipoOrganizacion.Enabled = false;
            txtTelefonoOrganizacion.Enabled = false;
            ddlPadre.Enabled = false;
            ddlHijo.Enabled = false;
            ddlNieto.Enabled = false;
            btnGuardar.Text = "Organización registrada";
            btnGuardar.Enabled = false;
            btnSiguiente.Visible = true;
        }
        private void SoloLecturaNuevo()
        {
            txtRifOrganizacion.Enabled = false;
            btnSiguiente.Visible = false;
        }
        private void CargarTipoOrganizacion()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from TipoOrganizacion order by NombreTipoOrganizacion";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddTipoOrganizacion.DataSource = cmd.ExecuteReader();
                ddTipoOrganizacion.DataTextField = "NombreTipoOrganizacion";
                ddTipoOrganizacion.DataValueField = "TipoOrganizacionID";
                ddTipoOrganizacion.DataBind();
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
        private void ProcesoOrganizacion()
        {
            try
            {
                if(EsTodoCorrecto())
                {
                    COrganizacion objetoOrganizaicon = new COrganizacion();
                    CargarCombosAlEnviarFormulario();
                    objetoOrganizaicon.OrganizacionID = codigoOrganizacion;
                    objetoOrganizaicon.RifOrganizacion = txtRifOrganizacion.Text.ToUpper();
                    objetoOrganizaicon.NombreOrganizacion = txtNombreOrganizacion.Text.ToUpper();
                    objetoOrganizaicon.TipoOrganizacionID = Convert.ToInt32(ddTipoOrganizacion.SelectedValue);
                    objetoOrganizaicon.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                    objetoOrganizaicon.TelefonoOrganizacion = txtTelefonoOrganizacion.Text;
                    objetoOrganizaicon.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    objetoOrganizaicon.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
                    codigoOrganizacion = Organizacion.InsertarOrganizacion(objetoOrganizaicon);
                    if (codigoOrganizacion > 0)
                    {
                        Session.Remove("OrganizacionID");
                        Session["OrganizacionID"] = codigoOrganizacion;
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nueva organización: " + txtNombreOrganizacion.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        codigoOrganizacion = 0;
                        Response.Redirect("~/Vista/Solicitud.aspx");
                     }
                    else
                    {
                        messageBox.ShowMessage("No se actualizó el registro.");
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
                if (ddlHijo.SelectedValue == "0" || ddlHijo.SelectedValue == "")
                {
                    resultado = false;
                    messageBox.ShowMessage("Debe seleccionar el municipio.");
                }
                else if (ddlNieto.SelectedValue == "0" || ddlNieto.SelectedValue == "")
                {
                    resultado = false;
                    messageBox.ShowMessage("Debe seleccionar la parroquia.");
                }
            }
            return resultado;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoOrganizacion();
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Session["OrganizacionID"] != null && Session["OrganizacionID"].ToString() != "")
            {
                Session["OrganizacionID"] = codigoOrganizacion;
                codigoOrganizacion = 0;
                Response.Redirect("~/Vista/Solicitud.aspx");
            }
            else
            {
                messageBox.ShowMessage("No puede avanzar al siguiente paso hasta no agregar los datos de la organización y presionar REGISTRAR ORGANIZACION");
            }
        }
    }
}