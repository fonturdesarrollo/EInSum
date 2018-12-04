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

                if (Request.QueryString["identifier"] == "Organizacion")
                {
                    int codigoEstado = 0;
                    int codigoBloque = 0;
                    if(Session["CodigoEstado"]!=null)
                    {
                        codigoEstado = Convert.ToInt32(Session["CodigoEstado"]);
                    }
                    if (Session["CodigoBloque"] != null)
                    {
                        codigoBloque = Convert.ToInt32(Session["CodigoBloque"]);
                    }

                    DataSet ds = Autocomplete.ObtenerRifOrganizacion(Request.QueryString["query"] , codigoEstado, codigoBloque);
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
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["RifOrganizacion"].ToString() + "_" + dr["OrganizacionID"].ToString() + "_" + dr["NombreOrganizacion"].ToString() + "_" + dr["NombreTipoOrganizacion"].ToString() + "_" + dr["NombreEstado"].ToString() + "_" + dr["ParroquiaID"].ToString() + "_" + dr["TelefonoLocalOrganizacion"].ToString() + "_" + dr["TelefonoCelularOrganizacion"].ToString() + "_" + dr["EmailOrganizacion"].ToString() + "_" + dr["DireccionOrganizacion"].ToString() + "_" + dr["CedulaPresidente"].ToString() + "_" + dr["NombrePresidente"].ToString() + "_" + dr["TipoOrganizacionID"].ToString() + "_" + dr["MunicipioID"].ToString() + "_" + dr["EstadoID"].ToString() + "_" + dr["BloqueID"].ToString() + "'>" + item.value + "</li>" + "\n");
                        }
                        Response.Write("</ul>");
                        Response.End();
                    }
                }
                if (Request.QueryString["identifier"] == "Beneficiario")
                {
                    DataSet ds = Autocomplete.ObtenerCedulaBeneficiario(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["NombreCompuestoBeneficiario"].ToString();
                            item.id = dr["OrganizacionBeneficiarioID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["TipoBeneficiarioID"].ToString() + "_" + dr["CedulaBeneficiario"].ToString() + "_" + dr["NombreBeneficiario"].ToString() + "_" + dr["ParroquiaID"].ToString() + "_" + dr["TelefonoBeneficiario"].ToString() + "_" + dr["DireccionBeneficiario"].ToString() + "_" + dr["EmailBeneficiario"].ToString() + "_" + dr["NombreParroquia"].ToString() + "_" + dr["NombreMunicipio"].ToString() + "_" + dr["NombreEstado"].ToString() + "_" + dr["NombreTipoBeneficiario"].ToString() + "_" + dr["EstadoID"].ToString() + "_" + dr["MunicipioID"].ToString() + "'>" + item.value + "</li>" + "\n");
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

                if (Request.QueryString["identifier"] == "Placa")
                {
                    DataSet ds = Autocomplete.ObtenerPlacaAsignadaJornada(Request.QueryString["query"]);
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        Response.Write("<ul>" + "\n");
                        paginaBase.AutoCompleteResult item;
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            item = new paginaBase.AutoCompleteResult();
                            item.value = dr["Placa"].ToString();
                            item.id = dr["OrganizacionBeneficiarioID"].ToString();
                            item.value = item.value.Replace(Request.QueryString["query"].ToString(), "<span style='font-weight:bold;'>" + Request.QueryString["query"].ToString() + "</span>");
                            Response.Write("\t" + "<li id=autocomplete_" + item.id + " rel='" + item.id + "_" + dr["Placa"].ToString() + "_" + dr["OrganizacionBeneficiarioID"].ToString() + "_" + dr["CedulaBeneficiario"].ToString() + "_" + dr["NombreBeneficiario"].ToString() + "_" + dr["RifOrganizacion"].ToString() + "_" + dr["NombreOrganizacion"].ToString() + "_" + dr["NombreTipoVehiculo"].ToString() + "_" + dr["NombreAño"].ToString() + "_" + dr["SerialCarroceria"].ToString() + "_" + dr["Puestos"].ToString() + "'>" + item.value + "</li>" + "\n");
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