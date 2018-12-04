<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitante.aspx.cs"  EnableEventValidation="false" Inherits="Atensoli.Solicitantes" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Solicitante</title>
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

	
	   <%----------------------------------------------------------------------------------------------------------------------------------------------%>
	   <%-- PROCESO PARA COMBOS ANIDADOS DESDE EL CLIENTE CON AJAX  JSON Y JAVASRCIPT--%>
		<%--COMBO ANIDADO 2--%>
		<script type = "text/javascript">
			var pageUrl = '<%=ResolveUrl("Organizacion.aspx")%>'
			function CargarHijos() {
				$("#<%=ddlHijo.ClientID%>").attr("disabled", "disabled");
				$("#<%=ddlNieto.ClientID%>").attr("disabled", "disabled");
				if ($('#<%=ddlPadre.ClientID%>').val() == "0") {
					$('#<%=ddlHijo.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione la marca del equipo</option>');
					$('#<%=ddlNieto.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione el modelo del equipo</option>');
				}
				else {

					$('#<%=ddlHijo.ClientID %>').empty().append('<option selected="selected" value="0">Cargando...</option>');
					$.ajax({
						type: "POST",
						url: pageUrl + '/CargarHijo',
						data: '{padreID: ' + $('#<%=ddlPadre.ClientID%>').val() + '}',
						contentType: "application/json; charset=utf-8",
						dataType: "json",
						success: EnMarcasCargadas,
						failure: function(response) {
							alert(response.d);
						}
					});
				}
			}
 
			function EnMarcasCargadas(response) {
				CargarControl(response.d, $("#<%=ddlHijo.ClientID %>"));
			}
		</script>
		<%----------------------------------------------------------------------------------------------------------------------------------------------%>

		<%--COMBO ANIDADO 3--%>
		<script type = "text/javascript">
			function CargarNieto() {
				$("#<%=ddlNieto.ClientID%>").attr("disabled", "disabled");
				if ($('#<%=ddlHijo.ClientID%>').val() == "0") {
					$('#<%=ddlNieto.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione el modelo del equipo</option>');
				}
				else {
					$('#<%=ddlNieto.ClientID %>').empty().append('<option selected="selected" value="0">Cargando...</option>');
					$.ajax({
						type: "POST",
						url: pageUrl + '/CargarNieto',
						data: '{nietoID: ' + $('#<%=ddlHijo.ClientID%>').val() + '}',
						contentType: "application/json; charset=utf-8",
						dataType: "json",
						success: EnModelosCargados,
						failure: function(response) {
							alert(response.d);
						}
					});
				}
			}
 
			function EnModelosCargados(response) {
				CargarControl(response.d, $("#<%=ddlNieto.ClientID %>"));
			}
		</script>
			<script type = "text/javascript">
			  function CargarControl(list, control) {
				if (list.length > 0) {
					control.removeAttr("disabled");
					control.empty().append('<option selected="selected" value="0">Por favor seleccione</option>');
					$.each(list, function() {
						control.append($("<option></option>").val(this['Value']).html(this['Text']));
					});
				}
				else {
					control.empty().append('<option selected="selected" value="0">No disponible<option>');
				}
			}
		</script>
		<%--FIN DE COMBOS ANIDADOS--%>
		<%----------------------------------------------------------------------------------------------------------------------------------------------%>
	  
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
									<a class="logo"><strong>Datos del Solicitante</strong></a>
									<ul class="icons">

									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCedula"    MaxLength="12"  Enabled="false"  placeholder="Cedula" />
												<ASP:RequiredFieldValidator id="rqrvalidaCedula" runat="server" errormessage="Debe colocar la cedula" controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnCedula"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtNombre"  MaxLength="80" Enabled="false" placeholder="Nombre Solicitante" />
												<ASP:RequiredFieldValidator id="rqrvalidaNombreVisitante" runat="server" errormessage="Debe colocar el nombre"  controltovalidate="txtNombre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtApellido"  MaxLength="80" Enabled="false" placeholder="Apellido Solicitante" />
												<ASP:RequiredFieldValidator id="rqrvalidaApellido" runat="server" errormessage="Debe colocar el Apellido"  controltovalidate="txtApellido" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlSexo" runat="server"  AppendDataBoundItems="True"  >
														<asp:ListItem>M</asp:ListItem>
														<asp:ListItem>F</asp:ListItem>
													</asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCelular"  MaxLength="100" placeholder ="Celular" pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 04127654321" />
												<ASP:RequiredFieldValidator id="rqrvalidaCelular" runat="server" errormessage="Debe colocar el Celular"  controltovalidate="txtCelular" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefonoLocal"  MaxLength="100" placeholder ="Teléfono local"  pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 02127654321" />
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefonoOficina"  MaxLength="100" placeholder ="Teléfono oficina"  pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 02127654321" />
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCorreo"  MaxLength="100" placeholder ="Correo" pattern="[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.-]+\.[a-zA-Z0-9.-]+" title="Debe usar la estructura de correo electronico Ejemplo@fontur.es" />
												<ASP:RequiredFieldValidator id="rqrCorreo" runat="server" errormessage="Debe colocar el Correo"  controltovalidate="txtCorreo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
					
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlPadre" runat="server" AppendDataBoundItems="true"
																 onchange = "CargarHijos();">
		 
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaEstado" runat="server" errormessage="Debe colocar el estado"  controltovalidate="ddlPadre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlHijo" runat="server"
																 onchange = "CargarNieto();">
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaMunicipio" runat="server" errormessage="Debe colocar el municipio"  controltovalidate="ddlHijo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlNieto" runat="server">
																	 
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaParroquia" runat="server" errormessage="Debe colocar la parroquia"  controltovalidate="ddlHijo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="12u$">
												<asp:CheckBox runat="server" ID="chkPatria" Text="Posee carnet de la patria"/> 
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtSerialCarnetPatria"  MaxLength="100" placeholder ="Serial del carnet de la patria"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCodigoCarnetPatria"  MaxLength="100" placeholder ="Codigo del carnet de la patria"/>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Registrar solicitante" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" /></li>
													<li><asp:Button Text="Siguiente" runat="server" ID ="btnSiguiente"   CausesValidation="False" OnClick="btnSiguiente_Click"  /></li>
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