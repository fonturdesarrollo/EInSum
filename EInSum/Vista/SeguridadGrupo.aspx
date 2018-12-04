<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguridadGrupo.aspx.cs" Inherits="Seguridad.SeguridadGrupo" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>



<!DOCTYPE HTML>

<html>
	<head>
		<title>Seguridad | Grupos</title>
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

		$(function () {
			$('#txtNombre').simpleAutoComplete('Autocomplete.aspx', {
				autoCompleteClassName: 'autocomplete',
				selectedClassName: 'sel',
				attrCallBack: 'rel',
				identifier: 'Grupos'
			}, fnPersonalCallBack);

		});

		function fnPersonalCallBack(par) {
			document.getElementById("hdnSeguridadGrupoID").value = par[0]; //par[0] id
			document.getElementById("txtNombre").value = par[1];
			document.getElementById("txtDescripcion").value = par[2];
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
									<a class="logo"><strong>Grupos</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtNombre" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Nombre Grupo"/> 
												<asp:HiddenField runat ="server" ID ="hdnSeguridadGrupoID"  Value="0"/>
												<ASP:RequiredFieldValidator id="rqrValidaNombre" runat="server" errormessage="Debe colocar el nombre del grupo"  controltovalidate="txtNombre" display="Dynamic"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtDescripcion"  MaxLength="200" placeholder ="Descripción Grupo"/> 
												<ASP:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" errormessage="Debe colocar la descripción del grupo"  controltovalidate="txtDescripcion" display="Dynamic"></ASP:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Guardar" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"/>
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo" CausesValidation="False" OnClick="btnNuevo_Click"   /></li>
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


