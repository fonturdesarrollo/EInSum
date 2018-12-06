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
    public partial class EntregaCierreOperativo : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarJornadaAbierta();
            }
        }
        private void CargarJornadaAbierta()
        {
            ddlEntregaInsumoJornada.Items.Clear();
            ddlEntregaInsumoJornada.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione la jornada--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From DetalleEntregaInsumo  Where EstatusEntregaInsumo ='Abierta'";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEntregaInsumoJornada.DataSource = cmd.ExecuteReader();
                    ddlEntregaInsumoJornada.DataTextField = "NombreDeJornada";
                    ddlEntregaInsumoJornada.DataValueField = "EntregaInsumoID";
                    ddlEntregaInsumoJornada.DataBind();
                    con.Close();
                }
            }
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if(ddlEntregaInsumoJornada.SelectedValue !="")
            {
                
                EntregaInsumoJornada.CerrarJornadaEntregaInsumo(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue),Convert.ToInt32(Session["UserId"]));
                CargarJornadaAbierta();
                messageBox.ShowMessage("Operativo cerrado");
            }
            else
            {
                messageBox.ShowMessage("Debe seleccionar la jornada a cerrar");
            }
            
        }
    }
}