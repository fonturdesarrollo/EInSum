using Seguridad.Clases;
using System;

namespace Seguridad
{
    public partial class SeguridadGrupo : System.Web.UI.Page
    {
        protected  void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["UserID"] == null)
            {
                Server.Transfer("Logout.aspx");
            }
            if (SeguridadUsuario.EsUsuarioPermitido(Session,18) == false)
            {
                Response.Redirect("/Index.aspx");
            }
        }
        private void ActualizarRegistros()
        {
                try
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadGrupoID = Convert.ToInt32(hdnSeguridadGrupoID.Value);
                    objetoSeguridad.NombreGrupo = this.txtNombre.Text.ToUpper();
                    objetoSeguridad.DescripcionGrupo = this.txtDescripcion.Text.ToUpper();
                    if (SeguridadGrupo.InsertarGrupo(objetoSeguridad) > 0)
                    {
                        messageBox.ShowMessage("El grupo se ingresó correctamente");
                        LimpiarPantalla();
                    }
                }
                catch (Exception)
                {

                    throw;
                }
        }

        private void LimpiarPantalla()
        {
            this.txtNombre.Text = "";
            this.txtDescripcion.Text = "";
            this.hdnSeguridadGrupoID.Value = "0";
            this.txtNombre.Focus();
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarRegistros();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            LimpiarPantalla();
        }
    }
}