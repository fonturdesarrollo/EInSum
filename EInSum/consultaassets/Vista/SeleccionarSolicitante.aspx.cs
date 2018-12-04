using System;
using System.Collections.Generic;
using System.Linq;

namespace Atensoli.Vista
{
    public partial class SeleccionarSolicitante : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LimpiarVariablesSession();
            }
        }
        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            SiguientePaso();
        }
        private void SiguientePaso()
        {
            if (EsSolicitanteValido())
            {
                Response.Redirect("Solicitante.aspx");
             }
            else
            {
                messageBox.ShowMessage("El número de cedula no corresponde a alguien válido.");
            }
            //Response.Redirect("EnConstruccion.aspx?" + "Cedula=" + hdnCedulaSolicitante.Value + "&Nombre="+ hdnNombreSolicitante.Value + "&ID=" + hdnSolicitanteID.Value, true);
        }
        private bool EsSolicitanteValido()
        {
            int codigoSolicitanteRegistrado = 0;
            LimpiarVariablesSession();
            bool resultado = false;

            //Paso 1
            //Verificar que la cedula este registrada en el sistema
            codigoSolicitanteRegistrado = Solicitante.CodigoSolicitanteRegistrado(txtCedula.Text);
            if (codigoSolicitanteRegistrado > 0)
            {
                Session["SolicitanteID"] = codigoSolicitanteRegistrado;
                resultado = true;
            }
            //Paso 2
            //Si no está registrado en el sistema, verificar que la cedula este registrada en el SAIME
            else
            {
                if(EsSolicitanteEnsaime())
                {
                    resultado = true;
                }
            }
            return resultado;
        }
        private bool EsSolicitanteEnsaime()
        {
            bool resultado = false;
            int contador = 0;
            LimpiarVariablesSession();
            try
            {
                foreach (var saime in Saime.ObtenerDatosSaime(txtCedula.Text))
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
                LimpiarVariablesSession();
                resultado = false;
            }
            return resultado;
        }
        private void LimpiarVariablesSession()
        {
            Session.Remove("SolicitanteID");
            Session.Remove("CedulaSaime");
            Session.Remove("NombreSaime");
            Session.Remove("ApellidoSaime");
            Session.Remove("SerialCarnetPatria");
        }
    }
}