using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eisum
{
    public partial class AsignarVehiculos : Seguridad.SeguridadAuditoria
    {
        public static int codigoAsignarVehiculos = 0;
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarPadre();
                CargarEstado();
                CargarBloque();
                CargarAño();
                CargarColor();
                Session.Remove("CodigoEstado");
                Session.Remove("CodigoBloque");
                btnImprimir.Visible = false;
                //CargarTipoVehiculo();
                //CargarTipoPrestacionServicioVehiculo();
            }
        }
        //***********************************************************************************
        //PROCESO PARA COMBOS ANIDADOS:

        //COMBO ANIDADO NUMERO 1 (SE CARGA DESDE EL SERVIDOR)
        private void CargarPadre()
        {
            ddlPadre.Items.Clear();
            ddlPadre.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione la marca--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From MarcaVehiculo ORDER BY NombreMarcaVehiculo";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlPadre.DataSource = cmd.ExecuteReader();
                    ddlPadre.DataTextField = "NombreMarcaVehiculo";
                    ddlPadre.DataValueField = "MarcaVehiculoID";
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
                strQuery = "select * From ModeloVehiculo  WHERE MarcaVehiculoID   = @padreID  ORDER BY NombreModeloVehiculo";
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
                        list.Add(new System.Web.UI.WebControls.ListItem(
                       sdr["NombreModeloVehiculo"].ToString(),
                       sdr["ModeloVehiculoID"].ToString()
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

            if (ddlPadre.SelectedValue != "")
            {
                PopulateDropDownList(CargarHijo(int.Parse(padre)), ddlHijo);

                if (hijo != "0" && hijo != null)
                {
                    ddlHijo.Items.FindByValue(hijo).Selected = true;
                }
                else
                {
                    ddlHijo.Items.Clear();
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

        private void CargarColor()
        {
            ddlColor.Items.Clear();
            ddlColor.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el color--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "Select * from Color order by NombreColor";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlColor.DataSource = cmd.ExecuteReader();
                ddlColor.DataTextField = "NombreColor";
                ddlColor.DataValueField = "ColorID";
                ddlColor.DataBind();
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
        //private void CargarTipoPrestacionServicioVehiculo()
        //{
        //    String strConnString = ConfigurationManager
        //    .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
        //    String strQuery = "Select * from TipoPrestacionServicioVehiculo order by NombreTipoPrestacionServicioVehiculo";
        //    SqlConnection con = new SqlConnection(strConnString);
        //    SqlCommand cmd = new SqlCommand();

        //    cmd.CommandType = CommandType.Text;
        //    cmd.CommandText = strQuery;
        //    cmd.Connection = con;

        //    try
        //    {
        //        con.Open();
        //        ddlTipoPrestacionServicioVehiculo.DataSource = cmd.ExecuteReader();
        //        ddlTipoPrestacionServicioVehiculo.DataTextField = "NombreTipoPrestacionServicioVehiculo";
        //        ddlTipoPrestacionServicioVehiculo.DataValueField = "TipoPrestacionServicioVehiculoID";
        //        ddlTipoPrestacionServicioVehiculo.DataBind();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        con.Close();
        //        con.Dispose();
        //    }
        //}
        private void CargarAño()
        {
            ddAñoVehiculo.Items.Clear();
            ddAñoVehiculo.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el año--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "Select * from Año order by AñoID";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddAñoVehiculo.DataSource = cmd.ExecuteReader();
                ddAñoVehiculo.DataTextField = "NombreAño";
                ddAñoVehiculo.DataValueField = "AñoID";
                ddAñoVehiculo.DataBind();
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
        private void CargarDetalleVehiculoAsignadoOrganizacion()
        {
            try
            {
                gridDetalle.Visible = true;
                gridDetalle2.Visible = false;
                DataSet ds = AsignarVehiculos.ObtenerVehiculosAsignadosOrganizacion(Convert.ToInt32(hdnCodigoOrganizacion.Value));
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
                lblTotalRegistros.Text= ds.Tables[0].Rows.Count.ToString();
                btnImprimir.Visible = true;

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarDetalleVehiculoAsignado()
        {
            try
            {
                gridDetalle.Visible = false;
                gridDetalle2.Visible = true;
                int codigoVehiculoAsignado =0;
                if (Session["OrganizacionAsignarVehiculoID"] != null)
                {
                    codigoVehiculoAsignado = Convert.ToInt32(Session["OrganizacionAsignarVehiculoID"].ToString());
                }
                DataSet ds = AsignarVehiculos.ObtenerVehiculosAsignadosBeneficiario(codigoVehiculoAsignado, Convert.ToInt32(hdnBeneficiarioID.Value));
                DataTable dt = ds.Tables[0];
                gridDetalle2.DataSource = dt;
                gridDetalle2.DataBind();
                if(ds.Tables[0].Rows.Count > 0)
                {
                    txtCedulaBeneficiario.Text = ds.Tables[0].Rows[0]["CedulaBeneficiario"].ToString() + " " + ds.Tables[0].Rows[0]["NombreBeneficiario"].ToString();
                }
                
                btnNuevoRegistro.Text = "Limpiar selección";
                btnImprimir.Visible = true;
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizaAsignarVehiculo();
        }
        private void ActualizaAsignarVehiculo()
        {
            if(EsTodoCorrecto())
            {
                try
                {
                    CAsignarVehiculos objetoAsignarVehiculo = new CAsignarVehiculos();
                    objetoAsignarVehiculo.OrganizacionAsignarVehiculoID = Convert.ToInt32(hdnCodigoOrganizacionAsignarVehiculoID.Value);
                    objetoAsignarVehiculo.OrganizacionID = Convert.ToInt32(hdnCodigoOrganizacion.Value);
                    objetoAsignarVehiculo.OrganizacionBeneficiarioID = Convert.ToInt32(hdnBeneficiarioID.Value);
                    objetoAsignarVehiculo.Placa = txtPlaca.Text.ToUpper();
                    objetoAsignarVehiculo.TipoVehiculoID = 1;// Convert.ToInt32(ddTipoVehiculo.SelectedValue);
                    objetoAsignarVehiculo.SerialCarroceria = txtSerialCarroceria.Text.ToUpper();
                    objetoAsignarVehiculo.Puestos = 0;// Convert.ToInt32(txtPuestos.Text);
                    objetoAsignarVehiculo.AñoVehiculo = Convert.ToInt32(ddAñoVehiculo.SelectedValue);
                    objetoAsignarVehiculo.TipoPrestacionServicioVehiculoID = 1;//Convert.ToInt32(ddlTipoPrestacionServicioVehiculo.SelectedValue);
                    objetoAsignarVehiculo.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);
                    objetoAsignarVehiculo.SerialMotor = txtSerialMotor.Text.ToUpper();
                    objetoAsignarVehiculo.ColorID = Convert.ToInt32(ddlColor.SelectedValue);
                    objetoAsignarVehiculo.Ruta = txtRuta.Text.ToUpper();
                    objetoAsignarVehiculo.ModeloVehiculoID = Convert.ToInt32(ddlHijo.SelectedValue);
                    codigoAsignarVehiculos = AsignarVehiculos.InsertarAsignarVehiculo(objetoAsignarVehiculo);

                    if (codigoAsignarVehiculos > 0)
                    {
                        Session.Remove("OrganizacionAsignarVehiculoID");
                        Session["OrganizacionAsignarVehiculoID"] = codigoAsignarVehiculos;
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Asignó nuevo vehiculo a beneficiario: " + txtCedulaBeneficiario.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        NuevoRegistroLuegoProceso();
                        messageBox.ShowMessage("Registro actualizado");
                        codigoAsignarVehiculos = 0;
                    }
                    else
                    {
                        messageBox.ShowMessage("No se actualizó el registro.");
                    }

                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
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
                    messageBox.ShowMessage("Debe seleccionar el modelo.");
                }
            }
          
            if (hdnBeneficiarioID.Value =="0")
            {
                resultado = false;
                messageBox.ShowMessage("Debe selecionar el beneficiario de la lista.");
            }
            else if (hdnCodigoOrganizacion.Value == "0")
            {
                resultado = false;
                messageBox.ShowMessage("Debe selecionar la organización de la lista.");
            }
            if (AsignarVehiculos.EsPlacaAsignada(txtPlaca.Text.ToUpper()))
            {
                resultado = false;
                messageBox.ShowMessage("La placa ya está asignada.");
            }
            if(ddlEstado.SelectedValue =="")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar el estado y el bloque de la lista.");
                NuevoRegistro();

            }
            if (ddlBloque.SelectedValue == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe seleccionar el estado y el bloque de la lista.");
                NuevoRegistro();

            }
            return resultado;
        }
        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    AsignarVehiculos.EliminarVehiculoAsignado(Convert.ToInt32(e.CommandArgument.ToString()));
                    messageBox.ShowMessage("Vehículo eliminado.");
                    NuevoRegistroLuegoProceso();
                }
                else if(e.CommandName == "ModificarDetalle")
                {
                    hdnBeneficiarioID.Value = e.CommandArgument.ToString();
                    CargarDetalleVehiculoAsignado();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void ButtonTest_Click(object sender, EventArgs e)
        {
            //SE COMENTO PARA SIEMPRE PERMITIR CARGAR A LA MISMA ORGANIZACION
            //Session.Remove("OrganizacionAsignarVehiculoID");
            //hdnCodigoOrganizacion.Value = "0";
            CargarDetalleVehiculoAsignado();
        }
        private void NuevoRegistroLuegoProceso()
        {
            gridDetalle.Visible = true;
            gridDetalle2.Visible = false;
            btnNuevoRegistro.Text = "Nuevo registro";
            Session.Remove("OrganizacionAsignarVehiculoID");
            txtPlaca.Text = string.Empty;
            txtSerialCarroceria.Text = string.Empty;
            if(hdnBeneficiarioID.Value !="0")
            {
                CargarDetalleVehiculoAsignado();
            }
            else
            {
                txtCedulaBeneficiario.Text = "";
                CargarDetalleVehiculoAsignadoOrganizacion();
            }
            
        }
        private void NuevoRegistro()
        {
            txtCedulaBeneficiario.Text = string.Empty;
            txtRifOrganizacion.Text = string.Empty;
            txtPlaca.Text = string.Empty;
            //txtPuestos.Text = string.Empty;
            txtSerialCarroceria.Text = string.Empty;
            hdnBeneficiarioID.Value = "0";
            hdnCodigoOrganizacion.Value = "0";
            hdnCodigoOrganizacionAsignarVehiculoID.Value = "0";
            txtCedulaBeneficiario.Focus();
            gridDetalle2.Visible = false;
            gridDetalle.Visible = true;
            gridDetalle.DataSource = null;
            gridDetalle.DataBind();

            ddlEstado.Enabled = true;
            ddlBloque.Enabled = true;
            CargarAño();
            CargarEstado();
            CargarBloque();
            CargarColor();
            CargarPadre();
            ddlHijo.Items.Clear();
            Session.Remove("CodigoEstado");
            Session.Remove("CodigoBloque");
            lblTotalRegistros.Text = "0";
            btnImprimir.Visible = false;
        }

        protected void btnNuevoRegistro_Click(object sender, EventArgs e)
        {
            if(btnNuevoRegistro.Text !="Limpiar selección")
            {
                NuevoRegistro();
            }
            else
            {
                hdnBeneficiarioID.Value = "0";
                NuevoRegistroLuegoProceso();
            }
        }

        protected void ButtonTest2_Click(object sender, EventArgs e)
        {
            CargarDetalleVehiculoAsignadoOrganizacion();
        }

        protected void ddlEstado_SelectedIndexChanged(object sender, EventArgs e)
        {

            Session["CodigoEstado"] = ddlEstado.SelectedValue;
            ddlEstado.Enabled = false;
        }

        protected void ddlBloque_SelectedIndexChanged(object sender, EventArgs e)
        {
            Session["CodigoBloque"] = ddlBloque.SelectedValue;
            ddlBloque.Enabled = false;
        }

        private void ActualizarLista()
        {
            try
            {
                string fechaDia = DateTime.Now.ToString("dd/MM/yyyy");
                int contadorRegistros = 0;
                List<CAsignarVehiculos> objetoLista = new List<CAsignarVehiculos>();
                string sResultado = ValidarDatos(ref objetoLista);
                foreach (CAsignarVehiculos prod in objetoLista)
                {
                    contadorRegistros = contadorRegistros + 1;
                    AsignarVehiculos.InsertarAsignarVehiculo(prod);

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
        private string ValidarDatos(ref List<CAsignarVehiculos> objetoAsignarEstatus)
        {
            try
            {
                string sResultado = "";
                CAsignarVehiculos objetoAsignaEstatus = null;
                int j = 1;
                foreach (GridViewRow dr in this.gridDetalle2.Rows)
                {
                    objetoAsignaEstatus = new CAsignarVehiculos();
                    objetoAsignaEstatus.OrganizacionAsignarVehiculoID = Utils.utils.ToInt(((Label)dr.FindControl("lblCodigoTabla")).Text);
                    objetoAsignaEstatus.OrganizacionID = Utils.utils.ToInt(((Label)dr.FindControl("lblCodigoOrganizacion")).Text);
                    objetoAsignaEstatus.OrganizacionBeneficiarioID = Utils.utils.ToInt(((Label)dr.FindControl("lblCodigoTransportista")).Text);
                    objetoAsignaEstatus.Placa = Utils.utils.ToString(((TextBox)dr.FindControl("txtPlacaGrid")).Text);
                    objetoAsignaEstatus.SerialCarroceria = Utils.utils.ToString(((TextBox)dr.FindControl("txtSerialCarroceriaGrid")).Text);
                    objetoAsignaEstatus.SerialMotor = Utils.utils.ToString(((TextBox)dr.FindControl("txtSerialMotorGrid")).Text);
                    objetoAsignaEstatus.AñoVehiculo = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlAñoGrid")).SelectedValue);
                    objetoAsignaEstatus.ColorID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlColorGrid")).SelectedValue);
                    objetoAsignaEstatus.ModeloVehiculoID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddModeloGrid")).SelectedValue);
                    objetoAsignaEstatus.Ruta = Utils.utils.ToString(((TextBox)dr.FindControl("txtRutaGrid")).Text);

                    objetoAsignaEstatus.TipoVehiculoID = 1;
                    objetoAsignaEstatus.TipoPrestacionServicioVehiculoID = 1;
                    objetoAsignaEstatus.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);


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
                    AsignarVehiculos.EliminarVehiculoAsignado(Convert.ToInt32(e.CommandArgument.ToString()));
                    messageBox.ShowMessage("Vehículo eliminado.");
                    NuevoRegistroLuegoProceso();
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

        protected void btnImprimir_Click(object sender, EventArgs e)
        {


            if (hdnCodigoOrganizacion.Value != "0")
            {
                try
                {
                    string nombreOrganizacion = "";
                    string estado = "";
                    string bloque = "";
                    int totalRegistros = 0;

                    DataSet dsOrg = AsignarVehiculos.ObtenerVehiculosAsignadosOrganizacion(Convert.ToInt32(hdnCodigoOrganizacion.Value));
                    DataTableReader drOrg = dsOrg.Tables[0].CreateDataReader();

                    if (drOrg.Read())
                    {
                        nombreOrganizacion = drOrg["RifOrganizacion"].ToString() + " " + drOrg["NombreOrganizacion"].ToString();
                        estado = drOrg["NombreEstado"].ToString(); 
                        bloque = drOrg["NombreBloque"].ToString();
                        totalRegistros = dsOrg.Tables[0].Rows.Count;
                        drOrg.Close();
                    }


                    // Create a Document object
                    Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);

                    // Create a new PdfWrite object, writing the output to a MemoryStream
                    var output = new MemoryStream();
                    var writer = PdfWriter.GetInstance(document, output);

                    // Open the Document for writing
                    document.Open();


                    var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                    var subTitleFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                    var boldTableFont = FontFactory.GetFont("Arial", 6, Font.BOLD);
                    var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                    var bodyFont = FontFactory.GetFont("Arial", 8, Font.NORMAL);


                    var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/LogoFonturChiquito.png"));
                    logo.SetAbsolutePosition(510, 770);
                    logo.ScaleAbsolute(60f, 60f);
                    document.Add(logo);

                    // Add the "Northwind Traders Receipt" title
                    document.Add(new Paragraph("Ficha de Organización", titleFont));

                    // Now add the "Thank you for shopping at Northwind Traders. Your order details are below." message



                    document.Add(new Paragraph("Organización: " + nombreOrganizacion, bodyFont));
                    document.Add(new Paragraph("Estado: " + estado, bodyFont));
                    document.Add(new Paragraph("Bloque: " + bloque, bodyFont));

                    var endingMessage = new Paragraph("Reporte impreso por: " + Session["NombreCompletoUsuario"] + " el día:  " + System.DateTime.Now, bodyFont);


                    document.Add(endingMessage);

                    document.Add(Chunk.NEWLINE);


                    // Add the "Items In Your Order" subtitle
                    document.Add(new Paragraph("Detalle de transportistas", subTitleFont));

                    // Create the Order Details table
                    var orderDetailsTable = new PdfPTable(8);
                    orderDetailsTable.HorizontalAlignment = 1;
                    orderDetailsTable.SpacingBefore = 10;
                    orderDetailsTable.SpacingAfter = 35;
                    orderDetailsTable.DefaultCell.Border = 0;

                    orderDetailsTable.TotalWidth = 500f;
                    orderDetailsTable.LockedWidth = true;
                    float[] widths = new float[] { 35f, 35f, 60f, 60f, 50f, 40f, 40f, 50f};
                    orderDetailsTable.SetWidths(widths);
                    orderDetailsTable.AddCell(new Phrase("Placa", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Cedula", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Transportista", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Serial Carroceria", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Serial Motor", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Marca", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Modelo", boldTableFont));
                    orderDetailsTable.AddCell(new Phrase("Ruta", boldTableFont));

                    DataSet dg = AsignarVehiculos.ObtenerVehiculosAsignadosOrganizacion(Convert.ToInt32(hdnCodigoOrganizacion.Value));
                    DataTableReader dr = dsOrg.Tables[0].CreateDataReader();

                    while (dr.Read())
                    {
                        orderDetailsTable.AddCell(new Phrase(dr["Placa"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["CedulaBeneficiario"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["NombreBeneficiario"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["SerialCarroceria"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["SerialMotor"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["NombreMarcaVehiculo"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["NombreModeloVehiculo"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                        orderDetailsTable.AddCell(new Phrase(dr["Ruta"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                    }
                    dr.Close();
       

                    document.Add(orderDetailsTable);


                    // Add ending message
                    var totalMessage = new Paragraph("Cantidad de transportistas: " + totalRegistros, endingMessageFont);

                    totalMessage.SetAlignment("Center");
                    document.Add(totalMessage);

                    document.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=FichaOrganizacion-{0}.pdf", ""));
                    Response.BinaryWrite(output.ToArray());

                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
            else
            {
                messageBox.ShowMessage("Debe seleccionar la organización para imprimir el reporte");
            }

        }

        protected void ddlMarcaGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList ddl = sender as DropDownList;
            TextBox txt = ddl.NamingContainer.FindControl("txtModeloID") as TextBox;
            txt.Text = "";
        }
    }
}
