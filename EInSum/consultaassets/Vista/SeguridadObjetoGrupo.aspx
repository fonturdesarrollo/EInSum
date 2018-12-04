<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SeguridadObjetoGrupo.aspx.cs" Inherits="Seguridad.SeguridadObjetoGrupo" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Seguridad | Objeto y Grupos</title>
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

		function Confirmacion() {

			return confirm("¿Realmente desea eliminar este servicio?");
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
									<a class="logo"><strong>Objetos y Grupos</strong></a>
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
													<asp:DropDownList ID="ddlGrupo" runat="server"  AppendDataBoundItems="True" AutoPostBack = "true" OnSelectedIndexChanged="ddlGrupo_SelectedIndexChanged"></asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)"> 
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlObjeto" runat="server"  AppendDataBoundItems="True"  > </asp:DropDownList>
												</div>
											</div>
											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Asignar Objeto" runat="server" ID ="btnAsignar"  CssClass ="special" OnClick="btnAsignar_Click" />
													<li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevo" CausesValidation="False" /></li>
												</ul>
											</div>
											<div class="table-wrapper">
												  <asp:GridView ID="gridDetalle" runat="server" CssClass="subtitulo" EmptyDataText="No existen Registros" 
													  GridLines="Horizontal" AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
														<HeaderStyle CssClass ="registroTitulo" Font-Size="10px" />
														<AlternatingRowStyle CssClass ="registroNormal" Font-Size="10px" />
														  <RowStyle CssClass ="registroAlternado" Font-Size="10px" />
													  <Columns>
														  <asp:TemplateField HeaderText="Nombre de Grupo" HeaderStyle-Width="200">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreGrupo" Text='<%# Eval("NombreGrupo") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Descripción Grupo" HeaderStyle-Width="200">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblDesGrupo" Text='<%# Eval("DescripcionGrupo") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>
														  <asp:TemplateField HeaderText="Nombre Objeto" HeaderStyle-Width="200px">
															  <ItemTemplate>
																  <asp:Label runat="server" ID="lblNombreObjeto" Text='<%# Eval("NombreObjeto") %>'></asp:Label>
															  </ItemTemplate>
														  </asp:TemplateField>

														   <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100px">
															  <ItemTemplate>
																  <asp:ImageButton runat="server" ID="btnEliminar" AlternateText="Eliminar Detalle" OnClientClick="return Confirmacion();" ToolTip="Eliminar Detalle" CssClass="cBotones" ImageUrl="~/Images/eliminar.gif"  CommandName="EliminarDetalle" CommandArgument='<%# Eval("SeguridadObjetoAccesoID") %>'/>
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
		<!-- Scripts -->

<%--        SE COLOCARON EN EL HEADER --%>

	</body>
</html>

