<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InventarioAsignacion.aspx.cs" Inherits="Eisum.InventarioAsignacion" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
    <head>
        <title>Eisum | Asignación Inventario</title>
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
                                    <a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Asignación de Insumos Almacén Externo"></asp:Label></strong></a>
                                </header>
                            <!-- Content -->
                            <form runat ="server" id ="principal">
                                <section>
                                    <p></p>
                                        <div class="row uniform">
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddAlmacenSecundario" runat="server" AppendDataBoundItems="true" AutoPostBack = "true"  OnSelectedIndexChanged ="ddAlmacenSecundario_SelectedIndexChanged"></asp:DropDownList>      
                                                </div>
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
												    <asp:DropDownList ID="ddlTipoInsumoDetalle" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlTipoInsumoDetalle_SelectedIndexChanged" AutoPostBack="true">
													    <asp:ListItem Text = "Seleccione detalle de insumo" Value = "0"></asp:ListItem>
												    </asp:DropDownList>
                                                    <ASP:RequiredFieldValidator id="rqrvalidaTipoInsumoDetalle" runat="server" errormessage="Debe seleccionar el detalle del tipo de insumo" controltovalidate="ddlTipoInsumoDetalle" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtCantidad"   MaxLength="5" placeholder="Cantidad"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidaCantidadEntrada" runat="server" errormessage="Debe colocar la cantidad a ingresar" controltovalidate="txtCantidad" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
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
                                                <asp:TextBox runat="server" ID="txtNumeroOrden"   MaxLength="50" placeholder="Número de orden / Observación"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidaNO" runat="server" errormessage="Debe colocar Número de orden / Observación" controltovalidate="txtNumeroOrden" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="12u$">
                                                <ul class="actions">
                                                    <li><asp:Button Text="Registrar Ingreso Almacén" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick="btnGuardar_Click"   /></li>
                                                    <li><asp:Button Text="Nuevo Registro" runat="server" ID ="btnNuevo" CausesValidation="False"   /></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </section>
								            <div class="table-wrapper">
									            <asp:Label runat ="server" ID ="Label1" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>
									            <p></p>
										            <asp:GridView ID="gridDetalle" runat="server" 
											            CssClass="subtitulo" 
											            EmptyDataText="No existen Registros" 
											            GridLines="Horizontal" 
											            AutoGenerateColumns="False" >
											            <HeaderStyle  Font-Size="10px" />
											            <AlternatingRowStyle Font-Size="10px" />
												            <RowStyle  Font-Size="10px" />
												            <Columns>
												            <asp:TemplateField HeaderText="Estado">
													            <ItemTemplate>
														            <asp:Label runat="server" ID="lblEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
													            </ItemTemplate>
												            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Almacén" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreAlmacen" Text='<%# Eval("NombreAlmacen") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Tipo de Insumo" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Unidad de Medida" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblUnidadMedida" Text='<%# Eval("NombreUnidadMedida") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Detalle Insumo" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Total Disponible" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("TotalDisponible") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
												</Columns>
										</asp:GridView>
								</div>
						   </form>
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

