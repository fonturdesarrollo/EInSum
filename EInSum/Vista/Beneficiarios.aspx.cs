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
    public partial class Beneficiarios : Seguridad.SeguridadAuditoria
    {
        public static int codigoBeneficiario = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarPadre();
                CargaTipoBeneficiario();
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
        private void CargaTipoBeneficiario()
        {

            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoBeneficiario";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddTipoBenficiario.DataSource = cmd.ExecuteReader();
                    ddTipoBenficiario.DataTextField = "NombreTipoBeneficiario";
                    ddTipoBenficiario.DataValueField = "TipoBeneficiarioID";
                    ddTipoBenficiario.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizaBeneficiario();
        }

        private void ActualizaBeneficiario()
        {
            try
            {
                if (EsTodoCorrecto())
                {
                    CBeneficiario objetoBeneficiario = new CBeneficiario();
                    CargarCombosAlEnviarFormulario();
                    objetoBeneficiario.OrganizacionBeneficiarioID = Convert.ToInt32(hdnBeneficiarioID.Value);
                    objetoBeneficiario.TipoBeneficiarioID = Convert.ToInt32(ddTipoBenficiario.SelectedValue);
                    objetoBeneficiario.CedulaBeneficiario = Convert.ToInt32(txtCedulaBeneficiario.Text);
                    objetoBeneficiario.NombreBeneficiario = Session["NombreSaime"].ToString().ToUpper() + " " + Session["ApellidoSaime"].ToString().ToUpper();
                    objetoBeneficiario.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                    objetoBeneficiario.TelefonoBeneficiario = txtTelefonoBeneficiario.Text;
                    objetoBeneficiario.EmailBeneficiario = txtEmailBeneficiario.Text;
                    objetoBeneficiario.DireccionBeneficiario = txtDireccionBeneficiario.Text.Trim().ToUpper();
                    objetoBeneficiario.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    codigoBeneficiario = Beneficiarios.InsertarBeneficiario(objetoBeneficiario);

                    if (codigoBeneficiario > 0)
                    {
                        Session.Remove("BeneficiarioID");
                        Session["BeneficiarioID"] = codigoBeneficiario;
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo beneficiario: " + txtNombreBeneficiario.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Registro actualizado");
                        NuevoRegistro();
                        codigoBeneficiario = 0;
                    }
                    else
                    {
                        messageBox.ShowMessage("No se actualizó el registro.");
                    }
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
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
            if (EsSolicitanteValido() == false)
            {
                resultado = false;
                messageBox.ShowMessage("La cédula del beneficiario es incorrecta.");
            }
            return resultado;
        }

        private bool EsSolicitanteValido()
        {

            bool resultado = false;
            //verificar que la cedula este registrada en el SAIME
            if (EsSolicitanteEnsaime())
            {
                resultado = true;
            }

            return resultado;
        }
        private bool EsSolicitanteEnsaime()
        {
            bool resultado = false;
            int contador = 0;
            try
            {
                foreach (var saime in Saime.ObtenerDatosSaime(txtCedulaBeneficiario.Text))
                {
                    //Si ocurre algún error de conexión en la BD SAIME se sale de la busqueda
                    if (saime.Contains("ERROR "))
                    {
                        break;
                    }
                    switch (contador)
                    {
                        case 0:
                            Session["CedulaSaime"] = saime;
                            contador = 1;
                            resultado = true;
                            break;
                        case 1:
                            Session["NombreSaime"] = saime;
                            contador = 2;
                            resultado = true;
                            break;
                        case 2:
                            Session["ApellidoSaime"] = saime;
                            contador = 3;
                            resultado = true;
                            break;
                        case 3:
                            Session["Sexo"] = saime.ToUpper();
                            contador = 4;
                            resultado = true;
                            break;
                        case 4:
                            Session["SerialCarnetPatria"] = saime.ToUpper();
                            contador = 5;
                            resultado = true;
                            break;
                    }

                }
            }
            catch (Exception)
            {
                resultado = false;
            }
            return resultado;
        }

        private void NuevoRegistro()
        {
            txtCedulaBeneficiario.Text = string.Empty;
            hdnBeneficiarioID.Value = "0";
            hdnMunicipioID.Value = "0";
            hdnParroquiaID.Value = "0";
            txtDireccionBeneficiario.Text = string.Empty;
            txtEmailBeneficiario.Text = string.Empty;
            txtNombreBeneficiario.Text = string.Empty;
            txtTelefonoBeneficiario.Text = string.Empty;
            ddlHijo.Items.Clear();
            ddlNieto.Items.Clear();
            CargarPadre();
                
                 
        }
        private void CargarDatosRegionBeneficiario()
        {
            CargarMunicipioDesdeConsulta();
            CargarParroquiaDesdeConsulta();
        }
        private void CargarMunicipioDesdeConsulta()
        {
            ddlHijo.Items.Clear();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM Municipio WHERE EstadoID = " + ddlPadre.SelectedValue + " ORDER BY NombreMunicipio";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlHijo.DataSource = cmd.ExecuteReader();
                    ddlHijo.DataTextField = "NombreMunicipio";
                    ddlHijo.DataValueField = "MunicipioID";
                    ddlHijo.DataBind();
                    con.Close();
                }
            }
            ddlHijo.SelectedValue = hdnMunicipioID.Value;
        }
        private void CargarParroquiaDesdeConsulta()
        {
            ddlNieto.Items.Clear();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM Parroquia WHERE MunicipioID = " + ddlHijo.SelectedValue + " ORDER BY NombreParroquia";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlNieto.DataSource = cmd.ExecuteReader();
                    ddlNieto.DataTextField = "NombreParroquia";
                    ddlNieto.DataValueField = "ParroquiaID";
                    ddlNieto.DataBind();
                    con.Close();
                }
            }
            ddlNieto.SelectedValue = hdnParroquiaID.Value;
        }

        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            CargarDatosRegionBeneficiario();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        protected void btnImport_Click(object sender, EventArgs e)
        {
            Importar();
        }

        private void Importar()
        {
            Beneficiarios.CruzarBeneficiario();
            messageBox.ShowMessage("LISTO");
        }
    }
}