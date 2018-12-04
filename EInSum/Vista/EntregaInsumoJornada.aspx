<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EntregaInsumoJornada.aspx.cs" Inherits="Eisum.EntregaInsumoJornada" %>
<%@ Register TagPrefix="MsgBox" Src="~/Vista/UCMessageBox.ascx" TagName="UCMessageBox" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>


<!DOCTYPE HTML>

<html>
    <head>
        <title>Eisum | Crear Jornada Entrega de Insumos</title>
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
         <script type="text/javascript">
		        $(function () {
		            $('#txtCantidad').keydown(function (e) {
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

		        $(function () {

		            //Array para dar formato en español
		            $.datepicker.regional['es'] =
                    {
                        closeText: 'Cerrar',
                        prevText: 'Previo',
                        nextText: 'Próximo',

                        monthNames: ['Enero', 'Febrero', 'Marzo', 'Abril', 'Mayo', 'Junio',
                        'Julio', 'Agosto', 'Septiembre', 'Octubre', 'Noviembre', 'Diciembre'],
                        monthNamesShort: ['Ene', 'Feb', 'Mar', 'Abr', 'May', 'Jun',
                        'Jul', 'Ago', 'Sep', 'Oct', 'Nov', 'Dic'],
                        monthStatus: 'Ver otro mes', yearStatus: 'Ver otro año',
                        dayNames: ['Domingo', 'Lunes', 'Martes', 'Miércoles', 'Jueves', 'Viernes', 'Sábado'],
                        dayNamesShort: ['Dom', 'Lun', 'Mar', 'Mie', 'Jue', 'Vie', 'Sáb'],
                        dayNamesMin: ['Do', 'Lu', 'Ma', 'Mi', 'Ju', 'Vi', 'Sa'],
                        dateFormat: 'dd/mm/yy', firstDay: 0,
                        initStatus: 'Selecciona la fecha', isRTL: false
                    };
		            $.datepicker.setDefaults($.datepicker.regional['es']);

		            $("#txtFechaJornada").datepicker({
		                dateFormat: 'dd/mm/yy', buttonImageOnly: false, changeMonth: true,
		                changeYear: true, gotoCurrent: true, yearRange: "1900:2020"
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
                                    <a class="logo"><strong><asp:Label runat ="server" ID ="lblTitulo" Text="Crear Jornada Entrega de Insumos"></asp:Label></strong></a>
                                </header>
                            <!-- Content -->
                            <form runat ="server" id ="principal">
                                <section>
                                    <p></p>
                                        <div class="row uniform">
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtFechaJornada"   MaxLength="20" placeholder="Fecha Jornada"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidaFechaJornada" runat="server" errormessage="Debe colocar la fecha de la jornada" controltovalidate="txtFechaJornada" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                             <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtDescripcionJornada"   MaxLength="100" placeholder="Descripción / Nombre de la Jornada"  />
                                                <ASP:RequiredFieldValidator id="rqrvalidatxtDescripcionJornada" runat="server" errormessage="Debe colocar Descripción / Nombre de la Jornada" controltovalidate="txtDescripcionJornada" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddEstado" runat="server" AppendDataBoundItems="true"  AutoPostBack ="true" OnSelectedIndexChanged="ddEstado_SelectedIndexChanged"></asp:DropDownList>      
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <div class="select-wrapper">
                                                    <asp:DropDownList ID="ddlAlmacen" runat="server" AppendDataBoundItems="true"  ></asp:DropDownList>      
                                                    <ASP:RequiredFieldValidator id="rqrvValidaAlmacen" runat="server" errormessage="Debe seleccionar el almacén" controltovalidate="ddlAlmacen" display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                                </div>
                                            </div>
                                            <div class="6u 12u$(xsmall)">
                                                <asp:TextBox runat="server" ID="txtDireccionJornada" MaxLength="150" TextMode="MultiLine" Rows="2"  placeholder ="Dirección de la jornadada de entrega"  />
                                                <ASP:RequiredFieldValidator id="rqrValidatxtDireccionJornada" runat="server" errormessage="Debe colocar la dirección de la jornada" controltovalidate="txtDireccionJornada"  display="Dynamic" ForeColor ="Red"></ASP:RequiredFieldValidator>
                                            </div>
                                            <div class="12u$">
                                                <ul class="actions">
                                                    <li><asp:Button Text="Registrar Jornada" runat="server" ID ="btnGuardar"  CssClass ="special"  OnClick="btnGuardar_Click"   /></li>
                                                    <li><asp:Button Text="Nuevo Registro" runat="server" ID ="btnNuevo" CausesValidation="False"  /></li>
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
											            AutoGenerateColumns="False" >
											            <HeaderStyle  Font-Size="10px" />
											            <AlternatingRowStyle Font-Size="10px" />
												            <RowStyle  Font-Size="10px" />
												            <Columns>
												            <asp:TemplateField HeaderText="Fecha jornada">
													            <ItemTemplate>
														            <asp:Label runat="server" ID="lblFecha" Text='<%# Eval("FechaCortaJornada") %>'  ></asp:Label>
													            </ItemTemplate>
												            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Nombre Jornada" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreJornada" Text='<%# Eval("NombreJornada") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Estado" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblNombreEstado" Text='<%# Eval("NombreEstado") %>'  ></asp:Label>
												            </ItemTemplate>
											            </asp:TemplateField>
											            <asp:TemplateField HeaderText="Dirección" >
												            <ItemTemplate>
													            <asp:Label runat="server" ID="lblDireccion" Text='<%# Eval("DireccionEntregaInsumo") %>'  ></asp:Label>
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

