<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguimientoHistorial.aspx.cs" Inherits="Atensoli.SeguimientoHistorial" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Seguimiento Historial</title>
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
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Seguimiento Historial"></asp:Label></strong>
									</a>
									<ul class="icons">
										<asp:HyperLink runat ="server" ID="lnkAtras" NavigateUrl="~/Vista/SeguimientoOAC.aspx" Text="Volver"></asp:HyperLink>
									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
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
														  <asp:TemplateField HeaderText="N° Solicitud" HeaderStyle-Width="50">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumero" Text='<%# Eval("SolicitudID") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Seguimiento" >
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblEstado" Text='<%# Eval("FechaUltimoSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Observaciones seguimiento">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoAccion" Text='<%# Eval("ObservacionSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo acción">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoUnidad" Text='<%# Eval("NombreTipoAccion") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitente">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblRemitente" Text='<%# Eval("NombreTipoRemitido") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Instruccion">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblIntruccion" Text='<%# Eval("NombreTipoInstruccionSeguimiento") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Remitido">
															  <ItemTemplate>    
																  <asp:Label runat="server" ID="lblTipoInsumo" Text='<%# Eval("Remitido") %>'  ></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Usuario">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTipoInsumoDetalle" Text='<%# Eval("NombreCompleto") %>'  ></asp:Label>
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
