using Database.Classes;
using Seguridad.Clases;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Seguridad
{
    public partial class SeguridadUsuario
    {
        public static bool EsUsuarioPermitido(HttpSessionState Session, int codigoObjeto)
        {
            bool respuesta = true;
            CSeguridad objetoSeguridad = new CSeguridad();
            if (Session["UserID"] == null)
            {
                respuesta = false;
            }
            if (Session["CodigoSucursalEmpresa"] == null)
            {
                Session.Abandon();
                respuesta = false;
            }
            //Valida que si el usuario esta correctamente loggeado no pueda entrar a modulo no permitido
            if(respuesta == true)
            {
                if(codigoObjeto != 999)
                {
                    objetoSeguridad.SeguridadUsuarioDatosID = Convert.ToInt32(Session["UserId"].ToString());
                    if (objetoSeguridad.EsUsuarioAdministrador() == false)
                    {
                        respuesta = objetoSeguridad.EsAccesoPermitido(codigoObjeto);
                        if(respuesta== false)
                        {
                            Session.Abandon();
                        }
                    }
                    else
                    {
                        respuesta = true;
                    }
                }
                else
                {
                    respuesta = true;
                }
            }
            return respuesta;
        }
        public static int InsertarUsuario(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoSeguridad.SeguridadUsuarioDatosID),
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, objetoSeguridad.LoginUsuario),
                    DBHelper.MakeParam("@ClaveUsuario", SqlDbType.VarChar, 0, objetoSeguridad.ClaveUsuario),
                    DBHelper.MakeParam("@NombreCompleto", SqlDbType.VarChar, 0, objetoSeguridad.NombreCompleto),
                    DBHelper.MakeParam("@DescripcionUsuario", SqlDbType.VarChar, 0, objetoSeguridad.DescripcionUsuario),
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@UsuarioTecnico", SqlDbType.Bit, 0, objetoSeguridad.UsuarioTecnico),
                    DBHelper.MakeParam("@EstatusUsuario", SqlDbType.VarChar, 0,objetoSeguridad.EstatusUsuario),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0,objetoSeguridad.EmpresaSucursalID)
            };
            if (objetoSeguridad.SeguridadUsuarioDatosID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadUsuario_Actualizar]", dbParams));
            }
        }
        public static DataSet ObtenerLogin(string loginDeUsuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@LoginUsuario", SqlDbType.VarChar, 0, loginDeUsuario),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadUsuario_ObtenerLogin", dbParams);
        }
        public static SqlDataReader ObtenerEmpresas(int usuarioID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, usuarioID),
                };

            return DBHelper.ExecuteDataReader("usp_Login_ObtenerEmpresas", dbParams);
        }
        public static SqlDataReader ObtenerLogoEmpresa(int empresaID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, empresaID),
                };

            return DBHelper.ExecuteDataReader("usp_Login_ObtenerLogoEmpresa", dbParams);
        }
        public static int ObtenerCodigoEmpresa(int codigoSucursal)
        {
            int codigoEmpresa = 0;
            SqlDataReader dr;
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal),
                };

            dr = DBHelper.ExecuteDataReader("usp_Login_ObtenerCodigoEmpresa", dbParams);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    codigoEmpresa = dr.GetInt32(1);
                }
            }
            dr.Close();
            return codigoEmpresa;
        }
        public static DataSet ObtenerSucursalesDeUsuario(int codigoUsuario, int codigoEmpresa)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, codigoUsuario),
                    DBHelper.MakeParam("@EmpresaID", SqlDbType.Int, 0, codigoEmpresa)
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadUsuario_ObtenerSucursalesUsuario", dbParams);
        }
        public static DataSet EliminarSucursalUsuario(int codigoUsuario)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioSucursalEmpresaID", SqlDbType.Int, 0, codigoUsuario),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadUsuario_EliminarSucursalUsuario", dbParams);
        }

        public static int GrupoIDUsuarioLogin(int codigoUsuario)
        {
            SqlDataReader dr;
            int codigoGrupo = 0;
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, codigoUsuario),
                };

            dr= DBHelper.ExecuteDataReader("usp_SeguridadUsuario_ObtenerNombreGrupoPorIDUsuario", dbParams);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    codigoGrupo = Convert.ToInt32(dr["SeguridadGrupoID"]);
                }
            }
            dr.Close();
            return  codigoGrupo;
        }

        public static int ObjetoIDUsuarioLogin(int codigoUsuario)
        {
            SqlDataReader dr;
            int codigoObjeto = 0;
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, codigoUsuario),
                };

            dr = DBHelper.ExecuteDataReader("usp_SeguridadUsuario_ObtenerNombreObjetoPorIDUsuario", dbParams);
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    codigoObjeto = Convert.ToInt32(dr["SeguridadObjetoID"]);
                }
            }
            dr.Close();
            return codigoObjeto;
        }

        public void MantenerSesionEnCookie(string textoACifrar, string nombreCookie)
        {

            var textoCookie = Encoding.UTF8.GetBytes(textoACifrar);
            var valorCifrado = Convert.ToBase64String(MachineKey.Protect(textoCookie, "CookieProtegida"));

            //Create cookie object and pass name of the cookie and value to be stored
            HttpCookie cookieObject = new HttpCookie(nombreCookie, valorCifrado);

            //Set expiry time cookie
            cookieObject.Expires.AddDays(360);

            //Add cookie to cookie collection
            Response.Cookies.Add(cookieObject);
        }
        public string CookieDecifrada(string nombreCookie)
        {
            //Decode from Base 64 with the hash ProetectedCookie
            var bytes = Convert.FromBase64String(Request.Cookies[nombreCookie].Value);
            var output = MachineKey.Unprotect(bytes, "CookieProtegida");

            string result = Encoding.UTF8.GetString(output);

            return result;
        }

    }
}