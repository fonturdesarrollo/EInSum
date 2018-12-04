<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCNavegacion.ascx.cs" Inherits="Atensoli.Vista.UCNavegacion" %>

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
											<span class="opener">Atención al Ciudadano</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSolicitudes"  navigateurl ="~/Vista/SeleccionarTipoSolicitud.aspx"  Text ="Registrar solicitud"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkConsultarSolicitud"  navigateurl ="~/Vista/ConsultarSolicitud.aspx"  Text ="Consultar seguimiento solicitud"></ASP:HyperLink></li>
											</ul>
										</li>

										<li>
											<span class="opener">Seleccionar solicitud para comenzar seguimiento</span>
												<ul>
													<li><ASP:HyperLink runat="server" ID ="lnkCobranzas"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1023"  Text ="Cobranzas"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkFinanciamiento"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1026"  Text ="Financiamiento"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkMovilidadEstudiantil"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1027"  Text ="Movilidad Estudiantil"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkAsesoriaLegal"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1028"  Text ="Asesoria Legal"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkTecncicaAutomotriz"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1029"  Text ="Tecnica Automotriz"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkOAC"  navigateurl ="~/Vista/SeguimientoSeleccionSolicitud.aspx?CodigoObjeto=1030"  Text ="Control y Seguimiento OAC"></ASP:HyperLink></li>
												</ul>
										</li>

										<li>
											<span class="opener">Seleccionar solicitud en seguimiento</span>
												<ul>
												
													<li><ASP:HyperLink runat="server" ID ="lnkCobranzasSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1023"  Text ="Cobranzas"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkFinanciamientoSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1026"  Text ="Financiamiento"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkMovilidadEstudiantilSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1027"  Text ="Movilidad Estudiantil"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkAsesoriaLegalSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1028"  Text ="Asesoria Legal"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkTecncicaAutomotrizSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1029"  Text ="Tecnica Automotriz"></ASP:HyperLink></li>
													<li><ASP:HyperLink runat="server" ID ="lnkOACSeguimiento"  navigateurl ="~/Vista/SeguimientoSeleccion.aspx?CodigoObjeto=1030"  Text ="Control y Seguimiento OAC"></ASP:HyperLink></li>
												</ul>
											
										</li>
										
										<li>
											<span class="opener">Opciones especiales</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitante"  navigateurl ="~/Vista/TipoSolicitante.aspx" Text ="Tipo de solicitante"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSolicitud"  navigateurl ="~/Vista/TipoSolicitud.aspx" Text ="Tipo de solicitud"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoOrganizacion"  navigateurl ="~/Vista/TipoOrganizacion.aspx" Text ="Tipo de organización"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoAtencion"  navigateurl ="~/Vista/TipoAtencion.aspx" Text ="Tipo de atención"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkReferido"  navigateurl ="~/Vista/TipoReferencia.aspx" Text ="Tipo de referencia"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoRemitido"  navigateurl ="~/Vista/TipoRemitido.aspx" Text ="Tipo de remitido"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoInsumo"  navigateurl ="~/Vista/TipoInsumo.aspx" Text ="Tipo de insumo"></ASP:HyperLink></li>
												<li><ASP:HyperLink runat="server" ID ="lnkTipoSoporteFIsico"  navigateurl ="~/Vista/TipoSoporte.aspx" Text ="Tipo de soporte físico"></ASP:HyperLink></li>
											</ul>
										</li>
										<li>
											<span class="opener">Estadísticas</span>
											<ul>
												<li><ASP:HyperLink runat="server" ID ="lnkSolicitudesCargadas"  navigateurl ="~/Vista/ConsultarSolicitudesCargadas.aspx"  Text ="Solicitudes cargadas"></ASP:HyperLink></li>												
												<li><ASP:HyperLink runat="server" ID ="lnkEstadisticasGenerales"  navigateurl ="~/Vista/EstadisticasGenerales.aspx"  Text ="Estadísticas generales"></ASP:HyperLink></li>
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