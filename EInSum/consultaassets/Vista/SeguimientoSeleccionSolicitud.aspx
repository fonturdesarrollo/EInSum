<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguimientoSeleccionSolicitud.aspx.cs" Inherits="Atensoli.SeguimientoSeleccionSolicitud" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Selección de Solicitud para Seguimiento</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
		<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />
		<script src="../assets/js/jquery.min.js"></script>
		<link rel="stylesheet" href="../assets/css/main.css" />
		<link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
		<script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>      
		
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>      

<%--------------------------%>

	<script type="text/javascript">

				function Confirmacion() {

					return confirm("¿Realmente desea descartar esta solicitud?, no podrá deshacer");
				}
				function ConfirmacionSeguimiento() {

					return confirm("¿Desea realizar seguimiento esta solicitud?");
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
									<a class="logo">
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Selección de Solicitud para Seguimiento"></asp:Label></strong>
									</a>
									<ul class="icons">
										<asp:HyperLink runat="server" ID="lnkInicio" Text ="Inicio" NavigateUrl="~/Vista/Principal.aspx" ></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
											<div class="posts">
												<article>
													<asp:TextBox runat ="server" ID ="txtCedula" placeholder ="Número de cedula del solicitante"></asp:TextBox>
													<ASP:RequiredFieldValidator id="rqrvalidaCedula" runat="server" errormessage="Debe colocar el número de cedula del solicitante"  controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</article>
											   <article>
													<asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click"  />
											   </article>
										   </div>
											<p></p>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" 
													  CssClass="subtitulo" 
													  EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" 
													  AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand">
														<HeaderStyle  Font-Size="10px" />
														<AlternatingRowStyle Font-Size="10px" />
														  <RowStyle  Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="N" HeaderStyle-Width="50">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumero" Text='<%# Eval("SolicitudID") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("FechaRegistroSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Estado" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitido">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRemitido" Text='<%# Eval("NombreTipoRemitido") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoSolicitud" Text='<%# Eval("NombreTipoSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoSolicitante" Text='<%# Eval("NombreTipoSolicitante") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Cedula Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblCedulaSolicitante" Text='<%# Eval("CedulaSolicitante") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreSolicitante" Text='<%# Eval("SolicitanteNombre") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="RIF Organizacion">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRifOrganizacion" Text='<%# Eval("RifOrganizacion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Organizacion">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreOrganizacion" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Unidad">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoUnidad" Text='<%# Eval("NombreTipoUnidad") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Insumo">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Detalle Tipo Insumo">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones Solicitante">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObsSol" Text='<%# Eval("ObservacionesSolicitante") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones Analista">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObsAnalis" Text='<%# Eval("ObservacionesAnalista") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
															  <ItemTemplate>
																<asp:ImageButton runat="server" ID="btnSeguimiento" AlternateText="Realizar seguimiento" ToolTip="Realizar seguimiento" ImageUrl="~/images/asignar_estatus_icono.png"  CommandName="RealizarSeguimiento"  CommandArgument='<%# Eval("SolicitudID") %>'  OnClientClick="return ConfirmacionSeguimiento();" CausesValidation ="false"/> 
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
											</div>
								</section>
							</form>
						</div>
					</div>
					<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
				</div>
	</body>
</html>
