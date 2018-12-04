<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavegacion.ascx.cs" Inherits="Vista.UCNavegacion" %>

<!DOCTYPE HTML>

<html>

	<body>

		<!-- Wrapper -->
			<div id="wrapper">

				<!-- Main -->
				<!-- Sidebar -->
					<div id="sidebar">
						<div class="inner">

							<!-- Search -->


							<!-- Menu -->
							
								<nav id="menu">
									<header class="major">
										<h2>Menu</h2>
									</header>
									<ul>
										<li><a href="Principal.aspx">Inicio</a></li>
										<li>
											<span class="opener">Beneficiarios</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkRegistrarOrganzizaciones"  navigateurl ="~/Vista/Organizacion.aspx"  Text ="Registrar organización"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkRegistrarBeneficiarios"  navigateurl ="~/Vista/Beneficiarios.aspx"  Text ="Registrar beneficiario"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkAsignarVehiculos"  navigateurl ="~/Vista/AsignarVehiculos.aspx"  Text ="Asignar vehículos"></ASP:HyperLink></li>
                                                <li><ASP:HyperLink runat="server" ID ="lnkAsignarEje"  navigateurl ="~/Vista/AsignarEje.aspx"  Text ="Asignar Eje"></ASP:HyperLink></li>
											</ul>
										</li>

										<li>
											<span class="opener">Operativo de entrega</span>
												<ul>
													<li><ASP:HyperLink runat="server" ID ="lnkJornada"  navigateurl ="~/Vista/EntregaInsumoJornada.aspx"  Text ="Crear jornada"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkAsignarBeneficiarios"  navigateurl ="~/Vista/EntregaInsumoDetalleJornada.aspx"  Text ="Asignar beneficiarios a jornada"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkEntrega"  navigateurl ="~/Vista/Entrega.aspx"  Text ="Entrega"></ASP:HyperLink></li>
												</ul>
										</li>

										<li>
											<span class="opener">Inventario</span>
												<ul>
												
													<li><ASP:HyperLink runat="server" ID ="lnkEntradaInventario"  navigateurl ="~/Vista/InventarioEntrada.aspx"  Text ="Entrada de insumos"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkAsignacionInventario"  navigateurl ="~/Vista/InventarioAsignacion.aspx"  Text ="Asignación de insumos"></ASP:HyperLink></li>
                                                    <li><ASP:HyperLink runat="server" ID ="lnkAlmacen"  navigateurl ="~/Vista/Almacen.aspx"  Text ="Almacén"></ASP:HyperLink></li>
												</ul>
											
										</li>
										

										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkMarca"  navigateurl ="~/Vista/MarcaVehiculo.aspx" Text ="Agregar marca"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkModelo"  navigateurl ="~/Vista/ModeloVehiculo.aspx" Text ="Agregar modelo"></ASP:HyperLink></li>
											</ul>
										</li>
										<li>
											<span class="opener">Estadísticas</span>
											<ul>
												<%--<li><ASP:HyperLink runat="server" ID ="lnkSolicitudesCargadas"  navigateurl ="~/Vista/ConsultarSolicitudesCargadas.aspx"  Text ="Solicitudes cargadas"></ASP:HyperLink></li>--%>												
											</ul>
										</li>
										<li>
											<span class="opener">Seguridad</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSeguridad"  navigateurl="~/Vista/Seguridad.aspx" Text ="Agregar / Modificar Usuario"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkCambiarClave"  navigateurl="~/Vista/SeguridadCambiarClave.aspx" Text ="Cambiar Clave"></ASP:HyperLink></li>
											</ul>
										</li>
										<li><a href="Logout.aspx">Salir</a></li>
									</ul>
								</nav>
								
							<!-- Section -->


							<!-- Section -->
							<!-- Footer -->
								<footer id="footer">
									<p><%:Session["NombreCompletoUsuario"]%> <%:Session["NombreEmpresa"]%></p>
									<p class="copyright">&copy; <%= DateTime.Now.ToString("yyy") %> Desarrollado por la Gerencia de Tecnología de la Información, División de Desarrollo. Todos los derechos reservados.</p>
								</footer>
						</div>
					</div>
			</div>
		<!-- Scripts -->
	</body>
</html>