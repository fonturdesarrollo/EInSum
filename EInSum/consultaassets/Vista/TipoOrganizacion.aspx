<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoOrganizacion.aspx.cs" Inherits="Atensoli.TipoOrganizacion" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Tipo de Organización</title>
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
				    $('#txtNombreTipoOrganizacion').simpleAutoComplete('Autocomplete.aspx', {
						autoCompleteClassName: 'autocomplete',
						selectedClassName: 'sel',
						attrCallBack: 'rel',
						identifier: 'TipoOrganizacion'
					}, fnPersonalCallBack);

				});

				function fnPersonalCallBack(par) {
				    document.getElementById("hdnTipoOrganizacionID").value = par[0];
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
									<a class="logo"><strong>Tipo Organización</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtNombreTipoOrganizacion" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Indique el nombre del tipo de organización"/> 
												<ASP:RequiredFieldValidator id="rqrvalidaNombreTipoOrg" runat="server" errormessage="Debe colocar el nombre del tipo de organización" controltovalidate="txtNombreTipoOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>													
												<asp:HiddenField runat ="server" ID ="hdnTipoOrganizacionID"  Value="0"/> 
											</div>
											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Guardar tipo organización" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" />												   
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


