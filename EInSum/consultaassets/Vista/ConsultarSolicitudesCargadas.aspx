<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarSolicitudesCargadas.aspx.cs" Inherits="Atensoli.ConsultarSolicitudesCargadas" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Consultar Solicitudes Cargadas</title>
		<meta charset="utf-8" />
		<meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />

<%--        SCRIPTS--%>
		<link rel="stylesheet"  href="../Styles/jquery-ui-1.8rc3.custom.css"  />

		<link rel="stylesheet" href="../assets/css/main.css" />
		<link rel="stylesheet" href="../Styles/simpleAutoComplete.css"  />
		<script src="../js/Util.js" type="text/javascript"></script>
<%--        <script src="../js/jquery.js"></script>--%>      

		<script src="../assets/js/jquery.min.js"></script>
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>      

<%--------------------------%>

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
									<a class="logo"><strong>Consultar Solicitudes Cargadas</strong></a>
									<ul class="icons">
										<asp:HyperLink runat="server" ID="lnkInicio" Text ="Inicio" NavigateUrl="~/Vista/Principal.aspx" ></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
											<div class="row uniform">
											   <div class="6u 12u$(xsmall)">
													<asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click"  />
											   </div>
												<div class="6u 12u$(xsmall)"> 
													<asp:Button ID="btnExportar" runat="server"  Text="Exportar a Excel" OnClick = "ExportToExcel" />
													<asp:CheckBox runat="server" ID ="chkDelDia" Checked ="true" Text ="Solo solicitudes de hoy" />
												</div>
												<div class="6u 12u$(xsmall)">
													
												</div>
										   </div>
											<p></p>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" 
													  CssClass="subtitulo" 
													  EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" 
													  AutoGenerateColumns="False">
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
														  <asp:TemplateField HeaderText="Estatus Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblEstatusSolicitud" Text='<%# Eval("NombreSolicitudEstatus") %>' Font-Bold ="true" ForeColor = '<%# Eval("SolicitudEstatusID").ToString() == "6"?System.Drawing.Color.Blue:System.Drawing.Color.Red %>' ></asp:Label>
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
														  <asp:TemplateField HeaderText="Tipo Atencion">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoAtencion" Text='<%# Eval("NombreTipoAtencionBrindada") %>'  ></asp:Label>
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
														  <asp:TemplateField HeaderText="Atendido por">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAtencion" Text='<%# Eval("NombreCompleto") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
											</div>
								</section>
							</form>
						</div>
					</div>
			   </div>
				<!-- Sidebar -->
<%--					<div id="sidebar">
						<div class="inner">--%>
							<!-- Menu -->
								<%-- SE COMENTÓ DEBIDO A QUE NO SE VE BIEN --%>
								<%--<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>--%>
<%--						</div>
					</div>--%>
			<%--</div>--%>
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>