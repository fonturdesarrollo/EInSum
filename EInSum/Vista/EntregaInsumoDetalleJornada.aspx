<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregaInsumoDetalleJornada.aspx.cs" Inherits="Eisum.EntregaInsumoDetalleJornada" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
    <head>
        <title>Eisum | Cargar Entrega de Insumos</title>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>

        <link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
        <script src="../assets/js/jquery.min.js"></script>
        <link rel="stylesheet" href="../assets/css/main.css" />
        <link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
        <script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>
        <script  src="../js/jquery-ui-1.8rc3.custom.min.js"></script>
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <script src="../assets/js/main.js"></script>      
<%--------------------------%>
    
      <script type = "text/javascript">

          function Confirmacion() {

              return confirm("¿Realmente desea eliminar este registro?, no podrá deshacer");
          }
		</script>
         <script type="text/javascript">
		        $(function () {
		            $('#txtCantidad').keydown(function (e) {
		        if (e.shiftKey || e.ctrlKey || e.altKey) {
		        e.preventDefault();
		        } else {
		        var key = e.keyCode;
		        if (!((key == 8) || (key == 46) || (key >= 35 && key <= 40) || (key >= 48 && key <= 57) || (key >= 96 && key <= 105))) {
		        e.preventDefault();
		        }
		        }
		        });
	        });
        </script>
    </head>
    <body>
        <MsgBox:UCMessageBox ID="messageBox" runat="server" ></MsgBox:UCMessageBox>
        <!-- Wrapper -->
            <div id="wrapper">

                <!-- Main -->
                    <div id="main">
                        <div class="inner">
                            <!-- Header -->
                                <header id="header">
                                    <a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Cargar Entrega de Insumos"></asp:Label></strong></a>
                                </header>
                            <!-- Content -->
                            <form runat ="server" id ="principal">
                                <section>
                                    <p></p>
                                        <div class="row uniform">
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlEntregaInsumoJornada" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlEntregaInsumoJornada_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>      
                                                    <ASP:RequiredFieldValidator id="RqrValidaJornada" runat="server" errormessage="Debe seleccionar la jornada" controltovalidate="ddlEntregaInsumoJornada" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtPlaca"   MaxLength="7" placeholder="Placa vehículo"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidaPlaca" runat="server" errormessage="Debe colocar la placa" controltovalidate="txtPlaca" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlTipoInsumo" runat="server" AppendDataBoundItems="true"   OnSelectedIndexChanged="ddlTipoInsumo_SelectedIndexChanged" AutoPostBack ="true">
                                                        <asp:ListItem Text = "Seleccione el insumo" Value = "0"></asp:ListItem>  
                                                    </asp:DropDownList>
                                                    <ASP:RequiredFieldValidator id="rqrvalidaTipoInsumo" runat="server" errormessage="Debe seleccionar el tipo de insumo"  controltovalidate="ddlTipoInsumo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
												    <asp:DropDownList ID="ddlTipoInsumoDetalle" runat="server" AppendDataBoundItems="true" >
													    <asp:ListItem Text = "Seleccione detalle de insumo" Value = "0"></asp:ListItem>
												    </asp:DropDownList>
                                                    <ASP:RequiredFieldValidator id="rqrvalidaTipoInsumoDetalle" runat="server" errormessage="Debe seleccionar el detalle del tipo de insumo" controltovalidate="ddlTipoInsumoDetalle" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>

                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlUnidadMedida" runat="server" AppendDataBoundItems="true">
                                                        <asp:ListItem Text = "Seleccione la unidad de medida" Value = "0"></asp:ListItem>
                                                    </asp:DropDownList> 
                                                    <ASP:RequiredFieldValidator id="rqrvalidaUM" runat="server" errormessage="Debe seleccionar la unidad de medida" controltovalidate="ddlUnidadMedida" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtCantidad"   MaxLength="5" placeholder="Cantidad a entregar"  />
                                                <ASP:RequiredFieldValidator id="rqrtxtCantidad" runat="server" errormessage="Debe colocar la cantidad a entregar" controltovalidate="txtCantidad" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="12u$">
                                                <ul class="actions">
                                                    <li><asp:Button Text="Asignar insumo a unidad" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick ="btnGuardar_Click"   /></li>
                                                    <%--<li><asp:Button Text="Nuevo Registro" runat="server" ID ="btnNuevo" CausesValidation="False"  /></li>--%>
                                                    <li><asp:Button Text="Imprimir" runat="server" ID ="btnExportarExcel" CausesValidation="False"  OnClick="btnExportarExcel_Click" /></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </section>
								    <div class="table-wrapper">
									    <%--<asp:Label runat ="server" ID ="Label1" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>--%>
									    <p></p>
										    <asp:GridView ID="gridDetalle" runat="server" 
											    CssClass="subtitulo" 
											    EmptyDataText="No existen Registros" 
											    GridLines="Horizontal" 
											    AutoGenerateColumns="False"  OnRowCommand="gridDetalle_RowCommand" >
											    <HeaderStyle  Font-Size="10px" />
											    <AlternatingRowStyle Font-Size="10px"  />
												    <RowStyle  Font-Size="10px" />
												    <Columns>
												    <asp:TemplateField HeaderText="Fecha">
													    <ItemTemplate>
														    <asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCorta") %>'  ></asp:Label>
													    </ItemTemplate>
												    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Organización" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblNombreOrganizacion" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Cedula Beneficiario" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblCedulaBeneficiario" Text='<%# Eval("CedulaBeneficiario") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Nombre Beneficiario" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblNombreBeneficiario" Text='<%# Eval("NombreBeneficiario") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Marca" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblMarca" Text='<%# Eval("NombreMarcaVehiculo") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Placa" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblPlaca" Text='<%# Eval("Placa") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Tipo Insumo" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblNombreTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Detalle Insumo" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblNombreTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Cantidad" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("CantidadEntregaInsumo") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="U/M" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lblUM" Text='<%# Eval("NombreUnidadMedida") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
											    <asp:TemplateField HeaderText="Estatus Entrega" >
												    <ItemTemplate>
													    <asp:Label runat="server" ID="lbEtatusEntrega" Text='<%# Eval("EstatusEntregaInsumoDetalle") %>'  ></asp:Label>
												    </ItemTemplate>
											    </asp:TemplateField>
												<asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
													<ItemTemplate>
                                                    <asp:ImageButton runat="server" ID="btnEliminarRegistro"  AlternateText="Eliminar Registro" ToolTip="Eliminar Registro" OnClientClick="return Confirmacion();" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("EntregaInsumoDetalleID") %>'  CausesValidation ="false"/> 
													</ItemTemplate>
												</asp:TemplateField>
										</Columns>
								</asp:GridView>
								
						   </form>
                            </div>
						</div>
					</div>                   
                <!-- Sidebar -->
<%--					<div id="sidebar">
                        <div class="inner">--%>
                            <!-- Menu -->
                                <uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
<%--						</div>
                    </div>--%>
            </div>
    </body>
</html>

