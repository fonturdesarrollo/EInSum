using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Cellper
{
    public partial class Empresa : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEmpresa();
                CargarEstatusEmpresa();
            }
        }
        public void CargarEmpresa()
        {
            try
            {
                DataSet ds = Empresa.ObtenerEmpresas(Convert.ToInt32(hdnEmpresaID.Value));
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        private void CargarEstatusEmpresa()
        {
            ddlEstatusEmpresa.Items.Clear();
            ddlEstatusEmpresa.Items.Add(new ListItem("--Seleccione el estatus--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "SELECT * FROM EstatusEmpresa   ORDER BY EstatusEmpresaID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEstatusEmpresa.DataSource = cmd.ExecuteReader();
                    ddlEstatusEmpresa.DataTextField = "NombreEstatusEmpresa";
                    ddlEstatusEmpresa.DataValueField = "EstatusEmpresaID";
                    ddlEstatusEmpresa.DataBind();
                    con.Close();
                }
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoActualizar();
        }

        protected void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarControles();
        }
        private void ProcesoActualizar()
        {
            try
            {
                if (EsTodoCorrecto() == true) 
                {
                    CEmpresa objetoEmpresa = new CEmpresa();
                    objetoEmpresa.EmpresaID = Convert.ToInt32(hdnEmpresaID.Value);
                    objetoEmpresa.RIFEmpresa = txtRif.Text.ToUpper();
                    objetoEmpresa.NombreEmpresa = txtNombreEmpresa.Text;
                    objetoEmpresa.DireccionEmpresa = txtDireccion.Text;
                    objetoEmpresa.TelefonoEmpresa = txtTelefono.Text;
                    objetoEmpresa.EMailEmpresa = txtEmail.Text;
                    objetoEmpresa.WebEmpresa = txtWeb.Text;
                    objetoEmpresa.TwitterEmpresa = txtTwitter.Text;
                    objetoEmpresa.InstagramEmpresa = txtInstagram.Text;
                    objetoEmpresa.FacebookEmpresa = txtFacebook.Text;
                    objetoEmpresa.LogoEmpresa = hdnRutaImagen.Value;
                    objetoEmpresa.EstatusEmpresaID = Convert.ToInt32(ddlEstatusEmpresa.SelectedValue);
                    if (Empresa.InsertarEmpresa(objetoEmpresa) > 0)
                    {
                        messageBox.ShowMessage("Registro actualizado.");
                        LimpiarControles();
                    }
                    else
                    {
                        messageBox.ShowMessage("Ocurrió un error, no se actualizaron los registros");
                    }
                }

            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message +  ex.StackTrace);
            }
        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            if (Convert.ToInt32(hdnEmpresaID.Value) == 0)
            {
                if (EsImagenCargada() == false)
                {
                    resultado = false;
                }
            }
            return resultado;
        }

        private bool EsImagenCargada()
        {
            bool resultado = false;
            if (FileUploadControl.HasFile)
            {
                try
                {
                    if (FileUploadControl.PostedFile.ContentType == "image/jpeg")
                    {
                        string filename = Path.GetFileName(FileUploadControl.FileName);
                        FileUploadControl.SaveAs(Server.MapPath("~/images/") + filename);
                        hdnRutaImagen.Value = "../images/" + filename;
                        resultado = true;
                    }
                    else
                    {
                        messageBox.ShowMessage("Solo puede cargar imagenes .JPG");
                    }

                }
                catch (Exception ex)
                {
                    hdnRutaImagen.Value = "";
                    messageBox.ShowMessage(ex.Message + ex.StackTrace);
                }
                
            }
            else
            {
                messageBox.ShowMessage("Debe agregar un logo a la empresa");
            }
            return resultado;
        }
        private void LimpiarControles()
        {
            txtRif.Text = "";
            txtNombreEmpresa.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            txtTelefono.Text = "";
            txtEmail.Text = "";
            txtWeb.Text = "";
            txtTwitter.Text = "";
            txtInstagram.Text = "";
            txtFacebook.Text = "";
            hdnEmpresaID.Value = "0";
            hdnRutaImagen.Value = "";
            txtRif.Focus();
            CargarEmpresa();
            CargarEstatusEmpresa();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    if (Empresa.EliminarEmpresa(Convert.ToInt32(e.CommandArgument.ToString())) > 0)
                    {
                        messageBox.ShowMessage("Empresa eliminada.");
                        LimpiarControles();
                    }
                    else
                    {
                        messageBox.ShowMessage("No se pudo eliminar el detalle. Intente nuevamente.");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}