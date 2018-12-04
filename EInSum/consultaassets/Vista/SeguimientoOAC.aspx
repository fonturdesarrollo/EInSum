<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguimientoOAC.aspx.cs" Inherits="Atensoli.SeguimientoOAC" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>
<html>
	<head>
		<title>Atensoli | Seguimiento OAC</title>
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
				$('#txtCedulaPostulante').keydown(function (e) {
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
										<strong><asp:Label runat ="server" ID ="lblTitulo" Text="Seguimiento OAC"></asp:Label></strong>
									<ul class="icons">
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
											<div class="row uniform">
												<div class="6u 12u$(xsmall)">
													<asp:Button  runat ="server" ID="btnGuardar" Text ="Actualizar seguimiento" CssClass ="special" OnClick="btnGuardar_Click"/>
												</div>
												<div class="6u 12u$(xsmall)">
													<asp:Button  runat ="server" ID="btnHistorial" Text ="Historial de seguimiento" CausesValidation="False" OnClick="btnHistorial_Click" />
												</div>
											</div>
											<p></p>
											<div class="table-wrapper"> 
												<asp:Label runat="server" ID ="lblSubTitulo" Text ="Detalle solicitud"></asp:Label>
													  <asp:GridView ID="gridDetalle" runat="server" 
														  CssClass="subtitulo" 
														  EmptyDataText="No existen Registros" 
														  GridLines="Horizontal" 
														  AutoGenerateColumns="False">
															<HeaderStyle  Font-Size="10px" />
															<AlternatingRowStyle Font-Size="10px" />
															  <RowStyle  Font-Size="10px" />
														  <Columns>
															  <asp:TemplateField HeaderText="Fecha Solicitud" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblFechaSolicitud" Text='<%# Eval("FechaRegistroSolicitud") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Estado" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Remitido">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblRemitido" Text='<%# Eval("NombreTipoRemitido") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Tipo Solicitud" >
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblTipoSolicitud" Text='<%# Eval("NombreTipoSolicitud") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Tipo Solicitante">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblTipoSolicitante" Text='<%# Eval("NombreTipoSolicitante") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Cedula Solicitante">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblCedulaSolicitante" Text='<%# Eval("CedulaSolicitante") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Nombre Solicitante">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblNombreSolicitante" Text='<%# Eval("SolicitanteNombre") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="RIF Organizacion">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblRifOrganizacion" Text='<%# Eval("RifOrganizacion") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Nombre Organizacion">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblNombreOrganizacion" Text='<%# Eval("NombreOrganizacion") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Telefono Organizacion">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblTelefonoOrganizacion" Text='<%# Eval("TelefonoOrganizacion") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Tipo Unidad">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblTipoUnidad" Text='<%# Eval("NombreTipoUnidad") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Tipo Insumo">
																  <ItemTemplate>    
																	  <asp:Label runat="server" ID="lblTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Detalle Tipo Insumo">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Observaciones Solicitante">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblObsSol" Text='<%# Eval("ObservacionesSolicitante") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
															  <asp:TemplateField HeaderText="Observaciones Analista">
																  <ItemTemplate>
																	  <asp:Label runat="server" ID="lblObsAnalis" Text='<%# Eval("ObservacionesAnalista") %>'  ></asp:Label>
																  </ItemTemplate>
															  </asp:TemplateField>
														  </Columns>
													  </asp:GridView>
											</div>
											<div class="posts">
												<article>
													<div class="select-wrapper">
														<asp:DropDownList ID="ddlTipoSoporte" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
													</div>
												</article>
												<article>
														<asp:Button runat ="server" Text ="Agregar documento" ID ="btnAgregar" CausesValidation ="false" OnClick="btnAgregar_Click" />
											  </article>
												<article>
													<div class="table-wrapper">
														<asp:GridView ID ="grdDocumentos" runat ="server" CssClass ="Grid" AutoGenerateColumns ="False" EmptyDataText ="No existen registros" OnRowCommand="grdDocumentos_RowCommand">
															<Columns>
																<asp:BoundField  DataField ="NombreTipoSoporte" HeaderText ="Documentos entregados"/>
																<asp:BoundField DataField ="TipoSoporteID" HeaderText ="Codigo" Visible ="false" />
																<asp:TemplateField HeaderText="Quitar">
																	<ItemTemplate>
																	<asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false"  ToolTip="Eliminar Detalle"  ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("TipoSoporteID") %>' />
																	</ItemTemplate>
																</asp:TemplateField>
															</Columns>
														</asp:GridView>
													</div>
											</article>
										</div>

										<div class="posts">
											<article>
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlAccionTramite" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrvalidaAccionTramite" runat="server" errormessage="Debe seleccionar la acción a tomar"  controltovalidate="ddlAccionTramite" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>

											</article>
											<article>
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlInstruccion" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
													<ASP:RequiredFieldValidator id="rqrValidaInstruccion" runat="server" errormessage="Debe indicar la instrucción"  controltovalidate="ddlInstruccion" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</article>
											<article>
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlTipoRemitido" runat="server"  AppendDataBoundItems="True"  ></asp:DropDownList>
												</div>
												<ASP:RequiredFieldValidator id="rqrValidaTipoRemitido" runat="server" errormessage="Debe seleccionar el remitente"  controltovalidate="ddlTipoRemitido" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>

											</article>
										</div>
										<div class="row uniform">
											<div class="12u$">
												<asp:TextBox runat="server" ID="txtObservaciones" TextMode="MultiLine" Rows="2" MaxLength="300" placeholder ="Indique las observaciones"></asp:TextBox>
												<ASP:RequiredFieldValidator id="rqrValidaObs" runat="server" errormessage="Debe colocar las obervaciones"  controltovalidate="txtObservaciones" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
											</div>
										</div>
										<p></p>														
										<div class="posts">
											<article>
												<asp:TextBox runat ="server" placeholder ="Cedula postulado" ID ="txtCedulaPostulante"  MaxLength="9"/>
											</article>
											<article>
												<asp:TextBox runat ="server" placeholder ="Celular postulado" ID ="txtTelefonoPostulante"   pattern="^([0-9]{11})$" title="Debe colocar el codigo seguido del numero sin espacios ni guiones 04127654321" MaxLength="11"/>
											</article>
											<article>
												<asp:Button runat ="server" Text ="Agregar postulado" ID ="Button1" OnClick="btnAgregarPostulante_Click"  />
											</article>
										</div>
  
										<div class="12u$">
											<div class="table-wrapper">
												<asp:GridView ID ="grdSoporte" runat ="server" CssClass ="Grid" AutoGenerateColumns ="False" EmptyDataText ="No existen registros" OnRowCommand="grdSoporte_RowCommand" >
													<Columns>
														<asp:BoundField  DataField ="CedulaPostulante"   HeaderText ="Cedula Postulado" />
														<asp:BoundField DataField ="NombrePostulante" HeaderText ="Nombre Postulado" />
														<asp:BoundField DataField ="Telefono" HeaderText ="Telefono" />
														 <asp:TemplateField HeaderText="Ficha Social">
															  <ItemTemplate>
																  <asp:DropDownList runat="server" ID="ddlEstatus"
																		DataSourceID="SqlDataSource4" 
																		DataTextField ="NombreEstatusFichaSocial"
																		DataValueField ="EstatusFichaSocialID"
																		SelectedValue ='<%# Bind("EstatusFichaSocialID") %>'>
																  </asp:DropDownList>
																<asp:SqlDataSource 
																	ID="SqlDataSource4" 
																	runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
																	SelectCommand="SELECT *  FROM [EstatusFichaSocial] ">
																</asp:SqlDataSource>
															  </ItemTemplate>
														  </asp:TemplateField>
														<asp:TemplateField HeaderText="Quitar">
															<ItemTemplate>
																<asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" CausesValidation="false"  ToolTip="Eliminar Detalle"  ImageUrl="~/Images/eliminar.png"  CommandName="EliminarDetalle" CommandArgument='<%# Bind("CedulaPostulante") %>' />
															</ItemTemplate>
														</asp:TemplateField>
													</Columns>
												</asp:GridView>
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
