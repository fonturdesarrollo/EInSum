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
    public partial class Almacen : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEstado();
                CargarAlmacenes();
            }
        }
        private void CargarEstado()
        {
            ddEstado.Items.Clear();
            ddEstado.Items.Add(new ListItem("--Seleccione el estado--", ""));
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
                    ddEstado.DataSource = cmd.ExecuteReader();
                    ddEstado.DataTextField = "NombreEstado";
                    ddEstado.DataValueField = "EstadoID";
                    ddEstado.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarAlmacenes()
        {
            try
            {

                DataSet ds = Almacen.ObtenerAlmacenes();
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoAlmacen();   
        }
        private void ProcesoAlmacen()
        {
            try
            {
                CAlmacen objetoAlmacen = new CAlmacen();
                objetoAlmacen.AlmacenID = 0;
                objetoAlmacen.NombreAlmacen = txtNombreAlmacen.Text.ToUpper();
                objetoAlmacen.EstadoID = Convert.ToInt32(ddEstado.SelectedValue);
                objetoAlmacen.DireccionAlmacen = txtDireccionAlmacen.Text.ToUpper();
                objetoAlmacen.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);

                if(Almacen.InsertarAlmacen(objetoAlmacen) >0)
                {
                    AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó nuevo almacén: " + txtNombreAlmacen.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                    messageBox.ShowMessage("Registro actualizado");
                    NuevoRegistro();
                }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void NuevoRegistro()
        {
            txtNombreAlmacen.Text = string.Empty;
            txtDireccionAlmacen.Text = string.Empty;
            CargarEstado();
            CargarAlmacenes();
        }
    }
}