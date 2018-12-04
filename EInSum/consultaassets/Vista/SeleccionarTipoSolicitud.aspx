<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeleccionarTipoSolicitud.aspx.cs" Inherits="Atensoli.Vista.BuscarTipoSolicitud" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %> 

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Tipo de solicitud</title>
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
		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
					<div id="main">
						<div class="inner">

							<!-- Header -->
								<header id="header">
									<a class="logo"><strong>Tipo de solicitud</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddTipoSolicitud" runat="server"  AppendDataBoundItems="True" AutoPostBack = "true" OnSelectedIndexChanged="ddTipoSolicitud_SelectedIndexChanged" ></asp:DropDownList>         
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Label runat ="server" ID ="lblDescripcion" Font-Bold ="true" ForeColor ="Red">

												</asp:Label>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Siguiente" runat="server" ID ="btnSiguiente"  CssClass ="special" OnClick="btnSiguiente_Click" /></li>
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
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>
