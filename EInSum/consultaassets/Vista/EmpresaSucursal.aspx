<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EmpresaSucursal.aspx.cs" Inherits="Atensoli.EmpresaSucursal" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Seguridad | Sucursal</title>
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

		function Confirmacion() {

			return confirm("¿Realmente desea eliminar este servicio?");
		}

		$(function () {
			$('#txtNombreSucursal').simpleAutoComplete('Autocomplete.aspx', {
				autoCompleteClassName: 'autocomplete',
				selectedClassName: 'sel',
				attrCallBack: 'rel',
				identifier: 'EmpresaSucursal'
			}, fnPersonalCallBack);

		});

		function fnPersonalCallBack(par) {
			document.getElementById("hdnEmpresaSucursalID").value = par[0]; //par[0] id
			document.getElementById("txtNombreSucursal").value = par[1];
			document.getElementById("txtDireccionSucursal").value = par[3];
			document.getElementById("txtTelefonoSucursal").value = par[4];
			$("#ddlEmpresa").val(par[5]);
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
									<a class="logo"><strong>Sucursal</strong></a>
									<ul class="icons">

									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper" style="height: 19px">
													<asp:DropDownList ID="ddlEmpresa" runat="server"  AppendDataBoundItems="True" AutoPostBack = "true" OnSelectedIndexChanged="ddlEmpresa_SelectedIndexChanged"></asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat ="server" ID ="txtNombreSucursal" placeholder ="Nombre de la sucursal"></asp:TextBox>
												<asp:RequiredFieldValidator runat ="server" ID ="rqrValidaNombre" ControlToValidate="txtNombreSucursal" ErrorMessage="Debe colocar el nombre la sucrusal" Font-Bold ="true" ForeColor ="Red"></asp:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnEmpresaSucursalID"  Value="0"/>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat ="server" ID ="txtDireccionSucursal" placeholder ="Dirección de la sucursal"></asp:TextBox>
												<asp:RequiredFieldValidator runat ="server" ID ="rqrValidaDireccion" ControlToValidate="txtDireccionSucursal" ErrorMessage="Debe colocar la dirección de la sucursal" Font-Bold ="true" ForeColor ="Red"></asp:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat ="server" ID ="txtTelefonoSucursal" placeholder ="Telefono de la sucursal"></asp:TextBox>
												<asp:RequiredFieldValidator runat ="server" ID ="rqrValidaTelefono" ControlToValidate="txtTelefonoSucursal" ErrorMessage="Debe colocar el telefono de la sucursal" Font-Bold ="true" ForeColor ="Red"></asp:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Asignar sucursal" runat="server" ID ="btnAsignar"  CssClass ="special" OnClick="btnAsignar_Click" />
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo" CausesValidation="False" OnClick="btnNuevo_Click" /></li>
												</ul>
												<ul>

												</ul>
											</div>
									   </div>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" AutoGenerateColumns="False" >
														<HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
														<AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
														  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="Nombre de Sucursal">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreGrupo" Text='<%# Eval("NombreEmpresaSucursal") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Dirección">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblDesGrupo" Text='<%# Eval("DireccionSucursal") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Teléfono" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreObjeto" Text='<%# Eval("TelefonoSucursal") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
															  <ItemTemplate>
																  <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("EmpresaSucursalID") %>'/>
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
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
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>

