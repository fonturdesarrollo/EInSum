<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ConsultarSolicitud.aspx.cs" Inherits="Atensoli.ConsultarSolicitud" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Consultar Solicitud</title>
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
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>      

<%--------------------------%>

	<script type="text/javascript">
			$(function () {
			$('#txtCedula').keydown(function (e) {
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

			function Confirmacion() {

				return confirm("¿Desea actualizar el estatus de esta solicitud?");
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
									<a class="logo"><strong>Consultar Solicitud en Seguimiento</strong></a>
									<ul class="icons">
										<asp:HyperLink runat="server" ID="lnkInicio" Text ="Inicio" NavigateUrl="~/Vista/Principal.aspx" ></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
										    <div class="posts">
											    <article>
												    <asp:TextBox runat="server" ID="txtCedula" MaxLength="9" placeholder ="Número de cedula del solicitante"/>  
											    </article>
												    <article>
													    <asp:Button Text="Consultar" runat="server" ID ="btnConsultar"  CssClass ="special" OnClick="btnConsultar_Click" />
												    </article>
											    </div>
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
														  <asp:TemplateField HeaderText="N°">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumero" Text='<%# Eval("SolicitudID") %>'  ></asp:Label>
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
														  <asp:TemplateField HeaderText="Rif Organización">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRifOrganizacion" Text='<%# Eval("RifOrganizacion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Organización">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreOrganizacion" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo Unidad">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoUnidad" Text='<%# Eval("NombreTipoUnidad") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>

														  <asp:TemplateField HeaderText="Fecha Solicitud" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("FechaRegistroSolicitud") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Ultimo Seguimiento" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaSeguimiento" Text='<%# Eval("FechaUltimoSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitente">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRemitente" Text='<%# Eval("Remitente") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Accion">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAccion" Text='<%# Eval("NombreTipoAccion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Instruccion">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoInsumoDetalle" Text='<%# Eval("NombreTipoInstruccionSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObsSol" Text='<%# Eval("ObservacionSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitido">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblRemitido" Text='<%# Eval("Remitido") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Analista">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAtencion" Text='<%# Eval("NombreCompleto") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Acciones">
															  <ItemTemplate>
																<asp:ImageButton runat="server" ID="btnEstatus" AlternateText="Actualizar estatus" ToolTip="Actualizar estatus" ImageUrl="~/Images/asignar_tecnico_icono.png" OnClientClick="return Confirmacion();" CommandName="ActualizarEstatus" CommandArgument='<%# Eval("SolicitudID") %>' CausesValidation ="false"/> 
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
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>