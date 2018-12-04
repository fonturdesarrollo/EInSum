<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarVehiculos.aspx.cs" Inherits="Eisum.AsignarVehiculos" EnableEventValidation="false" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Asignar Vehículos</title>
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
			var pageUrl = '<%=ResolveUrl("AsignarVehiculos.aspx")%>'
			function CargarHijos() {
				$("#<%=ddlHijo.ClientID%>").attr("disabled", "disabled");

				if ($('#<%=ddlPadre.ClientID%>').val() == "0") {
					$('#<%=ddlHijo.ClientID %>').empty().append('<option selected="selected" value="0">Seleccione la marca del vehículo</option>');

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
					control.empty().append('<option selected="selected" value="0">Por favor seleccione el modelo del vehículo</option>');
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
				  identifier: 'Organizacion',
			  }, fnPersonalCallBack);

		  });

		  function fnPersonalCallBack(par) {
			  document.getElementById("hdnCodigoOrganizacion").value = par[2];
			  var bt = document.getElementById("ButtonTest2");
			  bt.click();
		  }

		  $(function () {
				  $('#txtCedulaBeneficiario').simpleAutoComplete('Autocomplete.aspx', {
					  autoCompleteClassName: 'autocomplete',
					  selectedClassName: 'sel',
					  attrCallBack: 'rel',
					  identifier: 'Beneficiario'
				  }, fnPersonalCallBack2);
			  });

		  function fnPersonalCallBack2(par) {
			  document.getElementById("hdnBeneficiarioID").value = par[0];
			  //document.getElementById("txtRifOrganizacion").value = "";
			  document.getElementById("txtPlaca").value = "";
			  document.getElementById("txtSerialCarroceria").value = "";
			  document.getElementById("txtSerialMotor").value = "";
			  document.getElementById("txtRuta").value = "";
			  var bt = document.getElementById("ButtonTest");
			  bt.click();
		  }

		  function Confirmacion() {

			  return confirm("¿Realmente desea eliminar este registro?, no podrá deshacer");
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Asignar Vehículos"></asp:Label></strong></a>
									<ul class="icons">
										<asp:HyperLink runat="server" ID="lnkInicio" Text ="Inicio" NavigateUrl="~/Vista/Principal.aspx" ></asp:HyperLink>
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="true"  OnSelectedIndexChanged="ddlEstado_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>      
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlBloque" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlBloque_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>      
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRifOrganizacion"   MaxLength="30" placeholder="RIF  / nombre de la organización" />
												<ASP:RequiredFieldValidator id="rqrvalidaRifOrganizacion" runat="server" errormessage="Debe colocar el RIF de la organización" controltovalidate="txtRifOrganizacion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnCodigoOrganizacion"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)"> 
												<asp:TextBox runat="server" ID="txtCedulaBeneficiario"  MaxLength="80"  placeholder="Cedula / nombre beneficiario" />
												<ASP:RequiredFieldValidator id="rqrvalidaCedulaBeneficiario" runat="server" errormessage="Debe colocar la cedula del beneficiario"  controltovalidate="txtCedulaBeneficiario" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												<asp:HiddenField runat ="server" ID ="hdnBeneficiarioID"  Value="0"/> 
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtPlaca"  MaxLength="7" placeholder ="Placa" pattern="[A-Za-z0-9]+" title="Solo se permiten letras y numeros"/>
												<ASP:RequiredFieldValidator id="rqrvalidaPlaca" runat="server" errormessage="Debe colocar la Placa del Vehiculo" controltovalidate="txtPlaca" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlPadre" runat="server" AppendDataBoundItems="true"
																 onchange = "CargarHijos();">
													</asp:DropDownList>
													<ASP:RequiredFieldValidator id="rqrvalidaEstado" runat="server" errormessage="Debe seleccionar la marca" controltovalidate="ddlPadre" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlHijo" runat="server">
													</asp:DropDownList>
													<asp:HiddenField runat ="server" ID ="hdnMunicipioID"  Value="0"/> 
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtSerialCarroceria"  MaxLength="100" placeholder ="Serial de carroceria"/>
												<ASP:RequiredFieldValidator id="rqrValidaSerialCarroceria" runat="server" errormessage="Debe colocar el serial de carroceria" controltovalidate="txtSerialCarroceria" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtSerialMotor"  MaxLength="100" placeholder ="Serial de motor"/>
												<ASP:RequiredFieldValidator id="rqrValidaSerialMotor" runat="server" errormessage="Debe colocar el serial de motor" controltovalidate="txtSerialMotor" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlColor" runat="server" AppendDataBoundItems="true"></asp:DropDownList> 
													<ASP:RequiredFieldValidator id="rqrValidaColor" runat="server" errormessage="Debe colocar el color" controltovalidate="ddlColor" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>                                                         
												</div>
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddAñoVehiculo" runat="server" AppendDataBoundItems="true"></asp:DropDownList>      
													<ASP:RequiredFieldValidator id="rqrValidaAño" runat="server" errormessage="Debe colocar el año" controltovalidate="ddAñoVehiculo" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRuta"  MaxLength="200" placeholder ="Ruta"/>
												<ASP:RequiredFieldValidator id="rqrValidaRuta" runat="server" errormessage="Debe colocar la ruta" controltovalidate="txtRuta" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:Label runat="server" ID="lblEtiquetaTotalRegistros" Text="Total registros:"/>
												<asp:Label runat="server" ID="lblTotalRegistros" Text="0"/>
												<ASP:RequiredFieldValidator id="RequiredFieldValidator1" runat="server" errormessage="Debe colocar la ruta" controltovalidate="txtRuta" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>

											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Asignar vehículo" runat="server" ID ="btnGuardar"  CssClass ="special"     OnClick="btnGuardar_Click"/></li>
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevoRegistro"   CausesValidation="False"  OnClick="btnNuevoRegistro_Click"/></li>
													<li><asp:Button Text="Imprimir" runat="server" ID ="btnImprimir"   CausesValidation="False" OnClick="btnImprimir_Click"/></li>
													<li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  CausesValidation="False"  OnClick ="ButtonTest_Click" /></li>
													<li><asp:Button Text="TEST2" runat="server" ID ="ButtonTest2"  style="display:none"  CausesValidation="False"  OnClick="ButtonTest2_Click" /></li>
													<asp:HiddenField runat ="server" ID ="hdnCodigoOrganizacionAsignarVehiculoID"  Value="0"/> 
												</ul>
										  </div>
									</div>
								</section>

								<div class="table-wrapper">
									<asp:Label runat ="server" ID ="Label1" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>
									<p></p>
										<asp:GridView ID="gridDetalle" runat="server" 
											CssClass="subtitulo" 
											EmptyDataText="No existen Registros" 
											GridLines="Horizontal" 
											AutoGenerateColumns="False"   OnRowCommand ="gridDetalle_RowCommand">
											<HeaderStyle  Font-Size="10px" />
											<AlternatingRowStyle Font-Size="10px" />
												<RowStyle  Font-Size="10px" />
												<Columns>
												<asp:TemplateField HeaderText="Rif">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblRif" Text='<%# Eval("RifOrganizacion") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
											<asp:TemplateField HeaderText="Nombre organización" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblNombreOrg" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Placa">
												<ItemTemplate>
													<asp:Label runat="server" ID="lblPlacaGrid"  Text='<%# Eval("Placa") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Cedula">
												<ItemTemplate>
													<asp:Label runat="server" ID="lblCedulaGrid" Text='<%# Eval("CedulaBeneficiario") %>'  ></asp:Label>
													</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Transportista">
												<ItemTemplate>
													<asp:Label runat="server" ID="lblTransportistaGrid" Text='<%# Eval("NombreBeneficiario") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Serial carroceria" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblSerialCarroceriaGrid"  Text='<%# Eval("SerialCarroceria") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Serial Motor" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblSerialMotorGrid"  Text='<%# Eval("SerialMotor") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Color" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblColor"  Text='<%# Eval("NombreColor") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Año" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblAño"  Text='<%# Eval("AñoVehiculo") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Ruta" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblRuta"  Text='<%# Eval("Ruta") %>'></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Marca" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblMarca" Text='<%# Eval("NombreMarcaVehiculo") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Modelo" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblModelo" Text='<%# Eval("NombreModeloVehiculo") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
												<ItemTemplate>
													<asp:ImageButton runat="server" ID="btnModificarRegistro" AlternateText="Modificar Registro" ToolTip="Modificar Registro" ImageUrl="~/Images/asignar_estatus_icono.png"  CommandName="ModificarDetalle" CommandArgument='<%# Eval("OrganizacionBeneficiarioID") %>' CausesValidation ="false"/> 
													<asp:ImageButton runat="server" ID="btnEliminarRegistro" AlternateText="Eliminar Registro" ToolTip="Eliminar Registro" OnClientClick="return Confirmacion();" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("OrganizacionAsignarVehiculoID") %>' CausesValidation ="false"/> 
												</ItemTemplate>
											</asp:TemplateField>
											</Columns>
										</asp:GridView>


								<div class="table-wrapper">
									<asp:SqlDataSource 
										ID="SqlDataSource4" 
										runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
										SelectCommand="SELECT * FROM Color">
									</asp:SqlDataSource>
									<asp:SqlDataSource 
										ID="SqlDataSource6" 
										runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
										SelectCommand="SELECT * FROM MarcaVehiculo Order By NombreMarcaVehiculo">
									</asp:SqlDataSource>

									<asp:SqlDataSource 
										ID="SqlDataSource5" 
										runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
										SelectCommand="SELECT * FROM Año">
									</asp:SqlDataSource>
									<asp:SqlDataSource 
										ID="SqlDataSource1" 
										runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
										SelectCommand="SELECT * FROM Estado Order By NombreEstado">
									</asp:SqlDataSource>



									<asp:Label runat ="server" ID ="Label2" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>
									<p></p>
										<asp:GridView ID="gridDetalle2" runat="server" 
											CssClass="subtitulo" 
											EmptyDataText="No existen Registros" 
											GridLines="Horizontal" 
											AutoGenerateColumns="False" OnRowCommand="gridDetalle2_RowCommand" >
											<HeaderStyle  Font-Size="10px" />
											<AlternatingRowStyle Font-Size="10px" />
												<RowStyle  Font-Size="10px" />
												<Columns>
												<asp:TemplateField HeaderText="CodigoTabla" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblCodigoTabla" Text='<%# Eval("OrganizacionAsignarVehiculoID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="CodigoOrganizacion" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblCodigoOrganizacion" Text='<%# Eval("OrganizacionID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="CodigoTransportista" HeaderStyle-Width="0" Visible="false">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblCodigoTransportista" Text='<%# Eval("OrganizacionBeneficiarioID") %>'  Visible ="false" ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
												<asp:TemplateField HeaderText="Rif">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblRif" Text='<%# Eval("RifOrganizacion") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
											<asp:TemplateField HeaderText="Nombre organización" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblNombreOrg" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
