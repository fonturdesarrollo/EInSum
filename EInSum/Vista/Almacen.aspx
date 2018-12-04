<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Almacen.aspx.cs" Inherits="Eisum.Almacen" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
    <head>
        <title>Eisum | Almacén</title>
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
                                    <a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Almacén"></asp:Label></strong></a>
                                </header>
                            <!-- Content -->
                            <form runat ="server" id ="principal">
                                <section>
                                    <p></p>
                                        <div class="row uniform">
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtNombreAlmacen" MaxLength="50" placeholder="Nombre del almacén"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidatxtNombreAlmacen" runat="server" errormessage="Debe colocar el nombre del almacén" controltovalidate="txtNombreAlmacen" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddEstado" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
                                                    <ASP:RequiredFieldValidator id="rqrvalidaEstado" runat="server" errormessage="Debe colocar el estado" controltovalidate="ddEstado" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtDireccionAlmacen" MaxLength="150" TextMode="MultiLine" Rows="2"  placeholder ="Dirección del almacén"  />
                                                <ASP:RequiredFieldValidator id="rqrValidatxtDireccionAlmacen" runat="server" errormessage="Debe colocar la dirección del almacén" controltovalidate="txtDireccionAlmacen"  display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="12u$">
                                                <ul class="actions">
                                                    <li><asp:Button Text="Registrar almacén" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick ="btnGuardar_Click"/></li>
                                                    <li><asp:Button Text="Nuevo Registro" runat="server" ID ="btnNuevo" CausesValidation="False"  /></li>
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
														            <asp:Label runat="server" ID="lblNombreEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
													            </ItemTemplate>
												            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Nombre Jornada" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreAlmacen" Text='<%# Eval("NombreAlmacen") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Estado" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblDireccionAlmacen" Text='<%# Eval("DireccionAlmacen") %>'  ></asp:Label>
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

