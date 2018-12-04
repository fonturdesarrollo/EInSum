using Seguridad.Clases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Seguridad
{
    public partial class Seguridad : SeguridadAuditoria
    {
        protected  new void Page_Load(object sender, EventArgs e)
        {
            if (SeguridadUsuario.EsUsuarioPermitido(Session, 17) == false)
            {
                Response.Redirect("/Index.aspx");
            }
            EstablecerObjetos();
        }
        private void EstablecerObjetos()
        {
            CSeguridad objetoSeguridad = new CSeguridad();
            objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserID"]);
            if (objetoSeguridad.EsUsuarioAdministrador() == true)
            {
                btnAgregarGrupo.Visible = true;
                btnAgregarObjeto.Visible = true;
                btmAgregarGrupoObjeto.Visible = true;
                btnAgregarEmpresa.Visible = true;
                btnAgregarSucrusal.Visible = true;
                lblOpcionesEmpresa.Visible = true;
                lblOpcionesSeguridad.Visible = true;
            }
            else
            {
                btnAgregarGrupo.Visible = false;
                btnAgregarObjeto.Visible = false;
                btmAgregarGrupoObjeto.Visible = false;
                btnAgregarEmpresa.Visible = false;
                btnAgregarSucrusal.Visible = false;
                lblOpcionesEmpresa.Visible = false;
                lblOpcionesSeguridad.Visible = false;
            }
        }
        protected void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadUsuario.aspx");
        }

        protected void btnAgregarGrupo_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadGrupo.aspx");
        }

        protected void btnAgregarObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjeto.aspx");
        }

        protected void btmAgregarGrupoObjeto_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadObjetoGrupo.aspx");
        }

        protected void btnAgregarEmpresa_Click(object sender, EventArgs e)
        {
            Response.Redirect("Empresa.aspx");
        }

        protected void btnAuditoria_Click(object sender, EventArgs e)
        {
            Response.Redirect("SeguridadVistaAuditoria.aspx");
        }

        protected void btnAgregarSucrusal_Click(object sender, EventArgs e)
        {
            Response.Redirect("EmpresaSucursal.aspx");
        }
    }
}