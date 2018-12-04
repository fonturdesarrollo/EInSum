<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SolicitudResultado.aspx.cs" Inherits="Atensoli.SolicitudResultado" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Solicitud</title>
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
									<a class="logo"><strong>Solicitud creada exitosamente</strong></a>
									<ul class="icons">
										<asp:Label runat ="server" ID ="lblTitulo2" Text="Tipo de solicitud"></asp:Label>
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label1" Text="Número de solicitud"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblNumeroSOlicitud" Text=""></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label6" Text="Remitido"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblRemitido" Text=""></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label2" Text="Cedula"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblCedulaSolicitante" Text=""></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label3" Text="Nombre Solicitante"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblSolicitanteNombre" Text=""></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label4" Text="Rif Organización"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblRifOrganizacion" Text=""></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="Label5" Text="Nombre Organización"></asp:Label>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblNombreOrganizacion"></asp:Label>
											</div>

											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Nueva solicitud" runat="server" ID ="btnNueva" CssClass="special" OnClick ="btnNueva_Click"/></li>
												</ul>
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
	</body>
</html>
