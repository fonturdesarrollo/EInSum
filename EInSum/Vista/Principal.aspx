    <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Principal.aspx.cs" Inherits="EInSum.Principal" %>
<%@ Register TagPrefix="uc2" TagName="UCNavegacion" Src="~/Vista/UCNavegacion.ascx" %>
<!DOCTYPE HTML>
<html>
    <head>
        <title>EInSum | Inicio |</title>
        <meta charset="utf-8" />
        <meta name="viewport" content="width=device-width, initial-scale=1, user-scalable=no" />
        <link rel="stylesheet" href="../assets/css/main.css" />

        <script  src="../js/jquery-ui-1.8rc3.custom.min.js"></script>
        <script src="../assets/js/jquery.min.js"></script>
        <script src="../assets/js/skel.min.js"></script>
        <script src="../assets/js/util.js"></script>
        <script src="../assets/js/main.js"></script>      
    </head>
    <body>
        
        
        <!-- Wrapper -->
            <div id="wrapper">
                
                <!-- Main -->
                    <div id="main">
                        <div class="inner">

                            <!-- Header -->
                                <header id="header">
                                    <a href="index.html" class="logo"><strong>EInSum</strong></a>
                                    <ul class="icons">
                                        <li><a href="#" class="icon fa-twitter"><span class="label">Twitter</span></a></li>
                                        <li><a href="#" class="icon fa-facebook"><span class="label">Facebook</span></a></li>
                                        <li><a href="#" class="icon fa-instagram"><span class="label">Instagram</span></a></li>
                                    </ul>
                                </header>

                            <!-- Banner -->
                                <section id="banner">
                                    <div class="content">
                                        <header>
                                            <h1>Bienvenid@ <%:Session["NombreCompletoUsuario"]%> al sistema EInSum.<br /></h1>
                                            <p><%:Session["NombreEmpresa"]%></p>
                                        </header>
                                    </div>
                                    <span class="image object">
                                        <img src=<%:Session["LogoEmpresa"]%>  alt=""/>
                                    </span>
                                </section>

                            <!-- Section -->
                                <section>

                                    <div class="features">
                                        <article>
                                            <span class="icon fa-diamond"></span>
                                            <div class="content">
                                                <h3>Entrega de Insumos y Suministros</h3>
                                                <p>Seleccione al beneficiario y entregue el suministro.</p>
                                            </div>
                                        </article>
                                        <article>
                                            <span class="icon fa-paper-plane"></span>
                                            <div class="content">
                                                <h3>Entrega de Insumos y Suministros</h3>
                                                <p>Mantenga el control de estatus de las necesidades del solicitante.</p>
                                            </div>
                                        </article>
                                    </div>
                                </section>

                            <!-- Section -->
                                <section>

                                    <div class="posts">

                                    </div>
                                </section>
                        </div>
                    </div>

                <!-- Sidebar -->
<%--					<div id="sidebar">
                        <div class="inner">--%>
                                <uc2:UCNavegacion  runat ="server" ID ="ControlMenu"/>
<%--						</div>
                    </div>--%>
            </div>
        <!-- Scripts -->

    </body>
</html>