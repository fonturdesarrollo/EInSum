using Seguridad;
using Seguridad.Clases;
using System;

namespace Seguridad
{
    public partial class SeguridadCambiarClave : SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session,999) == false)
            {
                Response.Redirect("/Index.aspx");
            }
        }
        private void ActualizarClave()
        {
            try
            {
                if (this.Session["ClaveUsuario"].ToString() == this.txtClaveAnterior.Text)
                {
                    CSeguridad objetoSeguridad = new CSeguridad();
                    objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(this.Session["UserId"].ToString());
                    objetoSeguridad.ClaveUsuario = this.txtClaveNueva.Text.ToString();
                    if (SeguridadCambiarClave.CambiarClave(objetoSeguridad) > 0)
                    {
                        messageBox.ShowMessage("La clave se cambió correctamente");
                        LimpiarPantalla();
                    }
                }
                else
                {
                    messageBox.ShowMessage("La clave anterior no coincide");
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void LimpiarPantalla()
        {
            this.Session["ClaveUsuario"] = this.txtClaveNueva.Text;
            this.txtClaveAnterior.Text = "";
            this.txtClaveNueva.Text = "";
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ActualizarClave();
        }
    }
}