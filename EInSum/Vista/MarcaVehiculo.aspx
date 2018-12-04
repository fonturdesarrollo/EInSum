<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MarcaVehiculo.aspx.cs" Inherits="Eisum.MarcaVehiculo" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Agregar Marca</title>
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Agregar Marca"></asp:Label></strong></a>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">      
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtMarca"  MaxLength="50" placeholder ="Nombre Marca Vehículo"/>
												<ASP:RequiredFieldValidator id="rqrvalidaMarca" runat="server" errormessage="Debe colocar la marca del Vehiculo" controltovalidate="txtMarca" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick="btnGuardar_Click"  /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevoRegistro"   CausesValidation="False"  /></li>
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
											AutoGenerateColumns="False"  OnRowCommand="gridDetalle_RowCommand" >
											<HeaderStyle  Font-Size="10px" />
											<AlternatingRowStyle Font-Size="10px"  />
												<RowStyle  Font-Size="10px" />
												<Columns>
												<asp:TemplateField HeaderText="CodigoTabla" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblMarcaID" Text='<%# Eval("MarcaVehiculoID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Nombre Marca">
													<ItemTemplate>
														<asp:TextBox runat="server" ID="txtNombreMarca" Text='<%# Eval("NombreMarcaVehiculo") %>'  ></asp:TextBox>
													</ItemTemplate>
												</asp:TemplateField>
											    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
												    <ItemTemplate>
														    <asp:ImageButton runat="server" ID="btnActualizarModificacionGrid" AlternateText="Guardar cambios" ToolTip="Guardar cambios" ImageUrl="~/Images/Save_37110.png"  CommandName="GuardarCambiosGrid" CommandArgument='<%# Eval("MarcaVehiculoID") %>' CausesValidation ="false"/> 
														    <asp:ImageButton runat="server" ID="btnEliminarRegistro" AlternateText="Eliminar Registro" ToolTip="Eliminar Registro" OnClientClick="return Confirmacion();" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("MarcaVehiculoID") %>' CausesValidation ="false"/> 
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
