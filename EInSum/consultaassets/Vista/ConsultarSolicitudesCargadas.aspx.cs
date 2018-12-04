using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Atensoli
{
    public partial class ConsultarSolicitudesCargadas : Seguridad.SeguridadAuditoria
    {
        protected new void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarSolicitudes();
            }
        }
        private void CargarSolicitudes()
        {
            try
            {
                string fechaSolicitud = "";
                if(chkDelDia.Checked == true)
                {
                    fechaSolicitud = DateTime.Now.ToString("dd/MM/yyyy");
                }
                DataSet ds = ConsultarSolicitud.ObtenerSolicitudesCargadas(fechaSolicitud);
                this.gridDetalle.DataSource = ds.Tables[0];
                this.gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void ExportToExcel(object sender, EventArgs e)
        {
            string nombreArchivo;
            if (chkDelDia.Checked == true)
            {
                nombreArchivo = "SolicitantesAtendidosElDia" + System.DateTime.Now.ToString("dd-MM-yyyy") + ".xls";
            }
            else
            {
                nombreArchivo = "SolicitantesAtendidosTodos" + ".xls";
            }
            
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + nombreArchivo);
            Response.Charset = "";
            Response.ContentType = "application/vnd.ms-excel";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                this.gridDetalle.AllowPaging = false;
                CargarSolicitudes();

                gridDetalle.HeaderRow.BackColor = Color.White;
                foreach (TableCell cell in gridDetalle.HeaderRow.Cells)
                {
                    cell.BackColor = gridDetalle.HeaderStyle.BackColor;
                }
                foreach (GridViewRow row in gridDetalle.Rows)
                {
                    row.BackColor = Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = gridDetalle.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = gridDetalle.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                gridDetalle.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();
                AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Exportó a excel movimientos de solictudes", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
            }
        }
        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }
        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarSolicitudes();
            AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Consultó movimientos de solictudes", System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
        }

        protected void btnExportar_Click(object sender, EventArgs e)
        {

        }
    }
}