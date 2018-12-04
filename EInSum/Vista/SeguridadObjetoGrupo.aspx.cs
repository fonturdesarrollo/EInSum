using Seguridad.Clases;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;


namespace Seguridad
{
    public partial class SeguridadObjetoGrupo : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserID"] == null)
            {
                Server.Transfer("Logout.aspx");
            }
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 20) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            if (!IsPostBack)
            {
                CargarGrupos();
                CargarObjetos();
            }
        }
        private void CargarGrupos()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from SeguridadGrupo";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlGrupo.DataSource = cmd.ExecuteReader();
                ddlGrupo.DataTextField = "NombreGrupo";
                ddlGrupo.DataValueField = "SeguridadGrupoID";
                ddlGrupo.DataBind();
                ddlGrupo.Items.Insert(0, new ListItem("--Seleccione el Grupo--", "0"));
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

        private void CargarObjetos()
        {
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "select * from SeguridadObjeto";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                ddlObjeto.DataSource = cmd.ExecuteReader();
                ddlObjeto.DataTextField = "NombreObjeto";
                ddlObjeto.DataValueField = "SeguridadObjetoID";
                ddlObjeto.DataBind();
                ddlObjeto.Items.Insert(0, new ListItem("--Seleccione el Objeto--", "0"));
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
        private void CargarGruposObjetos()
        {
            try
            {
                CSeguridad objetoSeguridad = new CSeguridad();
                objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(this.ddlGrupo.SelectedValue);
                DataSet ds = SeguridadObjetoGrupo.ObtenerObjetosDeGrupo(objetoSeguridad);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void AsignarObjetoGrupo()
        {
            if (EsTodoCorrecto()== true)
            {

                try
                {

                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(this.ddlGrupo.SelectedValue);
                    objetoSeguridad.SeguridadObjetoID = Convert.ToInt32(this.ddlObjeto.SelectedValue);
                    if (SeguridadObjetoGrupo.InsertarObjetoGrupo(objetoSeguridad) > 0)
                    {
                        CargarGruposObjetos();
                        messageBox.ShowMessage("Se asignó el objeto correctamente");
                    }

                }
                catch (Exception ex)
                {

                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
            }
        }
        private bool ObjetoAsignado()
        {
            try
            {
                DataSet ds = SeguridadObjetoGrupo.ObtenerObjetoGrupo(Convert.ToInt32(this.ddlGrupo.SelectedValue), Convert.ToInt32(this.ddlObjeto.SelectedValue));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
                return true;
            }
        }
        private bool EsTodoCorrecto()
        {
            bool esTodoCorrecto = true;
            if (this.ddlGrupo.SelectedValue == "0" || this.ddlObjeto.SelectedValue =="0")
            {
                esTodoCorrecto = false;
                messageBox.ShowMessage("Debe seleccionar todos los datos");
            }
            if(ObjetoAsignado() == true)
            {
                esTodoCorrecto = false;
                messageBox.ShowMessage("El objeto que esta asignando ya pertenece al grupo");
            }
            return esTodoCorrecto;
        }
        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                String SeguridadObjetoAccesoID = e.CommandArgument.ToString();
                if (e.CommandName == "EliminarDetalle")
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadObjetoAccesoID = Convert.ToInt32(SeguridadObjetoAccesoID);
                    SeguridadObjetoGrupo.EliminarObjetoGrupo(objetoSeguridad);
                    CargarGruposObjetos();
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);

            }
        }

        protected void ddlGrupo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarGruposObjetos();
        }

        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            AsignarObjetoGrupo();
        }
    }
}