<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Empresa.aspx.cs" Inherits="Cellper.Empresa" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Empresa</title>
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

	<script type="text/javascript">
				$(function () {
					$('#txtNombreEmpresa').simpleAutoComplete('Autocomplete.aspx', {
						autoCompleteClassName: 'autocomplete',
						selectedClassName: 'sel',
						attrCallBack: 'rel',
						identifier: 'Empresas'
					}, fnPersonalCallBack);

				});

				function fnPersonalCallBack(par) {
					document.getElementById("hdnEmpresaID").value = par[0];
					document.getElementById("txtRif").value = par[3];
					document.getElementById("txtNombreEmpresa").value = par[1];
					document.getElementById("txtDireccion").value = par[4];
					document.getElementById("txtTelefono").value = par[5];
					document.getElementById("txtEmail").value = par[6]; 
					document.getElementById("txtWeb").value = par[11];
					document.getElementById("txtTwitter").value = par[7];
					document.getElementById("txtInstagram").value = par[8];
					document.getElementById("txtFacebook").value = par[9];
					document.getElementById("hdnRutaImagen").value = par[10];
					document.getElementById("ddlEstatusEmpresa").value = par[12];

					var bt = document.getElementById("ButtonTest");
					bt.click();
				}

				function Confirmacion() {

					return confirm("¿Realmente desea eliminar esta empresa?, se borraran todas sus sucursales, usuarios, inventario y movimientos, este proceso no se podrá deshacer");
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
									<a class="logo"><strong>Agregar Empresa</strong></a>
									<ul class="icons">

									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRif"   onkeypress="return event.keyCode!=13;" MaxLength="20" placeholder="RIF" />
												<ASP:RequiredFieldValidator id="rqrValidaRif" runat="server" errormessage="Debe colocar el RIF" controltovalidate="txtRif" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnEmpresaID"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtNombreEmpresa"  MaxLength="150"  placeholder="Nombre Empresa" />
												<ASP:RequiredFieldValidator id="rqrValidaNombreEmpresa" runat="server" errormessage="Debe colocar el nombre de la empresa"  controltovalidate="txtNombreEmpresa" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtDireccion"  MaxLength="100"  placeholder ="Dirección"/>
												<ASP:RequiredFieldValidator id="rqrValidaDireccion" runat="server" errormessage="Debe colocar la dirección de la empresa"  controltovalidate="txtDireccion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefono"  MaxLength="100" placeholder ="Teléfono"/>
												<ASP:RequiredFieldValidator id="rqrValidaTelefono" runat="server" errormessage="Debe colocar el numéro de teléfono de la empresa"  controltovalidate="txtTelefono" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtEmail"  MaxLength="50" placeholder ="Correo Electronico"/>
												<ASP:RequiredFieldValidator id="rqrValidaEmail" runat="server" errormessage="Debe colocar el E-Mail"  controltovalidate="txtEmail" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtWeb"  MaxLength="100" placeholder ="Sitio Web"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTwitter"  MaxLength="100" placeholder ="Twitter"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtInstagram"  MaxLength="100" placeholder ="Instagram"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtFacebook"  MaxLength="100" placeholder ="Facebook"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlEstatusEmpresa" runat="server" AppendDataBoundItems="true"></asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrValidaEstatus" runat="server" errormessage="Debe seleccionar el estatus"  controltovalidate="ddlEstatusEmpresa" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat="server" ID="lblFile" Text ="Logo: "></asp:Label>
												<asp:FileUpload id="FileUploadControl" runat="server" />
												<asp:HiddenField runat ="server" ID ="hdnRutaImagen"  Value=""/> 
											</div>

											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"  /></li>
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnLimpiar"   CausesValidation="False" OnClick="btnLimpiar_Click"  /></li>
													<li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  CausesValidation="False"  /></li>
												</ul>
											</div>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" 
													  CssClass="subtitulo" 
													  EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" 
													  AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" 
													  
													   >
														<HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
														<AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
														  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="CodV" HeaderStyle-Width="0" Visible="false">
															  <ItemTemplate>
																  <asp:TextBox runat="server" ID="txtCodEmpresa" Visible ="false"   Width="0" ForeColor ="Red" Text='<%# Eval("EmpresaID") %>' ></asp:TextBox>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="RIF" HeaderStyle-Width="50">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRif" Text='<%# Eval("RIFEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Empresa" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreEmpresa" Text='<%# Eval("NombreEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
													 <asp:TemplateField HeaderText="Dirección" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblDireccion" Text='<%# Eval("DireccionEmpresa") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Teléfono" HeaderStyle-Width="80">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTelefono" Text='<%# Eval("TelefonoEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="E-Mail" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblEmail" Text='<%# Eval("EMailEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Sitio WEB" HeaderStyle-Width="120">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAsunto" Text='<%# Eval("WebEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Twitter" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTwitter" Text='<%# Eval("TwitterEmpresa") %>' ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Instagram " HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblInstagram" Text='<%# Eval("InstagramEmpresa") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Facebook" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFacebook" Text='<%# Eval("FacebookEmpresa") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Facebook" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblEstatus" Text='<%# Eval("NombreEstatusEmpresa") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Logo" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Image runat="server" ID="imgLogo"  ImageUrl ='<%# Eval("LogoEmpresa") %>' Width="50" Height="50"></asp:Image>
															  </ItemTemplate>   
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
															  <ItemTemplate>
																<asp:ImageButton runat="server" ID="btnEliminarRegistro" AlternateText="Eliminar"  OnClientClick="return Confirmacion();" ToolTip="Eliminar Registro" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("EmpresaID") %>' CausesValidation ="false"/> 
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
											</div>
										</div>
								</section>
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

<%------------------------------------------------------------------------------------------------------------------%>
	</body>
</html>
