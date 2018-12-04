<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AsignarEje.aspx.cs" Inherits="Eisum.AsignarEje" %>

<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Asignar Eje</title>
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
		
	  
	  <script type = "text/javascript">
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Asignar Eje"></asp:Label></strong></a>
									<ul class="icons">
										<asp:Label runat ="server" ID ="lblTitulo2" Text="Agregar Eje"></asp:Label>
									</ul>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlEstado" runat="server" AppendDataBoundItems="true"></asp:DropDownList>      
												</div>
											</div>
											<div class="6u 12u$(xsmall)">
												<div class="select-wrapper">
													<asp:DropDownList ID="ddlBloque" runat="server" AppendDataBoundItems="true" OnSelectedIndexChanged="ddlBloque_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>      
												</div>
											</div>
									</div>
								</section>

								<div class="table-wrapper">
									<asp:Label runat ="server" ID ="Label1" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>
										<div class="table-wrapper">
									        <asp:Label runat ="server" ID ="Label2" Text ="" Font-Bold ="true" ForeColor ="Red"></asp:Label>
									        <p></p>
										        <asp:GridView ID="gridDetalle" runat="server" 
											        CssClass="subtitulo" 
											        EmptyDataText="No existen Registros" 
											        GridLines="Horizontal" 
											        AutoGenerateColumns="False" OnRowCommand="gridDetalle_RowCommand" >
											        <HeaderStyle  Font-Size="10px" />
											        <AlternatingRowStyle Font-Size="10px" />
												        <RowStyle  Font-Size="10px" />
												        <Columns>
												        <asp:TemplateField HeaderText="CodigoOrganizacion" HeaderStyle-Width="0" Visible="false">
													        <ItemTemplate>
														        <asp:Label runat="server" ID="lblCodigoOrganizacion" Text='<%# Eval("OrganizacionID") %>'  Visible ="false" ></asp:Label>
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
											        <asp:TemplateField HeaderText="Estado" >
												        <ItemTemplate>
													        <asp:Label runat="server" ID="lblEstadoGrid" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
												        </ItemTemplate>
											        </asp:TemplateField>
											        <asp:TemplateField HeaderText="Eje">
												        <ItemTemplate>
													        <div class="select-wrapper">
														        <asp:DropDownList runat="server" ID="ddlEje"
															        DataSourceID="SqlDataSource1" 
															        DataTextField ="NombreCompuesto"
															        DataValueField ="EjeID"
															        SelectedValue ='<%# Bind("EjeID") %>'>
														        </asp:DropDownList>
											                    <asp:SqlDataSource 
												                    ID="SqlDataSource1" 
												                    runat="server" ConnectionString="<%$ ConnectionStrings:CallCenterConnectionString %>" 
												                    SelectCommand="SELECT EjeID, NombreEje + ': ' + DescripcionEje AS NombreCompuesto, NombreEje FROM dbo.Eje ORDER BY NombreEje">
											                    </asp:SqlDataSource>
													        </div>
												        </ItemTemplate>
											        </asp:TemplateField>
											        <asp:TemplateField HeaderText="Acciones" HeaderStyle-Width="100">
												        <ItemTemplate>
														        <asp:ImageButton runat="server" ID="btnActualizarModificacionGrid" AlternateText="Guardar cambios" ToolTip="Guardar cambios" ImageUrl="~/Images/Save_37110.png"  CommandName="GuardarCambiosGrid" CommandArgument='<%# Eval("OrganizacionID") %>' CausesValidation ="false"/> 
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
								<uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
<%--						</div>
					</div>--%>
			</div>
	</body>
</html>

