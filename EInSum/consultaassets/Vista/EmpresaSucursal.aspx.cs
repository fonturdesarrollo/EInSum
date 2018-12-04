using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Atensoli
{
    public partial class EmpresaSucursal : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                CargarEmpresa();
                CargarEmpresaSucursal();
            }
        }
        private void CargarEmpresa()
        {
            ddlEmpresa.Items.Clear();
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From Empresa ORDER BY NombreEmpresa";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlEmpresa.DataSource = cmd.ExecuteReader();
                    ddlEmpresa.DataTextField = "NombreEmpresa";
                    ddlEmpresa.DataValueField = "EmpresaID";
                    ddlEmpresa.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarEmpresaSucursal()
        {
            try
            {
                DataSet ds = EmpresaSucursal.ObtenerSucursal(Convert.ToInt32(ddlEmpresa.SelectedValue));
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private void ProcesoSucursal()
        {
            CEmpresaSucursal objetoEmpresaSucursal = new CEmpresaSucursal();
            objetoEmpresaSucursal.EmpresaSucursalID = Convert.ToInt32(hdnEmpresaSucursalID.Value);
            objetoEmpresaSucursal.EmpresaID = Convert.ToInt32(ddlEmpresa.SelectedValue);
            objetoEmpresaSucursal.NombreSucursal = txtNombreSucursal.Text.ToUpper();
            objetoEmpresaSucursal.DireccionSucursal = txtDireccionSucursal.Text.ToUpper();
            objetoEmpresaSucursal.TelefonoSucursal = txtTelefonoSucursal.Text;

            EmpresaSucursal.InsertarEmpresaSucursal(objetoEmpresaSucursal);
            NuevoRegistro();
        }
        private void NuevoRegistro()
        {
            hdnEmpresaSucursalID.Value = "0";
            txtNombreSucursal.Text = string.Empty;
            txtDireccionSucursal.Text = string.Empty;
            txtTelefonoSucursal.Text = string.Empty;
            CargarEmpresaSucursal();
            txtNombreSucursal.Focus();
        }
        protected void btnAsignar_Click(object sender, EventArgs e)
        {
            ProcesoSucursal();
        }

        protected void btnNuevo_Click(object sender, EventArgs e)
        {
            NuevoRegistro();
        }

        protected void ddlEmpresa_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarEmpresaSucursal();
        }
    }
}