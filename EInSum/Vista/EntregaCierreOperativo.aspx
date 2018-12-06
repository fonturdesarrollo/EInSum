<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregaCierreOperativo.aspx.cs" Inherits="Eisum.EntregaCierreOperativo" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Cierre de Operativo</title>
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

		      return confirm("¿Realmente desea cerrar esta jornada de entrega de insumos?, no podrá deshacer");
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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Cierre de Operativo"></asp:Label></strong></a>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">      
								<section>
									<p></p>
										<div class="row uniform">
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlEntregaInsumoJornada" runat="server" AppendDataBoundItems="true" ></asp:DropDownList>      
                                                    <ASP:RequiredFieldValidator id="RqrValidaJornada" runat="server" errormessage="Debe seleccionar la jornada" controltovalidate="ddlEntregaInsumoJornada" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Cerrar Jornada" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClientClick="return Confirmacion();" OnClick="btnGuardar_Click"   /></li>
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
