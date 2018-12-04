<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Solicitud.aspx.cs"EnableEventValidation="false" Inherits="Atensoli.Solicitud" %>

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
		<script src="../assets/js/skel.min.js"></script>
		<script src="../assets/js/util.js"></script>
		<script src="../assets/js/main.js"></script>      
<%--------------------------%>
	   <%----------------------------------------------------------------------------------------------------------------------------------------------%>
	   <%-- PROCESO PARA COMBOS ANIDADOS DESDE EL CLIENTE CON AJAX  JSON Y JAVASRCIPT--%>
		<%--COMBO ANIDADO 2--%>
		<script type = "text/javascript">
			var pageUrl = '<%=ResolveUrl("Solicitud.aspx")%>'
			function CargarHijos() {
				$("#<%=ddlHijo.ClientID%>").attr("disabled", "disabled");

				if ($('#<%=ddlPadre.ClientID%>').val() == "0") {
					$('#<%=ddlHijo.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione la marca del equipo</option>');

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

		<script type = "text/javascript">
			  function CargarControl(list, control) {
				if (list.length > 0) {
					control.removeAttr("disabled");
					control.empty().append('<option selected="selected" value="0">Por favor seleccione detalle del insumo</option>');
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Datos de la solicitud"></asp:Label></strong></a>
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
												<asp:TextBox runat="server" ID="txtNombreCargoSolicitante"  MaxLength="50" placeholder="Cargo del solicitante en la organización" />
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoAtencionBrindada" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaTipoAtencion" runat="server" errormessage="Debe seleccionar el tipo de atención brindada"  controltovalidate="ddlTipoAtencionBrindada" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoReferenciaSolicitud" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaTipoReferencia" runat="server" errormessage="Debe seleccionar el tipo de referencia"  controltovalidate="ddlTipoReferenciaSolicitud" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoUnidad" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlPadre" runat="server" AppendDataBoundItems="true"
																 onchange = "CargarHijos();">
														<asp:ListItem Text = "Seleccione el tipo de insumo" Value = "0"></asp:ListItem>                
													</asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:DropDownList ID="ddlHijo" runat="server">
													<asp:ListItem Text = "Seleccione detalle de insumo" Value = "0"></asp:ListItem>                
												</asp:DropDownList>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoRemitido" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrValidaRemitido" runat="server" errormessage="Debe seleccionar donde será remitido"  controltovalidate="ddlTipoRemitido" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoFormaAtencion" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrValidaFormaAtencion" runat="server" errormessage="Debe seleccionar el tipo de atención prestada"  controltovalidate="ddlTipoFormaAtencion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtObservacionesSolicitante" TextMode="MultiLine" Rows="2" MaxLength="3000"  placeholder="Observaciones del solictante"/> 
												<ASP:RequiredFieldValidator id="rqrValidaObservacionesSolicitante" runat="server" errormessage="Debe colocar las observaciones del solicitante"  controltovalidate="txtObservacionesSolicitante" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtObservacionesAnalista" TextMode="MultiLine" Rows="2" MaxLength="3000"  placeholder="Observaciones del analista"/> 
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoSoporte" runat="server"  AppendDataBoundItems="True"  >
													</asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:Button runat ="server" Text ="Agregar tipo soporte" ID ="btnAgregar" OnClick="btnAgregar_Click" />
											</div>


											<div class="table-wrapper">
												<asp:GridView ID ="grdSoporte" runat ="server" CssClass ="Grid" AutoGenerateColumns ="False" EmptyDataText ="No existen registros" OnRowCommand="grdSoporte_RowCommand">
													<Columns>
														<asp:BoundField  DataField ="Tipo" HeaderText ="Tipo Documento"/>
														<asp:BoundField DataField ="TipoSoporteID" HeaderText ="Codigo" Visible ="false" />
														<asp:TemplateField HeaderText="Quitar" HeaderStyle-Width="100">
															<ItemTemplate>
															<asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false"  ToolTip="Eliminar Detalle"  ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("TipoSoporteID") %>' />
															</ItemTemplate>
														</asp:TemplateField>
													</Columns>
												</asp:GridView>

											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Registrar solicitud" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click"/></li>
													<%--<li><asp:Button Text="Nueva solicitud" runat="server" ID ="btnNueva" OnClick="btnNueva_Click"/></li>--%>
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
