<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Entrega.aspx.cs" Inherits="Eisum.Entrega" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
	<head>
		<title>Eisum | Entrega de Insumos al Beneficiario</title>
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

		  $(function () {
		      $('#txtPlaca').simpleAutoComplete('Autocomplete.aspx', {
					  autoCompleteClassName: 'autocomplete',
					  selectedClassName: 'sel',
					  attrCallBack: 'rel',
					  identifier: 'Placa'
				  }, fnPersonalCallBack2);
			  });

		  function fnPersonalCallBack2(par) {
              document.getElementById("hdnBeneficiarioID").value = par[0];
		      document.getElementById("txtCedulaBeneficiario").value = par[3] + ' ' + par[4];
		      document.getElementById("txtRifOrganizacion").value = par[5] + ' ' + par[6];
		      document.getElementById("txtSerialCarroceria").value =  "Serial carroceria: " + par[9];
		      document.getElementById("txtTipoVehiculo").value = "Tipo: " +par[7];
		      document.getElementById("txtPuestos").value = par[10] + ' ' + " Puestos";
		      document.getElementById("txtAñoVehiculo").value = "Año: " +par[8];

              document.getElementById("txtRifOrganizacion").readOnly = true;
              document.getElementById("txtCedulaBeneficiario").readOnly = true;

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
									<a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Entrega de Insumos al Beneficiario"></asp:Label></strong></a>
								</header>
							<!-- Content -->
							<form runat ="server" id ="principal">      
								<section>
									<p></p>
										<div class="row uniform">
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtPlaca"  MaxLength="7" placeholder ="Placa" pattern="[A-Za-z0-9]+" title="Solo se permiten letras y numeros"/>
												<ASP:RequiredFieldValidator id="rqrvalidaPlaca" runat="server" errormessage="Debe colocar la Placa del Vehiculo" controltovalidate="txtPlaca" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                <asp:HiddenField runat ="server" ID ="hdnBeneficiarioID"  Value="0"/> 
											</div>
											<div class="6u 12u$(xsmall)"> 
  												<asp:TextBox runat="server" ID="txtCedulaBeneficiario"  placeholder="Cedula / nombre beneficiario" />
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtRifOrganizacion"    placeholder="RIF  / nombre de la organización" />
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtSerialCarroceria"  placeholder ="Serial de carroceria"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtTipoVehiculo"  placeholder ="Tipo de vehículo"/>
											</div>

											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtPuestos"   placeholder ="Puestos vehículo"/>
											</div>
											<div class="6u 12u$(xsmall)">
												<asp:TextBox runat="server" ID="txtAñoVehiculo"  placeholder ="Año vehículo"/>
											</div>
											<div class="12u$">
												<ul class="actions">
													<li><asp:Button Text="Asignar insumo" runat="server" ID ="btnGuardar"  CssClass ="special" OnClick ="btnGuardar_Click"    /></li>
                                                    <li><asp:Button Text="Nuevo registro" runat="server" ID ="btnNuevoRegistro"   CausesValidation="False"  OnClick ="btnNuevoRegistro_Click" /></li>
													<li><asp:Button Text="TEST" runat="server" ID ="ButtonTest"  style="display:none"  OnClick ="ButtonTest_Click" CausesValidation="False"   /></li>
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
											AutoGenerateColumns="False"  >
											<HeaderStyle  Font-Size="10px" />
											<AlternatingRowStyle Font-Size="10px" />
												<RowStyle  Font-Size="10px" />
												<Columns>
												<asp:TemplateField HeaderText="Fecha">
													<ItemTemplate>
														<asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCorta") %>'  ></asp:Label>
													</ItemTemplate>
												</asp:TemplateField>
											<asp:TemplateField HeaderText="Tipo insumo" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblTipoInsumo" Text='<%# Eval("NombreTipoInsumo") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Descripción insumo" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblDetalleInsumo" Text='<%# Eval("NombreTipoInsumoDetalle") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Cantidad asignada" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblCantidad" Text='<%# Eval("CantidadEntregaInsumo") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
											<asp:TemplateField HeaderText="Unidad de medida" >
												<ItemTemplate>
													<asp:Label runat="server" ID="lblUM" Text='<%# Eval("NombreUnidadMedida") %>'  ></asp:Label>
												</ItemTemplate>
											</asp:TemplateField>
										</Columns>
										</asp:GridView>
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


