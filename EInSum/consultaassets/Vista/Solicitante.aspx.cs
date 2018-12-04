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
    public partial class Solicitantes  : Seguridad.SeguridadAuditoria
    {
        public static int codigoSolicitante = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                EstablecerEstadoInicial();
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

            if (EstablecerSolicitante() == false && EstablecerSolicitanteNuevo() == false)
            {
                Response.Redirect("SeleccionarSolicitante.aspx");
            }
        }
        private bool EstablecerSolicitante()
        {
            bool resultado = false;
            try
            {
                if (Convert.ToInt32(Session["SolicitanteID"]) > 0)
                {
                    SqlDataReader dr = Solicitante.ObtenerDatosSolicitante(Convert.ToInt32(Session["SolicitanteID"]));
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            txtCedula.Text = dr["CedulaSolicitante"].ToString();
                            txtNombre.Text = dr["NombreSolicitante"].ToString();
                            txtApellido.Text = dr["ApellidoSolicitante"].ToString();
                            ddlSexo.SelectedValue = dr["Sexo"].ToString();
                            txtCelular.Text = dr["CelularSolicitante"].ToString();
                            txtTelefonoLocal.Text = dr["TelefonoLocalSolicitante"].ToString();
                            txtTelefonoOficina.Text = dr["TelefonoOficinalSolicitante"].ToString();
                            txtCorreo.Text = dr["CorreoElectronicoSolicitante"].ToString();
                            ddlPadre.Items.Add(new ListItem(dr["NombreEstado"].ToString(), ""));
                            ddlHijo.Items.Add(new ListItem(dr["NombreMunicipio"].ToString(), ""));
                            ddlNieto.Items.Add(new ListItem(dr["NombreParroquia"].ToString(), ""));
                            if (dr["IndicaCarnetPatria"].ToString() == "0")
                            {
                                chkPatria.Checked = false;
                            }
                            else
                            {
                                chkPatria.Checked = true;
                            }
                            txtSerialCarnetPatria.Text = dr["SerialCarnetPatria"].ToString();
                            txtCodigoCarnetPatria.Text = dr["CodigoCarnetPatria"].ToString();
                            codigoSolicitante = 0;
                            codigoSolicitante = Convert.ToInt32(Session["SolicitanteID"]);
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
        private bool EstablecerSolicitanteNuevo()
        {
            bool resultado = false;
            try
            {
                if (Session["CedulaSaime"] != null && Session["CedulaSaime"].ToString() != "")
                {
                    CargarPadre();
                    txtCedula.Text = Session["CedulaSaime"].ToString();
                    txtNombre.Text = Session["NombreSaime"].ToString();
                    txtApellido.Text =  Session["ApellidoSaime"].ToString();

                    ddlSexo.SelectedValue = Session["Sexo"].ToString();
                    if(Session["SerialCarnetPatria"].ToString() !="")
                    {
                        chkPatria.Checked = true;
                        txtSerialCarnetPatria.Text = Session["SerialCarnetPatria"].ToString();
                        chkPatria.Enabled = false;
                        txtSerialCarnetPatria.Enabled = false;
                    }
                    else 
                    {
                        chkPatria.Checked = false;
                        chkPatria.Enabled = true;
                        txtSerialCarnetPatria.Enabled = true;
                    }
                    txtCedula.Enabled = false;
                    txtNombre.Enabled = false;
                    txtApellido.Enabled = false;
                    codigoSolicitante = 0;
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
            txtCedula.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            ddlSexo.Enabled = false;
            txtCelular.Enabled = false;
            txtTelefonoLocal.Enabled = false;
            txtTelefonoOficina.Enabled = false;
            txtCorreo.Enabled = false;
            ddlPadre.Enabled = false;
            ddlHijo.Enabled = false;
            ddlNieto.Enabled = false;
            txtSerialCarnetPatria.Enabled = false;
            txtCodigoCarnetPatria.Enabled = false;
            chkPatria.Enabled = false;
            btnGuardar.Text = "Solicitante registrado";
            btnGuardar.Enabled = false;
            btnSiguiente.Visible = true;
        }
        private void SoloLecturaNuevo()
        {
            txtCedula.Enabled = false;
            txtNombre.Enabled = false;
            txtApellido.Enabled = false;
            btnSiguiente.Visible = false;
            ddlSexo.Enabled = false;
        }
        private void ProcesoSolicitante()
        {
            try
            {
                if(EsTodoCorrecto())
                {
                    CSolicitante objetoSolicitante = new CSolicitante();
                    CargarCombosAlEnviarFormulario();
                    objetoSolicitante.SolicitanteID = codigoSolicitante;
                    objetoSolicitante.CedulaSolicitante = txtCedula.Text;
                    objetoSolicitante.Nombresolicitante = txtNombre.Text.ToUpper();
                    objetoSolicitante.ApellidoSolicitante = txtApellido.Text.ToUpper();
                    objetoSolicitante.Sexo = ddlSexo.SelectedValue;
                    objetoSolicitante.CelularSolicitante = txtCelular.Text;
                    objetoSolicitante.TelefonoLocalSolicitante = txtTelefonoLocal.Text;
                    objetoSolicitante.TelefonoOficinalSolicitante = txtTelefonoOficina.Text;
                    objetoSolicitante.CorreoElectronicoSolicitante = txtCorreo.Text.ToUpper();
                    objetoSolicitante.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                    objetoSolicitante.IndicaCarnetPatria = chkPatria.Checked ? 1 : 0;
                    objetoSolicitante.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    objetoSolicitante.EmpresaSucursalID = Convert.ToInt32(Session["CodigoSucursalEmpresa"]);
                    if (chkPatria.Checked == true)
                    {
                        objetoSolicitante.SerialCarnetPatria = txtSerialCarnetPatria.Text.ToUpper();
                        objetoSolicitante.CodigoCarnetPatria = txtCodigoCarnetPatria.Text.ToUpper();
                    }
                    else
                    {
                        objetoSolicitante.SerialCarnetPatria = "";
                        objetoSolicitante.CodigoCarnetPatria = "";
                    }

                    codigoSolicitante = Solicitante.InsertarSolicitante(objetoSolicitante);
                    if (codigoSolicitante > 0)
                    {
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo solicitante cedula:" + txtCedula.Text.ToUpper() + " nombre: " + txtNombre.Text + " " + txtApellido.Text , System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        LimpiarVariablesSession();
                        Session["SolicitanteID"] = codigoSolicitante;
                        codigoSolicitante = 0;
                        Response.Redirect("SeleccionarTipoSolicitante.aspx");
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
                else if(ddlNieto.SelectedValue == "0" || ddlNieto.SelectedValue == "")
                {
                    resultado = false;
                    messageBox.ShowMessage("Debe seleccionar la parroquia.");
                }
            }
            return resultado;
        }
        private bool EsTodoCorrectoParaSiguiente()
        {
            bool resultado = true;
            CargarCombosAlEnviarFormulario();
            if (Session["SolicitanteID"] == null)
            {
                resultado = false;
                messageBox.ShowMessage("No puede avanzar al siguiente paso hasta no agregar los datos del solicitante y presionar: REGISTRAR SOLICITANTE");
            }
            return resultado;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoSolicitante();
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (Session["SolicitanteID"] != null && Session["SolicitanteID"].ToString() !="")
            {
                codigoSolicitante = 0;
                Response.Redirect("SeleccionarTipoSolicitante.aspx");
            }
            else
            {
                messageBox.ShowMessage("No puede avanzar al siguiente paso hasta no agregar los datos del solicitante y presionar: REGISTRAR SOLICITANTE");
            }
        }
        private void LimpiarVariablesSession()
        {
            Session.Remove("SolicitanteID");
            Session.Remove("CedulaSaime");
            Session.Remove("NombreSaime");
            Session.Remove("ApellidoSaime");
        }
    }
}