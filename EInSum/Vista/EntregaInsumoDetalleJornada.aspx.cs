using iTextSharp.text;
using iTextSharp.text.pdf;
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


namespace Eisum
{
    public partial class EntregaInsumoDetalleJornada : Seguridad.SeguridadAuditoria
    {
        protected new  void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarJornadaAbierta();
                CargarTipoInsumo();
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

        private void CargarTipoInsumo()
        {
            ddlTipoInsumo.Items.Clear();
            ddlTipoInsumo.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el tipo de insumo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            strQuery = "select * From TipoInsumo ORDER BY TipoInsumoID";

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlTipoInsumo.DataSource = cmd.ExecuteReader();
                    ddlTipoInsumo.DataTextField = "NombreTipoInsumo";
                    ddlTipoInsumo.DataValueField = "TipoInsumoID";
                    ddlTipoInsumo.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarTipoInsumoDetalle()
        {
            ddlTipoInsumoDetalle.Items.Clear();
            ddlTipoInsumoDetalle.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione el detalle del tipo de insumo--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            if (ddlTipoInsumo.SelectedValue != "")
            {
                strQuery = "select * From TipoInsumoDetalle Where TipoInsumoID = " + ddlTipoInsumo.SelectedValue + " Order By NombreTipoInsumoDetalle";

                using (SqlConnection con = new SqlConnection(strConnString))
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = strQuery;
                        cmd.Connection = con;
                        con.Open();
                        ddlTipoInsumoDetalle.DataSource = cmd.ExecuteReader();
                        ddlTipoInsumoDetalle.DataTextField = "NombreTipoInsumoDetalle";
                        ddlTipoInsumoDetalle.DataValueField = "TipoInsumoDetalleID";
                        ddlTipoInsumoDetalle.DataBind();
                        con.Close();
                    }
                }
            }

        }
        private void CargarUnidadMedida(int tipoInsumo)
        {
            ddlUnidadMedida.Items.Clear();
            ddlUnidadMedida.Items.Add(new System.Web.UI.WebControls.ListItem("--Seleccione la unidad de medida--", ""));
            String strConnString = ConfigurationManager
            .ConnectionStrings["CallCenterConnectionString"].ConnectionString;
            String strQuery = "";

            switch (tipoInsumo)
            {
                case 1:
                    strQuery = "select * From UnidadMedida WHERE UnidadMedidaID = 1";
                    break;
                case 2:
                    strQuery = "select * From UnidadMedida WHERE UnidadMedidaID = 1";
                    break;
                case 3:
                    strQuery = "select * From UnidadMedida WHERE UnidadMedidaID <> 1";
                    break;
                default:
                    break;
            }

            using (SqlConnection con = new SqlConnection(strConnString))
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = strQuery;
                    cmd.Connection = con;
                    con.Open();
                    ddlUnidadMedida.DataSource = cmd.ExecuteReader();
                    ddlUnidadMedida.DataTextField = "NombreUnidadMedida";
                    ddlUnidadMedida.DataValueField = "UnidadMedidaID";
                    ddlUnidadMedida.DataBind();
                    con.Close();
                }
            }
        }
        private void CargarDetalleEntregaInsumos()
        {
            try
            {
                DataSet ds = EntregaInsumoDetalleJornada.ObtenerDetalleEntregaJornada(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue),"",0);
                DataTable dt = ds.Tables[0];
                gridDetalle.DataSource = dt;
                gridDetalle.DataBind();
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
        protected void ddlTipoInsumo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarTipoInsumoDetalle();
            CargarUnidadMedida(Convert.ToInt32(ddlTipoInsumo.SelectedValue));
        }
        private void ProcesoIngresoInsumoDetalleJornada()
        {
            try
            {
                if (EsTodoCorrecto())
                {
                    CEntregaInsumoDetalleJornada objetoEntregaInsumoDetalleJornada = new CEntregaInsumoDetalleJornada();
                    objetoEntregaInsumoDetalleJornada.EntregaInsumoDetalleID = 0;
                    objetoEntregaInsumoDetalleJornada.EntregaInsumoID = Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue);
                    objetoEntregaInsumoDetalleJornada.Placa = txtPlaca.Text.ToUpper();
                    objetoEntregaInsumoDetalleJornada.TipoInsumoDetalleID = Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue);
                    objetoEntregaInsumoDetalleJornada.UnidadMedidaID = Convert.ToInt32(ddlUnidadMedida.SelectedValue);
                    objetoEntregaInsumoDetalleJornada.CantidadEntregaInsumo = Convert.ToInt32(txtCantidad.Text);
                    objetoEntregaInsumoDetalleJornada.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"]);

                    if (EntregaInsumoDetalleJornada.InsertarEntregaDetalleInsumoJornada(objetoEntregaInsumoDetalleJornada,Convert.ToInt32(Session["CodigoAlmacen"])) > 0)
                    {
                        AuditarMovimiento(HttpContext.Current.Request.Url.AbsolutePath, "Agregó insumo para jornada a la placa: " + txtPlaca.Text.ToUpper(), System.Net.Dns.GetHostEntry(Request.ServerVariables["REMOTE_HOST"]).HostName, Convert.ToInt32(this.Session["UserId"].ToString()));
                        messageBox.ShowMessage("Registro actualizado");
                        CargarDetalleEntregaInsumos();
                    }
                }
            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }

        }
        private bool EsTodoCorrecto()
        {
            bool resultado = true;
            if(ItemDisponible()== false)
            {
                resultado = false;
            }
            else if(AsignarVehiculos.EsPlacaAsignada(txtPlaca.Text) == false)
            {
                resultado = false;
                messageBox.ShowMessage("Esta placa no está asignada a ningún beneficiario");
            }
            else if(EsPlacaConInsumoAsignado() == true)
            {
                resultado = false;
                messageBox.ShowMessage("Esta placa ya tiene registrado este insumo");
            }
            return resultado;
        }
        private bool EsPlacaConInsumoAsignado()
        {
            bool resultado = false;
            SqlDataReader dr;
            dr = EntregaInsumoDetalleJornada.ObtenerPlacaConInsumoAsignado(txtPlaca.Text.ToUpper(), Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue));
            if(dr.HasRows)
            {
                while(dr.Read())
                {
                    resultado = true;
                }
            }
            dr.Close();
            return resultado;
        }
        private bool EsPlacaConInsumoEntregado(int entregaInsumoDetalleID)
        {
            bool resultado = false;
            SqlDataReader dr;
            dr = EntregaInsumoDetalleJornada.ObtenerPlacaConInsumoEntregado(entregaInsumoDetalleID);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    resultado = true;
                }
            }
            dr.Close();
            return resultado;
        }
        protected void ddlEntregaInsumoJornada_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlEntregaInsumoJornada.SelectedValue !="")
            {
                SqlDataReader dr;
                dr = EntregaInsumoJornada.ObtenerCodigoAlmacenPorJornada(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue));
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        Session["CodigoAlmacen"] = dr["AlmacenID"];
                    }
                }
                dr.Close();
                CargarDetalleEntregaInsumos();
            }
        }
        private bool ItemDisponible()
        {
            bool resultado = true;
            int totalItems = 0;
            int codigoAlmacen = 0;
            if (Session["CodigoAlmacen"] != null)
            {
                codigoAlmacen = Convert.ToInt32(Session["CodigoAlmacen"]);
            }
            SqlDataReader dr;
            dr = EntregaInsumoJornada.ObtenerTotalItemAlmacenEntregaInsumoJornada(codigoAlmacen, Convert.ToInt32(ddlTipoInsumoDetalle.SelectedValue));
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    totalItems += Convert.ToInt32(dr["TotalDisponible"]);
                }
                if (Convert.ToInt32(txtCantidad.Text) > totalItems)
                {
                    resultado = false;
                    messageBox.ShowMessage("La cantidad a asignar supera la cantidad en el inventario para este item en el almacén");
                }
            }
            else
            {
                resultado = false;
                messageBox.ShowMessage("No existe inventario para este item en el almacén");
            }
            return resultado;
        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            ProcesoIngresoInsumoDetalleJornada();
        }

        protected void gridDetalle_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "EliminarDetalle")
                {
                    if (EsPlacaConInsumoEntregado(Convert.ToInt32(e.CommandArgument.ToString())) == false)
                    {
                        EntregaInsumoJornada.EliminarVehiculoAsignadoJornada(Convert.ToInt32(e.CommandArgument.ToString()));
                        messageBox.ShowMessage("Vehículo eliminado.");
                        CargarDetalleEntregaInsumos();
                    }
                    else
                    {
                        messageBox.ShowMessage("No puede eliminar este registro, ya tiene insumo entregado");
                    }
                }
            }
            catch (Exception ex)
            {
                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }

        protected void btnExportarExcel_Click(object sender, EventArgs e)
        {

            try
            {
                string nombreOrganizacion = "";
                string estado = "";
                int totalRegistros = 0;
                int totalPlacasPorOrganizacion = 0;
                if (ddlEntregaInsumoJornada.SelectedValue != "")
                {
                    DataSet dsTotal = EntregaInsumoDetalleJornada.ObtenerDetalleEntregaJornada(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue), "", 0);
                    totalRegistros = dsTotal.Tables[0].Rows.Count;
                    dsTotal.Dispose();

                    DataSet dsOrg = EntregaInsumoDetalleJornada.ObtenerDetalleEntregaJornadaOrganizacion(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue));
                    DataTableReader drOrg = dsOrg.Tables[0].CreateDataReader();

                    // Create a Document object
                    Document document = new Document(PageSize.A4, 88f, 88f, 10f, 10f);

                    // Create a new PdfWrite object, writing the output to a MemoryStream
                    var output = new MemoryStream();
                    var writer = PdfWriter.GetInstance(document, output);

                    // Open the Document for writing
                    document.Open();

                    var titleFont = FontFactory.GetFont("Arial", 18, iTextSharp.text.Font.BOLD);
                    var subTitleFont = FontFactory.GetFont("Arial", 12, iTextSharp.text.Font.BOLD);
                    var boldTableFont = FontFactory.GetFont("Arial", 6, iTextSharp.text.Font.BOLD);
                    var endingMessageFont = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.ITALIC);
                    var bodyFont = FontFactory.GetFont("Arial", 8, iTextSharp.text.Font.NORMAL);


                    while (drOrg.Read())
                    {
                            var logo = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/LogoFonturChiquito.png"));
                            logo.SetAbsolutePosition(510, 770);
                            logo.ScaleAbsolute(60f, 60f);
                            document.Add(logo);
                            nombreOrganizacion = drOrg["RifOrganizacion"].ToString() + " " + drOrg["NombreOrganizacion"].ToString();
                            estado = drOrg["NombreEstado"].ToString();
                           // totalRegistros = dsOrg.Tables[0].Rows.Count;

                            document.Add(new Paragraph("Lista de Beneficiarios Entrega de Insumos", titleFont));

                            document.Add(new Paragraph("Organización: " + nombreOrganizacion, bodyFont));
                            document.Add(new Paragraph("Estado: " + estado, bodyFont));

                            var endingMessage = new Paragraph("Reporte impreso por: " + Session["NombreCompletoUsuario"] + " el día:  " + System.DateTime.Now, bodyFont);

                            document.Add(endingMessage);
                            document.Add(Chunk.NEWLINE);

                            // Add the "Items In Your Order" subtitle
                            document.Add(new Paragraph("Beneficiados", subTitleFont));

                            // Create the Order Details table
                            var orderDetailsTable = new PdfPTable(9);
                            orderDetailsTable.HorizontalAlignment = 0;
                            orderDetailsTable.SpacingBefore = 10;
                            orderDetailsTable.SpacingAfter = 35;
                            orderDetailsTable.DefaultCell.Border = 0;
                            orderDetailsTable.TotalWidth = 500f;
                            orderDetailsTable.LockedWidth = true;
                            float[] widths = new float[] { 35f, 50f, 35f, 50f, 60f, 50f, 50f, 50f, 45f };
                            orderDetailsTable.SetWidths(widths);
                            orderDetailsTable.AddCell(new Phrase("Cedula", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Transportista", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Placa", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Marca", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Insumo", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Tipo", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Cantidad", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("U/M", boldTableFont));
                            orderDetailsTable.AddCell(new Phrase("Estatus", boldTableFont));

                            DataSet dsPlaca = EntregaInsumoDetalleJornada.ObtenerDetalleEntregaJornada(Convert.ToInt32(ddlEntregaInsumoJornada.SelectedValue), "",Convert.ToInt32(drOrg["OrganizacionID"]));
                            totalPlacasPorOrganizacion = dsPlaca.Tables[0].Rows.Count;
                            DataTableReader drPlaca = dsPlaca.Tables[0].CreateDataReader();
                            while (drPlaca.Read())
                            {

                                orderDetailsTable.AddCell(new Phrase(drPlaca["CedulaBeneficiario"].ToString(), FontFactory.GetFont("Arial", 5, iTextSharp.text.Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["NombreBeneficiario"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["Placa"].ToString(), FontFactory.GetFont("Arial", 5, iTextSharp.text.Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["NombreMarcaVehiculo"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["NombreTipoInsumo"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["NombreTipoInsumoDetalle"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["CantidadEntregaInsumo"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["NombreUnidadMedida"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                                orderDetailsTable.AddCell(new Phrase(drPlaca["EstatusEntregaInsumoDetalle"].ToString(), FontFactory.GetFont("Arial", 5, Font.BOLD)));
                            }
                        
                            document.Add(orderDetailsTable);
                            drPlaca.Close();
                            document.Add(Chunk.NEWLINE);
                            var totalPlacas = new Paragraph("Total unidades en operativo por organización: " + totalPlacasPorOrganizacion, endingMessageFont);
                            totalPlacas.SetAlignment("Right");
                            document.Add(totalPlacas);
                            document.Add(Chunk.NEWLINE);
                            document.Add(Chunk.NEWLINE);
                            document.NewPage();
                    }
                    // Add ending message
                    var logoFin = iTextSharp.text.Image.GetInstance(Server.MapPath("~/Images/LogoFonturChiquito.png"));
                    logoFin.SetAbsolutePosition(510, 770);
                    logoFin.ScaleAbsolute(60f, 60f);
                    document.Add(logoFin);

                    document.Add(new Paragraph("Lista de Beneficiarios Entrega de Insumos", titleFont));

                    document.Add(new Paragraph("Operativo: " + ddlEntregaInsumoJornada.SelectedItem, bodyFont));

                    var endMessage = new Paragraph("Reporte impreso por: " + Session["NombreCompletoUsuario"] + " el día:  " + System.DateTime.Now, bodyFont);
                    document.Add(endMessage);
                    document.Add(Chunk.NEWLINE);

                    var totalMessage = new Paragraph("Cantidad total de unidades en operativo: " + totalRegistros, endingMessageFont);
                    totalMessage.SetAlignment("Center");
                    document.Add(totalMessage);

                    document.Close();
                    Response.ContentType = "application/pdf";
                    Response.AddHeader("Content-Disposition", string.Format("attachment;filename=BeneficiariosInsumos-{0}.pdf", ""));
                    Response.BinaryWrite(output.ToArray());
                    drOrg.Close();
                }
                else
                {
                    messageBox.ShowMessage("Debe seleccionar la jornada");
                }

            }
            catch (Exception ex)
            {

                messageBox.ShowMessage(ex.Message + ex.StackTrace);
            }
        }
    }
}