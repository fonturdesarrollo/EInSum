<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ModeloVehiculo.aspx.cs" Inherits="Eisum.ModeloVehiculo" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Agregar Modelo</title>
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
<%---------------------------------%>


	  
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Agregar Modelo"></asp:Label></strong></a>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">      
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlMarcaVehiculo" runat="server" AppendDataBoundItems="true"  OnSelectedIndexChanged="ddlMarcaVehiculo_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>    
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtModelo"  MaxLength="50" placeholder ="Nombre Modelo Vehículo"/>
												<ASP:RequiredFieldValidator id="rqrvalidaModelo" runat="server" errormessage="Debe colocar el modelo del Vehiculo" controltovalidate="txtModelo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoVehiculo" runat="server" AppendDataBoundItems="true"></asp:DropDownList> 
													<ASP:RequiredFieldValidator id="rqrValidaipoVehiculo" runat="server" errormessage="Debe colocar el tipo de vehiculo" controltovalidate="ddlTipoVehiculo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>                                                         
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoCaucho" runat="server" AppendDataBoundItems="true"></asp:DropDownList> 
													<ASP:RequiredFieldValidator id="rqrValidaTipoCaucho" runat="server" errormessage="Debe colocar el tipo de caucho" controltovalidate="ddlTipoCaucho" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>                                                         
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCantidadCauchos"  MaxLength="3" placeholder ="Indique la cantidad de cauchos"/>
												<ASP:RequiredFieldValidator id="rqrValidaCantidadCauhos" runat="server" errormessage="Debe colocar la cantidad de cauchos" controltovalidate="txtCantidadCauchos" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoAceite" runat="server" AppendDataBoundItems="true"></asp:DropDownList> 
													<ASP:RequiredFieldValidator id="rqrValidaTipoAceite" runat="server" errormessage="Debe colocar el tipo de aceite" controltovalidate="ddlTipoAceite" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>                                                         
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtLitros"  MaxLength="3" placeholder ="Indique la cantidad de litros de aceite"/>
												<ASP:RequiredFieldValidator id="rqrValidaLitros" runat="server" errormessage="Debe colocar de litros de aceite" controltovalidate="txtLitros" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoBateria" runat="server" AppendDataBoundItems="true"></asp:DropDownList> 
													<ASP:RequiredFieldValidator id="rqrValidaTipoBateria" runat="server" errormessage="Debe colocar el tipo de bateria" controltovalidate="ddlTipoBateria" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>                                                         
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCapacidad"  MaxLength="3" placeholder ="Indique el número de puestos"/>
												<ASP:RequiredFieldValidator id="rarValidaCapacidad" runat="server" errormessage="Debe colocar el número de puestos" controltovalidate="txtCapacidad" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick="btnGuardar_Click"  /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevoRegistro"   CausesValidation="False"  OnClick="btnNuevoRegistro_Click" /></li>
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
											AutoGenerateColumns="False"  >
											<HeaderStyle  Font-Size="10px" />
											<AlternatingRowStyle Font-Size="15px"  />
												<RowStyle  Font-Size="15px" />
												<Columns>
												<asp:TemplateField HeaderText="CodigoModelo" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblModeloID" Text='<%# Eval("ModeloVehiculoID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="CodigoMarca" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblMarcaID" Text='<%# Eval("MarcaVehiculoID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Nombre Marca">
													<ItemTemplate>
														<asp:Label runat="server" ID="txtNombreMarcaGrid" Text='<%# Eval("NombreMarcaVehiculo") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Nombre Modelo">
													<ItemTemplate>
														<asp:Label runat="server" ID="txtNombreModeloGrid" Text='<%# Eval("NombreModeloVehiculo") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Tipo Vehiculo">
													<ItemTemplate>
														<asp:Label runat="server" ID="txTipoVehiculoGrid" Text='<%# Eval("NombreTipoVehiculo") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Tipo Caucho">
													<ItemTemplate>
														<asp:Label runat="server" ID="txTipoCauchoGrid" Text='<%# Eval("NombreTipoCaucho") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Cantidad Cauchos">
													<ItemTemplate>
														<asp:Label runat="server" ID="txCantidadCauchoGrid" Text='<%# Eval("CantidadCauchos") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Tipo Aceite">
													<ItemTemplate>
														<asp:Label runat="server" ID="txTipoAceiteGrid" Text='<%# Eval("NombreTipoAceite") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Litros">
													<ItemTemplate>
														<asp:Label runat="server" ID="txLitrosGrid" Text='<%# Eval("CantidadLitros") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Tipo Bateria">
													<ItemTemplate>
														<asp:Label runat="server" ID="txTipoBateriaGrid" Text='<%# Eval("NombreTipoBateria") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Capacidad">
													<ItemTemplate>
														<asp:Label runat="server" ID="txtCapacidadGrid" Text='<%# Eval("Capacidad") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
<%--											    <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
												    <ItemTemplate>
														    <asp:ImageButton runat="server" ID="btnActualizarModificacionGrid" AlternateText="Guardar cambios" ToolTip="Guardar cambios" ImageUrl="~/Images/Save_37110.png"  CommandName="GuardarCambiosGrid" CommandArgument='<%# Eval("ModeloVehiculoID") %>' CausesValidation ="false"/> 
														    <asp:ImageButton runat="server" ID="btnEliminarRegistro" AlternateText="Eliminar Registro" ToolTip="Eliminar Registro" OnClientClick="return Confirmacion();" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("ModeloVehiculoID") %>' CausesValidation ="false"/> 
												    </ItemTemplate>
											    </asp:TemplateField>--%>
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