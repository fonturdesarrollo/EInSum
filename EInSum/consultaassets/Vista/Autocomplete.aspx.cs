using System;
using System.Data;



namespace Admin
{
    public partial class Autocomplete : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString["query"] != "")
            {


                if (Request.QueryString["identifier"] == "Solicitante")
                {
                    DataSet ds = Autocomplete.ObtenerCedulaSolicitante(Request.QueryString["query"],  Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["DescripcionSolicitante"].ToString();
                            item.id = dr["SolicitanteID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["CedulaSolicitante"].ToString() + "_" + dr["SolicitanteID"].ToString() + "_" + dr["NombreSolicitante"].ToString() + "_" + dr["ApellidoSolicitante"].ToString() + "_" + dr["Sexo"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Organizacion")
                {
                    DataSet ds = Autocomplete.ObtenerRifOrganizacion(Request.QueryString["query"], Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreCompuestoOrganizacion"].ToString();
                            item.id = dr["OrganizacionID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["RifOrganizacion"].ToString() + "_" + dr["OrganizacionID"].ToString() + "_" + dr["NombreOrganizacion"].ToString() + "_" + dr["NombreTipoOrganizacion"].ToString() + "_" + dr["NombreEstado"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Insumo")
                {
                    DataSet ds = Autocomplete.ObtenerNombreInsumo(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoInsumo"].ToString();
                            item.id = dr["TipoInsumoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoInsumo"].ToString() + "_" + dr["TipoInsumoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Referencia")
                {
                    DataSet ds = Autocomplete.ObtenerNombreReferencia(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoReferenciaSolicitud"].ToString();
                            item.id = dr["TipoReferenciaSolicitudID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoReferenciaSolicitud"].ToString() + "_" + dr["TipoReferenciaSolicitudID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoSolicitante")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoSolitante(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoSolicitante"].ToString();
                            item.id = dr["TipoSolicitanteID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoSolicitante"].ToString() + "_" + dr["TipoSolicitanteID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoSolicitud")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoSolitud(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoSolicitud"].ToString();
                            item.id = dr["TipoSolicitudID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoSolicitud"].ToString() + "_" + dr["TipoSolicitudID"].ToString() + "_" + dr["DescripcionTipoSolicitud"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoOrganizacion")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoOrganizacion(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoOrganizacion"].ToString();
                            item.id = dr["TipoOrganizacionID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoOrganizacion"].ToString() + "_" + dr["TipoOrganizacionID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoAtencion")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoAtencion(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoAtencionBrindada"].ToString();
                            item.id = dr["TipoAtencionBrindadaID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoAtencionBrindada"].ToString() + "_" + dr["TipoAtencionBrindadaID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoSoporte")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoSoporte(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoSoporte"].ToString();
                            item.id = dr["TipoSoporteID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoSoporte"].ToString() + "_" + dr["TipoSoporteID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "TipoRemitido")
                {
                    DataSet ds = Autocomplete.ObtenerNombreTipoRemitido(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreTipoRemitido"].ToString();
                            item.id = dr["TipoRemitidoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreTipoRemitido"].ToString() + "_" + dr["TipoRemitidoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Empresas")
                {
                    DataSet ds = Autocomplete.ObtenerEmpresas(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreEmpresa"].ToString();
                            item.id = dr["EmpresaID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreEmpresa"].ToString() + "_" + dr["EmpresaID"].ToString() + "_" + dr["RIFEmpresa"].ToString() + "_" + dr["DireccionEmpresa"].ToString() + "_" + dr["TelefonoEmpresa"].ToString() + "_" + dr["EMailEmpresa"].ToString() + "_" + dr["TwitterEmpresa"].ToString() + "_" + dr["InstagramEmpresa"].ToString() + "_" + dr["FacebookEmpresa"].ToString() + "_" + dr["LogoEmpresa"].ToString() + "_" + dr["WebEmpresa"].ToString() + "_" + dr["EstatusEmpresaID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "EmpresaSucursal")
                {
                    DataSet ds = Autocomplete.ObtenerEmpresaSucursal(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreSucursal"].ToString();
                            item.id = dr["EmpresaSucursalID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreSucursal"].ToString() + "_" + dr["EmpresaSucursalID"].ToString() + "_" + dr["DireccionSucursal"].ToString() + "_" + dr["TelefonoSucursal"].ToString() + "_" + dr["EmpresaID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Usuarios")
                {
                    DataSet ds = Autocomplete.ObtenerUsuarios(Request.QueryString["query"], Convert.ToInt32(Session["CodigoSucursalEmpresa"]));
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreCompleto"].ToString();
                            item.id = dr["SeguridadUsuarioDatosID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreCompleto"].ToString() + "_" + dr["LoginUsuario"].ToString() + "_" + dr["ClaveUsuario"].ToString() + "_" + dr["DescripcionUsuario"].ToString() + "_" + dr["SeguridadGrupoID"].ToString() + "_" + dr["UsuarioTecnico"].ToString() + "_" + dr["EstatusUsuario"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Grupos")
                {
                    DataSet ds = Autocomplete.ObtenerGrupos(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreGrupo"].ToString();
                            item.id = dr["SeguridadGrupoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreGrupo"].ToString() + "_" + dr["DescripcionGrupo"].ToString() + "_" + dr["SeguridadGrupoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Objetos")
                {
                    DataSet ds = Autocomplete.ObtenerObjetos(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreObjeto"].ToString();
                            item.id = dr["SeguridadObjetoID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["NombreObjeto"].ToString() + "_" + dr["SeguridadObjetoID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
            }
        }
    }
}