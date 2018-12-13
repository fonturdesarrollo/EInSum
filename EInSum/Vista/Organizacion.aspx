<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Organizacion.aspx.cs" Inherits="Eisum.Organizacion" EnableEventValidation = "false" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Organización</title>
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
					control.empty().append('<option selected="selected" value="0">Por favor seleccione el municipio / parroquia</option>');
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
	  
	  <script type = "text/javascript">
		  $(function () {
			  $('#txtRifOrganizacion').simpleAutoComplete('Autocomplete.aspx', {
				  autoCompleteClassName: 'autocomplete',
				  selectedClassName: 'sel',
				  attrCallBack: 'rel',
				  identifier: 'Organizacion'
			  }, fnPersonalCallBack);

		  });

		  function fnPersonalCallBack(par) {
			  
			  document.getElementById("txtNombreOrganizacion").value = par[3];
			  document.getElementById("ddTipoOrganizacion").value = par[13];
			  document.getElementById("ddlPadre").value = par[15];

			  document.getElementById("hdnCodigoOrganizacion").value = par[2];
			  document.getElementById("hdnMunicipioID").value = par[14];
			  document.getElementById("hdnParroquiaID").value = par[6];
			  
			  document.getElementById("txtTelefonoLocalOrganizacion").value = par[7];
			  document.getElementById("txtTelefonoOrganizacion").value = par[8];
			  document.getElementById("txtEmailOrg").value = par[9];
			  document.getElementById("txtDireccionOrganizacion").value = par[10];
			  document.getElementById("txtCedulaPresidente").value = par[11];
			  document.getElementById("txtNombrePresidente").value = par[12];
			  document.getElementById("txtRifOrganizacion").value = par[1];
              document.getElementById("ddlBloque").value = par[16];
              document.getElementById("txtRutaOrganizacion").value = par[17];


			  var bt = document.getElementById("ButtonTest");
			  bt.click();
		  }
	  </script>
         <script type="text/javascript">
		        $(function () {
		            $('#txtTelefonoLocalOrganizacion').keydown(function (e) {
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
        </script>
         <script type="text/javascript">
		        $(function () {
		            $('#txtTelefonoOrganizacion').keydown(function (e) {
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Datos de la Organización"></asp:Label></strong></a>
									<ul class="icons">
										<asp:Label runat ="server" ID ="lblTitulo2" Text="Datos de la Organización"></asp:Label>
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRifOrganizacion"   MaxLength="10" onkeypress="return event.keyCode!=13;" placeholder ="Indique el RIF de la organización" pattern="^([JGC]{1})([0-9]{9,10})$" title="El primer caracter debe ser J o G mayuscula seguido del numero de RIf G200062894" />
												<ASP:RequiredFieldValidator id="rqrvalidaRifOrganizacion" runat="server" errormessage="Debe colocar el RIF de la organización" controltovalidate="txtRifOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnCodigoOrganizacion"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddTipoOrganizacion" runat="server" AppendDataBoundItems="true"></asp:DropDownList>      
												</div>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtNombreOrganizacion"  MaxLength="80"  placeholder="Nombre de la organización" />
												<ASP:RequiredFieldValidator id="rqrvalidaNombreOrganizacion" runat="server" errormessage="Debe colocar el nombre de la organización"  controltovalidate="txtNombreOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlPadre" runat="server" AppendDataBoundItems="true"
																 onchange = "CargarHijos();">
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaEstado" runat="server" errormessage="Debe seleccionar el estado" controltovalidate="ddlPadre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlHijo" runat="server"
																 onchange = "CargarNieto();">
													</asp:DropDownList>
													<asp:HiddenField runat ="server" ID ="hdnMunicipioID"  Value="0"/> 
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlNieto" runat="server">
													</asp:DropDownList>
													<asp:HiddenField runat ="server" ID ="hdnParroquiaID"  Value="0"/> 
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlBloque" runat="server" AppendDataBoundItems="true"></asp:DropDownList>      
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRutaOrganizacion"  MaxLength="250" placeholder ="Ruta de la organización" TextMode="MultiLine" Rows="2"/>
												<%--<ASP:RequiredFieldValidator id="rqrValidaTelefonoLocalOrg" runat="server" errormessage="Debe colocar el telefono de la organización" controltovalidate="txtTelefonoLocalOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefonoLocalOrganizacion"  MaxLength="11" placeholder ="Teléfono local de la organización" pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 04127654321" />
												<%--<ASP:RequiredFieldValidator id="rqrValidaTelefonoLocalOrg" runat="server" errormessage="Debe colocar el telefono de la organización" controltovalidate="txtTelefonoLocalOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefonoOrganizacion"  MaxLength="11" placeholder ="Teléfono celular de la organización" pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 04127654321" />
												<%--<ASP:RequiredFieldValidator id="rqrValidaTelefonoOrg" runat="server" errormessage="Debe colocar el telefono de la organización" controltovalidate="txtTelefonoOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtEmailOrg"  MaxLength="100" placeholder ="Correo eléctronico de la organización" pattern="[a-zA-Z0-9.+_-]+@[a-zA-Z0-9.-]+\.[a-zA-Z0-9.-]+" title="Debe usar la estructura de correo electronico Ejemplo@fontur.es" />
												<%--<ASP:RequiredFieldValidator id="rqrValidaEmailOrg" runat="server" errormessage="Debe colocar el correo eléctronico  de la organización" controltovalidate="txtEmailOrg" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtDireccionOrganizacion"  MaxLength="250" TextMode="MultiLine" Rows="2"  placeholder ="Dirección de la organización" />
												<%--<ASP:RequiredFieldValidator id="rqrValidaDireccionOrg" runat="server" errormessage="Debe colocar la dirección de la organización" controltovalidate="txtDireccionOrganizacion"  display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCedulaPresidente"  MaxLength="100" placeholder ="Cedula presidente de la organización" />
												<%--<ASP:RequiredFieldValidator id="rqrValidaCedulaPresidenteOrg" runat="server" errormessage="Debe colocar la cedula del presidente de la organización" controltovalidate="txtCedulaPresidente" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>--%>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtNombrePresidente"  placeholder ="Nombre presidente de la organización"/>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Registrar organización" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick="btnGuardar_Click" /></li>
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo"  OnClick="btnNuevo_Click" CausesValidation="False" /></li>
													<li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  CausesValidation="False" OnClick ="ButtonTest_Click" /></li>
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
