using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Eisum
{
    public partial class MarcaVehiculo : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarMarcas();
            }
        }
        private void CargarMarcas()
        {
            try
            {
                DataSet ds = MarcaVehiculo.ObtenerMarcas();
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
            ProcesoInsertar();
        }
        private void ActualizarLista()
        {
            try
            {
                int contadorRegistros = 0;
                List<CMarcaModeloVehiculo> objetoLista = new List<CMarcaModeloVehiculo>();
                string sResultado = ValidarDatos(ref objetoLista);
                foreach (CMarcaModeloVehiculo prod in objetoLista)
                {
                    contadorRegistros = contadorRegistros + 1;
                    MarcaVehiculo.InsertarMarcaVehiculo(prod);

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
        private string ValidarDatos(ref List<CMarcaModeloVehiculo> objetoAsignarEstatus)
        {
            try
            {
                string sResultado = "";
                CMarcaModeloVehiculo objetoAsignaEstatus = null;
                int j = 1;
                foreach (GridViewRow dr in this.gridDetalle.Rows)
                {
                    objetoAsignaEstatus = new CMarcaModeloVehiculo();
                    objetoAsignaEstatus.MarcaVehiculoID = Utils.utils.ToInt(((Label)dr.FindControl("lblMarcaID")).Text);
                    objetoAsignaEstatus.NombreMarcaVehiculo = Utils.utils.ToString(((TextBox)dr.FindControl("txtNombreMarca")).Text);
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
        private void ProcesoInsertar()
        {
            CMarcaModeloVehiculo objetoMMVehiculo = new CMarcaModeloVehiculo();
            objetoMMVehiculo.MarcaVehiculoID = 0;
            objetoMMVehiculo.NombreMarcaVehiculo = txtMarca.Text.ToUpper().Trim();

            if(MarcaVehiculo.InsertarMarcaVehiculo(objetoMMVehiculo) >0)
            {
                messageBox.ShowMessage("Registro insertado");
                CargarMarcas();
                txtMarca.Text = string.Empty;
            }
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    MarcaVehiculo.EliminarMarcaVehiculo(Convert.ToInt32(e.CommandArgument.ToString()));
                    messageBox.ShowMessage("Marca eliminada.");
                    CargarMarcas();
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
    }
}