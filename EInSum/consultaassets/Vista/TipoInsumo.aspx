<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TipoInsumo.aspx.cs" Inherits="Atensoli.TipoInsumo" %>

<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>

<!DOCTYPE HTML>

<html>
	<head>
		<title>Atensoli | Insumos</title>
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
					$('#txtNombreInsumo').simpleAutoComplete('Autocomplete.aspx', {
						autoCompleteClassName: 'autocomplete',
						selectedClassName: 'sel',
						attrCallBack: 'rel',
						identifier: 'Insumo'
					}, fnPersonalCallBack);

				});

				function fnPersonalCallBack(par) {
					document.getElementById("hdnTipoInsumoID").value = par[0]; 
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
									<a class="logo"><strong>Agregar Insumos</strong></a>
									<ul class="icons">

									</ul>
								</header>

							<!-- Content -->
							<form runat ="server" id ="principal">	
								<section>
										<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
													<asp:TextBox runat="server" ID="txtNombreInsumo" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Indique el nombre del insumo"/> 
													<asp:HiddenField runat ="server" ID ="hdnTipoInsumoID"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)">
												<ul class="actions">
													<asp:Button Text="Guardar insumo" runat="server" ID ="btnGuardarInsumo"  CssClass ="special" OnClick="btnGuardarInsumo_Click" />
												</ul>
											</div>

											<div class="12u$">
												
												<div class="content">
													<h3><asp:Label runat ="server" ID ="lblDetalleInsumo" Text ="Detalle del insumo"></asp:Label></h3>
												</div>                                        
											</div>

											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID ="ddlInsumo" runat ="server" AppendDataBoundItems ="true"  AutoPostBack ="true" OnSelectedIndexChanged="ddlInsumo_SelectedIndexChanged"> </asp:DropDownList>
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtNombreDetalleInsumo" MaxLength="100" onkeypress="return event.keyCode!=13;" placeholder ="Indique el nombre del detalle insumo"/>
											</div>

											<div class="12u$">
												<ul class="actions">
													<asp:Button Text="Guardar detalle insumo" runat="server" ID ="Button1"  CssClass ="special" OnClick="Button1_Click" />												   
												</ul>
											</div>
											<div class="12u$">
											    <div class="table-wrapper">
												      <asp:GridView ID="gridDetalle" runat="server" 
													      CssClass="subtitulo" 
													      EmptyDataText="No existen Registros" 
													      GridLines="Horizontal" 
													      AutoGenerateColumns="False">
														    <HeaderStyle  Font-Size="10px" />
														    <AlternatingRowStyle Font-Size="10px" />
														      <RowStyle  Font-Size="10px" />
													      <Columns>
														      <asp:TemplateField HeaderText="Nombre tipo insumo">
															      <ItemTemplate>
																      <asp:Label runat="server" ID="lblNombreTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
															      </ItemTemplate>
														      </asp:TemplateField>
														      <asp:TemplateField HeaderText="Detalle tipo insumo" >
															      <ItemTemplate>
																      <asp:Label runat="server" ID="lblNombreTipoInsumoDetalle" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
															      </ItemTemplate>
														      </asp:TemplateField>
													      </Columns>
												      </asp:GridView>
											    </div>
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