<%--											<asp:TemplateField HeaderText="Estado" ControlStyle-Width="150">
												<ItemTemplate>
													<div class="select-wrapper">
														<asp:DropDownList runat="server" ID="ddlEstadoGrid"
															DataSourceID="SqlDataSource1" 
															DataTextField ="NombreEstado"
															DataValueField ="EstadoID"
															SelectedValue ='<%# Bind("EstadoID") %>'>
														</asp:DropDownList>
													</div>
												</ItemTemplate>
											</asp:TemplateField>--%>
											<asp:TemplateField HeaderText="Cedula">
												<ItemTemplate>
													<asp:Label runat="server" ID="lblCedulaGrid" Text='<%# Eval("CedulaBeneficiario") %>'  ></asp:Label>
													</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Transportista">
												<ItemTemplate>
													<asp:Label runat="server" ID="lblTransportistaGrid" Text='<%# Eval("NombreBeneficiario") %>'  ></asp:Label>
															</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Placa" ControlStyle-Width="100">
												<ItemTemplate>
													<asp:TextBox runat="server" ID="txtPlacaGrid"  Text='<%# Eval("Placa") %>'></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Serial carroceria" ControlStyle-Width="180">
												<ItemTemplate>
													<asp:TextBox runat="server" ID="txtSerialCarroceriaGrid"  Text='<%# Eval("SerialCarroceria") %>'></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Serial Motor" ControlStyle-Width="180">
												<ItemTemplate >
													<asp:TextBox runat="server" ID="txtSerialMotorGrid"  Text='<%# Eval("SerialMotor") %>'></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Ruta"  HeaderStyle-Width="0" Visible="false">
												<ItemTemplate >
													<asp:TextBox runat="server" ID="txtRutaGrid"  Text='<%# Eval("Ruta") %>'></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="ModeloID"  HeaderStyle-Width="0" Visible="false">
												<ItemTemplate >
													<asp:TextBox runat="server" ID="txtModeloID"  Text='<%# Eval("NombreModeloVehiculo") %>'></asp:TextBox>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Color" ControlStyle-Width="150">
												<ItemTemplate>
													<div class="select-wrapper">
														<asp:DropDownList runat="server" ID="ddlColorGrid"
															DataSourceID="SqlDataSource4" 
															DataTextField ="NombreColor"
															DataValueField ="ColorID"
															SelectedValue ='<%# Bind("ColorID") %>'>
														</asp:DropDownList>
													</div>
												</ItemTemplate>
											</asp:TemplateField>

											<asp:TemplateField HeaderText="Año" ControlStyle-Width="100">
												<ItemTemplate>
													<div class="select-wrapper">
														<asp:DropDownList runat="server" ID="ddlAñoGrid"
															DataSourceID="SqlDataSource5" 
															DataTextField ="NombreAño"
															DataValueField ="AñoID"
															SelectedValue ='<%# Bind("AñoID") %>'>
														</asp:DropDownList>
													</div>
												</ItemTemplate>
											</asp:TemplateField>

											<asp:TemplateField HeaderText="Marca" ControlStyle-Width="150">
												<ItemTemplate>
													<div class="select-wrapper">
														<asp:DropDownList runat="server" ID="ddlMarcaGrid" OnSelectedIndexChanged="ddlMarcaGrid_SelectedIndexChanged"
															DataSourceID="SqlDataSource6" 
															DataTextField ="NombreMarcaVehiculo"
															DataValueField ="MarcaVehiculoID"
															SelectedValue ='<%# Bind("MarcaVehiculoID") %>'
															AutoPostBack="true" >
														</asp:DropDownList>
													</div>
												</ItemTemplate>
											</asp:TemplateField>

											<asp:TemplateField HeaderText="Modelo" ControlStyle-Width="200">
												<ItemTemplate>
													<div class="select-wrapper">
														<asp:DropDownList runat="server" ID="ddModeloGrid"
															DataSourceID="SqlDataSource7" 
															DataTextField ="NombreModeloVehiculo"
															DataValueField ="ModeloVehiculoID" >
														</asp:DropDownList>
													</div>
													<asp:SqlDataSource 
														ID="SqlDataSource7" 
														runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
														SelectCommand="SELECT * FROM ModeloVehiculo"
														FilterExpression ="MarcaVehiculoID = '{0}' AND NombreModeloVehiculo LIKE '%{1}%'">
														<FilterParameters>
															<asp:ControlParameter Name="MarcaVehiculoID" ControlID="ddlMarcaGrid" PropertyName="SelectedValue" DefaultValue="ALL"/>
															<asp:ControlParameter Name="ModeloVehiculoID" ControlID="txtModeloID" PropertyName="Text" ConvertEmptyStringToNull="false"  Type="String" DefaultValue="ALL" />
														</FilterParameters> 
													</asp:SqlDataSource>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
												<ItemTemplate>
														<asp:ImageButton runat="server" ID="btnActualizarModificacionGrid" AlternateText="Guardar cambios" ToolTip="Guardar cambios" ImageUrl="~/Images/Save_37110.png"  CommandName="GuardarCambiosGrid" CommandArgument='<%# Eval("OrganizacionBeneficiarioID") %>' CausesValidation ="false"/> 
														<asp:ImageButton runat="server" ID="btnEliminarRegistro" AlternateText="Eliminar Registro" ToolTip="Eliminar Registro" OnClientClick="return Confirmacion();" ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("OrganizacionAsignarVehiculoID") %>' CausesValidation ="false"/> 
												</ItemTemplate>
											</asp:TemplateField>
											</Columns>
										</asp:GridView>
								</div>
							  </div>
						   </form>
						</div>
					</div>                  
				<!-- Sidebar -->
<%--					<div id="sidebar">
						<div class="inner">--%>
							<!-- Menu -->
								<%--<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>--%>
<%--						</div>
					</div>--%>
			</div>
	</body>
</html>

