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
    public partial class Organizacion : Seguridad.SeguridadAuditoria
    {
        public static int codigoOrganizacion = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("CodigoEstado");
            Session.Remove("CodigoBloque");
            if (!IsPostBack)
            {
                CargarPadre();
                CargarTipoOrganizacion();
                CargarBloque();
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
        private void CargarBloque()
        {
            ddlBloque.Items.Clear();
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
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoOrganizacion();
        }

        private void ProcesoOrganizacion()
        {
            try
            {
                if (EsTodoCorrecto())
                {
                    COrganizacion objetoOrganizacion = new COrganizacion();
                    CargarCombosAlEnviarFormulario();
                    objetoOrganizacion.OrganizacionID =  Convert.ToInt32(hdnCodigoOrganizacion.Value);
                    objetoOrganizacion.TipoOrganizacionID = Convert.ToInt32(ddTipoOrganizacion.SelectedValue);
                    objetoOrganizacion.RifOrganizacion = txtRifOrganizacion.Text.ToUpper();
                    objetoOrganizacion.NombreOrganizacion = txtNombreOrganizacion.Text.ToUpper();
                    objetoOrganizacion.ParroquiaID = Convert.ToInt32(ddlNieto.SelectedValue);
                    objetoOrganizacion.TelefonoLocalOrganizacion = txtTelefonoLocalOrganizacion.Text;
                    objetoOrganizacion.TelefonoCelularOrganizacion = txtTelefonoOrganizacion.Text;
                    objetoOrganizacion.EmailOrganizacion = txtEmailOrg.Text;
                    objetoOrganizacion.DireccionOrganizacion = txtDireccionOrganizacion.Text.Trim().ToUpper();
                    objetoOrganizacion.CedulaPresidente = 0;//Convert.ToInt32(txtCedulaPresidente.Text);
                    txtNombrePresidente.Text = ""; // Session["NombreSaime"].ToString().ToUpper() + " " + Session["ApellidoSaime"].ToString().ToUpper();
                    objetoOrganizacion.NombrePresidente = txtNombrePresidente.Text.ToUpper();
                    objetoOrganizacion.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    objetoOrganizacion.BloqueID = Convert.ToInt32(ddlBloque.SelectedValue);
                    codigoOrganizacion = Organizacion.InsertarOrganizacion(objetoOrganizacion);

                    if (codigoOrganizacion > 0)
                    {
                        Session.Remove("OrganizacionID");
                        Session["OrganizacionID"] = codigoOrganizacion;
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nueva organización: " + txtNombreOrganizacion.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        codigoOrganizacion = 0;
                        NuevoRegistro();
                        messageBox.ShowMessage("Registro actualizado");
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

            //SE COMENTO DEBIDO A QUE NO ES REQUERIDA LA CEDULA DEL PRESIDENTE
            //if(EsSolicitanteValido() == false)
            //{
            //    resultado = false;
            //    messageBox.ShowMessage("La cédula del presidente de la organización es incorrecta.");
            //}
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
                foreach (var saime in Saime.ObtenerDatosSaime(txtCedulaPresidente.Text))
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
            txtRifOrganizacion.Text = string.Empty;
            txtNombreOrganizacion.Text = string.Empty;
            txtTelefonoLocalOrganizacion.Text = string.Empty;
            txtTelefonoOrganizacion.Text = string.Empty;
            txtDireccionOrganizacion.Text = string.Empty;
            txtEmailOrg.Text = string.Empty;
            txtCedulaPresidente.Text = string.Empty;
            txtNombrePresidente.Text = string.Empty;
            CargarPadre();
            ddlHijo.Items.Clear();
            ddlNieto.Items.Clear();
            hdnCodigoOrganizacion.Value = "0";
            hdnMunicipioID.Value = "0";
            hdnParroquiaID.Value = "0";
        }
        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            CargarDatosOrganizacion();
        }

        private void CargarDatosOrganizacion()
        {
            CargarMunicipioDesdeConsulta();
            CargarParroquiaDesdeConsulta();
            txtNombrePresidente.Visible = true;
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

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }
    }
}