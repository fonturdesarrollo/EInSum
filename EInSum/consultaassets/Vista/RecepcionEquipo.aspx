<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RecepcionEquipo.aspx.cs" Inherits="Cellper.RecepcionEquipo" EnableEventValidation = "false" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Cellper | Recepción de Equipos</title>
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
					$('#txtCedula').simpleAutoComplete('Autocomplete.aspx', {
						autoCompleteClassName: 'autocomplete',
						selectedClassName: 'sel',
						attrCallBack: 'rel',
						identifier: 'Clientes'
					}, fnPersonalCallBack);

				});

				function fnPersonalCallBack(par) {
					document.getElementById("hdnCedula").value = par[0]; 
					document.getElementById("txtCedula").value = par[0]; 
					document.getElementById("txtNombre").value = par[1];
					document.getElementById("txtTelefono").value = par[3];
					document.getElementById("txtDireccion").value = par[4]; 
					document.getElementById("hdnClienteID").value = par[6];


					var bt = document.getElementById("ButtonTest");
					bt.click();
				}

				function Confirmacion() {

					return confirm("¿Realmente desea eliminar este registro?, no podrá deshacer");
				}
				function ConfirmacionGarantia() {

					//return confirm("¿Desea enviar este equipo a garantía?, no podrá deshacer");
					return document.write("<a href=´#openModal´></a>");
			
				}
				function Recibo() {
					document.write("<a href=´#openModal´></a>");
			
				}
				function LimpiarTextos() {
					document.getElementById("hdnCedula").value = "0";
					document.getElementById("txtCedula").value = "";
					document.getElementById("txtNombre").value = "";
					document.getElementById("txtTelefono").value = "";
				}

		 </script>
		
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
		</script>
		 <script type="text/javascript">
				$(function () {
				$('#txtTelefono').keydown(function (e) {
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
					$('#txtCostoRevision').keydown(function (e) {
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
		

	   <%----------------------------------------------------------------------------------------------------------------------------------------------%>
	   <%-- PROCESO PARA COMBOS ANIDADOS DESDE EL CLIENTE CON AJAX  JSON Y JAVASRCIPT--%>
		<%--COMBO ANIDADO 2--%>
		<script type = "text/javascript">
			var pageUrl = '<%=ResolveUrl("RecepcionEquipo.aspx")%>'
			function CargarMarcaCelular() {
				$("#<%=ddlTipoCelular.ClientID%>").attr("disabled", "disabled");
				$("#<%=ddlModeloCelular.ClientID%>").attr("disabled", "disabled");
				if ($('#<%=ddlTipoEquipo.ClientID%>').val() == "0") {
					$('#<%=ddlTipoCelular.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione la marca del equipo</option>');
					$('#<%=ddlModeloCelular.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione el modelo del equipo</option>');
				}
				else {

					$('#<%=ddlTipoCelular.ClientID %>').empty().append('<option selected="selected" value="0">Cargando...</option>');
					$.ajax({
						type: "POST",
						url: pageUrl + '/CargarTipoCelular',
						data: '{tipoEquipoID: ' + $('#<%=ddlTipoEquipo.ClientID%>').val() + '}',
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
				CargarControl(response.d, $("#<%=ddlTipoCelular.ClientID %>"));
			}
		</script>
		<%----------------------------------------------------------------------------------------------------------------------------------------------%>

		<%--COMBO ANIDADO 3--%>
		<script type = "text/javascript">
			function CargarModeloCelular() {
				$("#<%=ddlModeloCelular.ClientID%>").attr("disabled", "disabled");
				if ($('#<%=ddlTipoCelular.ClientID%>').val() == "0") {
					$('#<%=ddlModeloCelular.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione el modelo del equipo</option>');
				}
				else {
					$('#<%=ddlModeloCelular.ClientID %>').empty().append('<option selected="selected" value="0">Cargando...</option>');
					$.ajax({
						type: "POST",
						url: pageUrl + '/CargarModeloCelular',
						data: '{tipoCelularID: ' + $('#<%=ddlTipoCelular.ClientID%>').val() + '}',
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
				CargarControl(response.d, $("#<%=ddlModeloCelular.ClientID %>"));
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
									<a class="logo"><strong>Recepción de Equipos</strong></a>
									<ul class="icons">

									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCedula"   onkeypress="return event.keyCode!=13;" MaxLength="12" placeholder="Cedula" />
												<ASP:RequiredFieldValidator id="rqrvalidaCedula" runat="server" errormessage="Debe colocar la cedula" controltovalidate="txtCedula" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnCedula"  Value="0"/> 
												<asp:HiddenField runat ="server" ID ="hdnClienteID"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtNombre"  MaxLength="80"  placeholder="Nombre Cliente" />
												<ASP:RequiredFieldValidator id="rqrvalidaNombreVisitante" runat="server" errormessage="Debe colocar el nombre"  controltovalidate="txtNombre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTelefono"  MaxLength="100" placeholder ="Teléfono"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtDireccion"  MaxLength="100" placeholder ="Dirección"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoEquipo" runat="server" AppendDataBoundItems="true"
																 onchange = "CargarMarcaCelular();">
														<asp:ListItem Text = "Seleccione el tipo de equipo" Value = "0"></asp:ListItem>                
													</asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
											<asp:DropDownList ID="ddlTipoCelular" runat="server"
														 onchange = "CargarModeloCelular();">
												<asp:ListItem Text = "Seleccione la marca del equipo" Value = "0"></asp:ListItem>                
											</asp:DropDownList>
											</div>
											<div class="6u 12u$(xsmall)">
											<asp:DropDownList ID="ddlModeloCelular" runat="server">
												<asp:ListItem Text = "Seleccione el modelo del equipo" Value = "0"></asp:ListItem>                
											</asp:DropDownList>

												<asp:HiddenField runat ="server" ID ="hdnCodigoModelo"  Value="0"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtIMEI" MaxLength="15" placeholder ="IMEI/SERIAL"/>
												<ASP:RequiredFieldValidator id="rqrvalidaIMEI" runat="server" errormessage="Debe colocar IMEI/Serial"  controltovalidate="txtIMEI" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													 <asp:DropDownList ID="ddlFalla" runat="server"  AppendDataBoundItems="True" ></asp:DropDownList> 
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlCondicionEquipo" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtAccesorios" TextMode="MultiLine" Rows="1" MaxLength="300"  placeholder="Accesorios"/> 
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="1" MaxLength="300"  placeholder="Observaciones"/> 
												<ASP:RequiredFieldValidator id="rqrvalidaObservaciones" runat="server" errormessage="Debe colocar las observaciones"  controltovalidate="txtObservaciones" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTecnico" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtCostoRevision" MaxLength="5" placeholder ="Costo Revisión"/>
												<ASP:RequiredFieldValidator id="rqrvalidaCostoReviison" runat="server" errormessage="Debe colocar el costo de revisión"  controltovalidate="txtCostoRevision" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Enviar a servicio" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick="btnGuardar_Click" /></li>
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnLimpiar"   CausesValidation="False" OnClick="btnLimpiar_Click"  /></li>
													<li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  CausesValidation="False" OnClick="ButtonTest_Click" /></li>
												   
												</ul>
											</div>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" 
													  CssClass="subtitulo" 
													  EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" 
													  AutoGenerateColumns="False" 
													  OnRowCommand="gridDetalle_RowCommand"
													   >
														<HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
														<AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
														  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="CodV" HeaderStyle-Width="0" Visible="false">
															  <ItemTemplate>
																  <asp:TextBox runat="server" ID="txtCodVisita" Visible ="false"   Width="0" ForeColor ="Red" Text='<%# Eval("RecepcionEquipoID") %>' ></asp:TextBox>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="N°" HeaderStyle-Width="50">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNumeroRecibo" Text='<%# Eval("RecepcionEquipoID") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Fecha Recepción" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaRecepcion" Text='<%# Eval("FechaRecepcion") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
													 <asp:TemplateField HeaderText="Fecha Entrega" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFechaEntrega" Text='<%# Eval("FechaEntrega") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Cédula" HeaderStyle-Width="80">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblCedulaVisitante" Text='<%# Eval("CedulaCliente") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Nombre" HeaderStyle-Width="150">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreVisitante" Text='<%# Eval("NombreCliente") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Tipo equipo" HeaderStyle-Width="80">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblAsunto" Text='<%# Eval("NombreTipoEquipo") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Marca" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblObservacion" Text='<%# Eval("NombreTipoCelular") %>' Font-Bold ="true" ForeColor = '<%# Eval("EstatusEquipoID").ToString() == "1"?System.Drawing.Color.Red:System.Drawing.Color.Blue %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Modelo " HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblVisitado" Text='<%# Eval("NombreModeloCelular") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="IMEI/Serial" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblIMEI" Text='<%# Eval("IMEI") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Falla" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblFalla" Text='<%# Eval("NombreFallaCelular") %>'></asp:Label>
															  </ItemTemplate>   
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Técnico" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblTecnico" Text='<%# Eval("NombreTecnico") %>'></asp:Label>
															  </ItemTemplate>   
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Estatus" HeaderStyle-Width="100">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreEstatus" Text='<%# Eval("NombreEstatusEquipo") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
															  <ItemTemplate>
																<asp:ImageButton runat="server" ID="btnEstatus" AlternateText="Imprimir Recibo" ToolTip="Imprimir Recibo" ImageUrl="~/Images/imprimir.jpg"  CommandName="ImprimirRecibo" CommandArgument='<%# Eval("RecepcionEquipoID") %>' CausesValidation ="false"/> 
																<asp:ImageButton runat ="server" PostBackUrl="#openModal"  ImageUrl="~/Images/icon-garantia.png" ToolTip="Enviar a garantía" CausesValidation="false" CommandName="Garantia" AlternateText ='<%# Eval("NombreEstatusEquipo") %>' CommandArgument='<%# Eval("RecepcionEquipoID") %>'></asp:ImageButton>
																<%--<asp:HyperLink runat ="server" ID ="lnkGarantia" NavigateUrl="#openModal" ImageUrl="~/Images/icon-garantia.png" ToolTip="Garantía" ></asp:HyperLink>--%>
																<%--<asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("RecepcionEquipoID") %>'/>--%>
															  </ItemTemplate>
														  </asp:TemplateField>
													  </Columns>
												  </asp:GridView>
											</div>
										</div>
								</section>
						   <%--</form>--%>
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


<%--        FORMULARIO MODAL DEL RECIBO DE ENTREGA--%>
<%--            SE SUSTITUYO POR UNA NUEVA PAGINA LLAMADA DESDE EL CODE BEHIND--%>
			<div id="openModal" class="modalWindow">
				<div>
		
					<div class="modalHeader">
						<h2>Enviar a garantía</h2>
						<a href="#close" title="Close" class="close">X</a>
					</div>
		
					<div class="modalContent">
						  <table>
								<tr>    
									<td class="auto-style2">
										<asp:Label Text="Observaciones" ID="Label5" runat="server" />
										<asp:TextBox runat="server" ID="txtObservacionesGarantia" MaxLength="550" TextMode="MultiLine" Rows="1" Width ="700"/> 
										<asp:HiddenField runat ="server" ID ="hdnEquipoRecepcionGarantiaID"  Value="0"/> 
									</td>
								</tr>
						  </table>
					</div>
		
					<div class="modalFooter">
						<asp:Button  ID ="btnEnviarGarantia" runat ="server" Text="Enviar a garantía"  CssClass ="special" CausesValidation="false" OnClick="btnEnviarGarantia_Click"/>
						<%--<a href="#cancel" title="Cancel" class="cancel">Cancelar</a>--%>
						<%--<a href="#ok" title="Ok" class="ok">Cancelar</a>--%>
						<div class="clear"></div>
					</div>
				
				</div>
			</div>
		</form>
<%------------------------------------------------------------------------------------------------------------------%>
	</body>
</html>