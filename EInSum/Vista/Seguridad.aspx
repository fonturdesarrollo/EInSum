<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seguridad.aspx.cs" Inherits="Seguridad.Seguridad" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %> 

<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Agregar usuario</title>
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
									<a class="logo"><strong>Agregar usuario</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">

											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Agregar / modificar usuario" runat="server" ID ="btnAgregarUsuario"   CssClass ="special" OnClick="btnAgregarUsuario_Click"/></li>
												</ul>
												<hr />
												<div class="content">
													<h3><asp:Label runat ="server" ID ="lblOpcionesSeguridad" Text ="Opciones adicionales de seguridad"></asp:Label></h3>
												</div>
												 <ul class="actions">
													<li><asp:Button Text="Grupos" runat="server" ID ="btnAgregarGrupo"    OnClick="btnAgregarGrupo_Click"/></li>
													<li><asp:Button Text="Objetos" runat="server" ID ="btnAgregarObjeto"  OnClick="btnAgregarObjeto_Click"/></li>
													<li><asp:Button Text="Objetos/Grupos" runat="server" ID ="btmAgregarGrupoObjeto"  OnClick="btmAgregarGrupoObjeto_Click"/></li>
													<li><asp:Button Text="Auditoria" runat="server" ID ="btnAuditoria" OnClick="btnAuditoria_Click"/></li>
												 </ul>
												<hr />
												<div class="content">
													<h3><asp:Label runat ="server" ID ="lblOpcionesEmpresa" Text ="Opciones de Empresa"></asp:Label></h3>
												</div>
												<ul class="actions">
													<li><asp:Button Text="Agregar Empresa" runat="server" ID ="btnAgregarEmpresa" OnClick="btnAgregarEmpresa_Click" /></li>
													<li><asp:Button Text="Agregar Sucursal" runat="server" ID ="btnAgregarSucrusal" OnClick="btnAgregarSucrusal_Click" /></li>
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


