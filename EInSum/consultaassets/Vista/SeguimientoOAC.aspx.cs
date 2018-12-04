using System;
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
    public partial class SeguimientoOAC : Seguridad.SeguridadAuditoria
    {
        private static DataTable dtGrid;
        private static DataTable dtGridDocumentos;
        private static string nombreValidoPostulante ="";
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                EstablecerVistaSegunGerencia();
                lblTitulo.Text = Session["NombreGerenciaSeguimiento"].ToString() + " seguimiento a la solicitud " + Session["SolicitudParaSeguimientoID"].ToString();
                CargarGridPostulados();
                CargarGridDocumentos();
                CargarPostulados();
                CargarDocumentos();
                CargarConsulta();
                CargarTipoAccion();
                CargarTipoRemitido();
                CargarTipoSoporte();
                CargarTipoInstruccion();
            }
        }

        private void EstablecerVistaSegunGerencia()
        {
            switch (Session["NombreGerenciaSeguimiento"].ToString())
            {
                case "OAC":
                    txtCedulaPostulante.Visible = true;
                    txtTelefonoPostulante.Visible = true;
                    Button1.Visible = true;
                    break;
                default:
                    txtCedulaPostulante.Visible = false;
                    txtTelefonoPostulante.Visible = false;
                    Button1.Visible = false;
                    grdSoporte.Columns[3].Visible = false;
                    break;
            }
        }
        private void CargarGridPostulados()
        {
            if (dtGrid != null)
            {
                dtGrid.Clear();
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("CedulaPostulante"), new DataColumn("NombrePostulante"), new DataColumn("Telefono"), new DataColumn("EstatusFichaSocialID") });
            ViewState["Soporte"] = dt;
            this.BindGrid();
        }
        private void CargarPostulados()
        {
            try
            {
                SqlDataReader dr = SeguimientoOAC.ObtenerPostulados(Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()));

                if(dr.HasRows)
                {
                    while(dr.Read())
                    {
                        dtGrid = (DataTable)ViewState["Soporte"];
                        dtGrid.Rows.Add(dr["CedulaPostulado"].ToString(), dr["NombrePostulado"].ToString(), dr["TelefonoPostulado"].ToString(), dr["EstatusFichaSocialID"].ToString());
                        ViewState["Soporte"] = dtGrid;
                        this.BindGrid();
                    }
                }
                dr.Close();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarDocumentos()
        {
            try
            {
                SqlDataReader dr = SeguimientoOAC.ObtenerDocumentosSolicitud(Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()));

                while (dr.Read())
                {
                    dtGridDocumentos = (DataTable)ViewState["Documentos"];
                    dtGridDocumentos.Rows.Add(dr["NombreTipoSoporte"].ToString(), dr["TipoSoporteID"].ToString());
                    ViewState["Documentos"] = dtGridDocumentos;
                    this.BindGridDocumentos();
                }
                dr.Close();

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        private void CargarGridDocumentos()
        {
            if (dtGridDocumentos != null)
            {
                dtGridDocumentos.Clear();
            }
            DataTable dt = new DataTable();
            dt.Columns.AddRange(new DataColumn[2] { new DataColumn("NombreTipoSoporte"), new DataColumn("TipoSoporteID") });
            ViewState["Documentos"] = dt;
            this.BindGridDocumentos();
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
        private void CargarTipoAccion()
        {
            ddlAccionTramite.Items.Clear();
            ddlAccionTramite.Items.Add(new ListItem("--Seleccione el tipo de acción a tomar--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoAccion ORDER BY TipoAccionID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlAccionTramite.DataSource = cmd.ExecuteReader();
                    ddlAccionTramite.DataTextField = "NombreTipoAccion";
                    ddlAccionTramite.DataValueField = "TipoAccionID";
                    ddlAccionTramite.DataBind();
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

            strQuery = "SELECT TipoRemitidoID, NombreTipoRemitido FROM dbo.TipoRemitido WHERE(TipoRemitidoID > 1) ORDER BY TipoRemitidoID";

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
        private void CargarTipoInstruccion()
        {
            ddlInstruccion.Items.Clear();
            ddlInstruccion.Items.Add(new ListItem("--Seleccione la instrucción--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM TipoInstruccionSeguimiento ORDER BY TipoInstruccionSeguimientoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlInstruccion.DataSource = cmd.ExecuteReader();
                    ddlInstruccion.DataTextField = "NombreTipoInstruccionSeguimiento";
                    ddlInstruccion.DataValueField = "TipoInstruccionSeguimientoID";
                    ddlInstruccion.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarConsulta()
        {
            try
            {
                DataSet ds = ConsultarSolicitud.ObtenerSolicitudPorID(Convert.ToInt32(Session["SolicitudParaSeguimientoID"].ToString()));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void BindGrid()
        {
            grdSoporte.DataSource = (DataTable)ViewState["Soporte"];
            grdSoporte.DataBind();
        }
        protected void BindGridDocumentos()
        {
            grdDocumentos.DataSource = (DataTable)ViewState["Documentos"];
            grdDocumentos.DataBind();
        }
        private bool EsSoportePostuladoAgregado()
        {
            bool resultado = false;
            if (dtGrid != null)
            {
                for (int i = 0; i < dtGrid.Rows.Count; i++)
                {
                    DataRow dr = dtGrid.Rows[i];
                    if (dr["CedulaPostulante"].ToString() == txtCedulaPostulante.Text)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
        private bool EsSoporteDocumentoAgregado()
        {
            bool resultado = false;
            if (dtGridDocumentos != null)
            {
                for (int i = 0; i < dtGridDocumentos.Rows.Count; i++)
                {
                    DataRow dr = dtGridDocumentos.Rows[i];
                    if (dr["TipoSoporteID"].ToString() == ddlTipoSoporte.SelectedValue)
                    {
                        resultado = true;
                    }
                }
            }

            return resultado;
        }
        private void AgregarPostulante()
        {
            if(EsTodoCorrectoPostulante())
            {
                if (EsSoportePostuladoAgregado() == false)
                {
                    if (txtCedulaPostulante.Text != "")
                    {
                        if (EsSolicitanteEnsaime())
                        {
                            dtGrid = (DataTable)ViewState["Soporte"];
                            dtGrid.Rows.Add(txtCedulaPostulante.Text, nombreValidoPostulante, txtTelefonoPostulante.Text,"1");
                            ViewState["Soporte"] = dtGrid;
                            this.BindGrid();
                            grdSoporte.DataBind();
                            nombreValidoPostulante = string.Empty;
                            txtCedulaPostulante.Text = string.Empty;
                            txtTelefonoPostulante.Text = string.Empty;
                        }
                        else
                        {
                            messageBox.ShowMessage("Cedula no registrada en el SAIME");
                            nombreValidoPostulante = string.Empty;
                        }

                    }
                    else
                    {
                        messageBox.ShowMessage("Debe colocar la cedula del postulante");
                    }
                }
                else
                {
                    messageBox.ShowMessage("Ya agregó a la lista este postulante [" + txtCedulaPostulante.Text + "]");
                }
            }
        }
        private bool EsTodoCorrectoPostulante()
        {
            bool resultado = true;
            if(txtCedulaPostulante.Text == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe indicar el numero de cedula del postulado");
                return resultado;
            }
            if (txtTelefonoPostulante.Text == "")
            {
                resultado = false;
                messageBox.ShowMessage("Debe indicar el numero de telefono del postulado");
                return resultado;
            }
            if(SeguimientoOAC.EsPostuladoEnOtraSolicitud(Convert.ToInt32(Session["SolicitudParaSeguimientoID"]),Convert.ToInt32(txtCedulaPostulante.Text)))
            {
                resultado = false;
                messageBox.ShowMessage("Este postulado ya fue asignado a otra solicitud");
                return resultado;
            }
            return resultado;
        }

        private bool EsSolicitanteEnsaime()
        {
            bool resultado = false;
            int contador = 0;
            try
            {
                foreach (var saime in Saime.ObtenerDatosSaime(txtCedulaPostulante.Text))
                {
                    //Si ocurre algún error de conexión en la BD SAIME se sale de la busqueda
                    if (saime.Contains("ERROR "))
                    {
                        break;
                    }
                    switch (contador)
                    {
                        case 0:
                            contador = 1;
                            resultado = true;
                            break;
                        case 1:
                            nombreValidoPostulante = saime;
                            contador = 2;
                            resultado = true;
                            break;
                        case 2:
                            nombreValidoPostulante = nombreValidoPostulante + " " +  saime;
                            contador = 3;
                            resultado = true;
                            break;
                        case 3:
                            resultado = true;
                            break;
                        case 4:
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
        protected void btnAgregarPostulante_Click(object sender, EventArgs e)
        {
            AgregarPostulante();
        }

        protected void grdSoporte_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (Session["NombreGerenciaSeguimiento"].ToString() == "OAC")
            {
                for (int i = dtGrid.Rows.Count - 1; i >= 0; i--)
                {
                    DataRow dr = dtGrid.Rows[i];
                    if (dr["CedulaPostulante"].ToString() == e.CommandArgument.ToString())
                    {
                        dr.Delete();
                        ViewState["Soporte"] = dtGrid;
                        this.BindGrid();
                        grdSoporte.DataBind();
                    }
                }
            }
            else
            {
                messageBox.ShowMessage("Solo OAC puede eliminar postulados.");
            }

        }
    private void ProcesoSeguimientoOAC()
    {
            try
            {
                CSeguimientoOAC objetoSeguimientoOAC = new CSeguimientoOAC();
                objetoSeguimientoOAC.SolicitudID = Convert.ToInt32(Session["SolicitudParaSeguimientoID"]);
                objetoSeguimientoOAC.TipoAccionID = Convert.ToInt32(ddlAccionTramite.SelectedValue);
                objetoSeguimientoOAC.GerenciaID = Convert.ToInt32(ddlTipoRemitido.SelectedValue);
                objetoSeguimientoOAC.ObservacionSeguimiento = txtObservaciones.Text.ToUpper().Trim();
                objetoSeguimientoOAC.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);
                objetoSeguimientoOAC.TipoRemitidoID = ModuloGeneral.CodigoTipoRemitenteSegunNombre(Session["NombreGerenciaSeguimiento"].ToString());
                objetoSeguimientoOAC.TipoInstruccionSeguimientoID = Convert.ToInt32(ddlInstruccion.SelectedValue);

                //CAMBIAR ESTATUS A LA SOLICITUD AL NUMERO 2
                Seguimiento.ActualizarEstatusSolicitud(Convert.ToInt32(Session["SolicitudParaSeguimientoID"]));
                
                ActualizarDtgrid();
                if (SeguimientoOAC.InsertarSeguimiento(objetoSeguimientoOAC) > 0)
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo seguimiento a la solicitud: " + Convert.ToInt32(Session["SolicitudParaSeguimientoID"]) , System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    messageBox.ShowMessage("Registro actualizado");
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }


    }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoSeguimientoOAC();
        }

        protected void btnHistorial_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguimientoHistorial.aspx");
        }

        protected void grdDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            for (int i = dtGridDocumentos.Rows.Count - 1; i >= 0; i--)
            {
                DataRow dr = dtGridDocumentos.Rows[i];
                if (dr["TipoSoporteID"].ToString() == e.CommandArgument.ToString())
                {
                    dr.Delete();
                    ViewState["Documentos"] = dtGridDocumentos;
                    this.BindGridDocumentos();
                    grdDocumentos.DataBind();
                }
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            AgregarTipoSoporteFisico();
        }
        private void AgregarTipoSoporteFisico()
        {

            if (EsSoporteDocumentoAgregado() == false)
            {
                if (ddlTipoSoporte.SelectedValue != "")
                {
                    dtGridDocumentos = (DataTable)ViewState["Documentos"];
                    dtGridDocumentos.Rows.Add(ddlTipoSoporte.SelectedItem, ddlTipoSoporte.SelectedValue);
                    ViewState["Documentos"] = dtGridDocumentos;
                    this.BindGridDocumentos();
                    grdDocumentos.DataBind();
                }
                else
                {
                    messageBox.ShowMessage("Debe seleccionar de la lista un tipo de soporte");
                }
            }
            else
            {
                messageBox.ShowMessage("Ya agregó a la lista este tipo de documento [" + ddlTipoSoporte.SelectedItem + "]");
            }

        }
        private void ActualizarDtgrid()
        {
            int contador = 0;
            foreach (GridViewRow dr in grdSoporte.Rows)
            {
                
                int estatusID;
                estatusID = Utils.utils.ToInt(((DropDownList)dr.FindControl("ddlEstatus")).SelectedValue);
                DataRow r = dtGrid.Rows[contador];
                contador++;

                r["EstatusFichaSocialID"] = estatusID;
            }
        }

    }
}