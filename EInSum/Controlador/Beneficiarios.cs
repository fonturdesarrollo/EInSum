using Database.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Eisum
{
    public partial class Beneficiarios
    {
        public static int InsertarBeneficiario(CBeneficiario objetoBeneficiario)
        {
            try
            {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@OrganizacionBeneficiarioID", SqlDbType.Int, 0, objetoBeneficiario.OrganizacionBeneficiarioID),
                    DBHelper.MakeParam("@TipoBeneficiarioID", SqlDbType.Int, 0, objetoBeneficiario.TipoBeneficiarioID),
                    DBHelper.MakeParam("@CedulaBeneficiario", SqlDbType.Int, 0, objetoBeneficiario.CedulaBeneficiario),
                    DBHelper.MakeParam("@NombreBeneficiario", SqlDbType.VarChar, 0, objetoBeneficiario.NombreBeneficiario),
                    DBHelper.MakeParam("@ParroquiaID", SqlDbType.Int, 0,objetoBeneficiario.ParroquiaID),
                    DBHelper.MakeParam("@TelefonoBeneficiario", SqlDbType.VarChar, 0, objetoBeneficiario.TelefonoBeneficiario),
                    DBHelper.MakeParam("@DireccionBeneficiario", SqlDbType.VarChar, 0, objetoBeneficiario.DireccionBeneficiario),
                    DBHelper.MakeParam("@EmailBeneficiario", SqlDbType.VarChar, 0, objetoBeneficiario.EmailBeneficiario),
                    DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, objetoBeneficiario.SeguridadUsuarioDatosID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_Beneficiario_Insertar]", dbParams));
            }
            catch (Exception)
            {

                throw;
            }
        }
        public static int CruzarBeneficiario()
        {
            SqlDataReader dr = ObtenerBeneficiario();
            if (dr.HasRows)
            {
                while (dr.Read())
                {
                    string cedulaBen = dr["CEDULA"].ToString();

                        var nombreBen = CargarValorSaime(cedulaBen.Replace(".", "").Trim());

                        if (nombreBen != "")
                        {
                            try
                            {
                                SqlParameter[] dbParams = new SqlParameter[]
                                {
                                DBHelper.MakeParam("@OrganizacionBeneficiarioID", SqlDbType.Int, 0, 0),
                                DBHelper.MakeParam("@TipoBeneficiarioID", SqlDbType.Int, 0, 1),
                                DBHelper.MakeParam("@CedulaBeneficiario", SqlDbType.Int, 0, cedulaBen.Replace(".","").Trim()),
                                DBHelper.MakeParam("@NombreBeneficiario", SqlDbType.VarChar, 0, nombreBen),
                                DBHelper.MakeParam("@ParroquiaID", SqlDbType.Int, 0,1124),
                                DBHelper.MakeParam("@TelefonoBeneficiario", SqlDbType.VarChar, 0, ""),
                                DBHelper.MakeParam("@DireccionBeneficiario", SqlDbType.VarChar, 0, ""),
                                DBHelper.MakeParam("@EmailBeneficiario", SqlDbType.VarChar, 0, "IMPORTADO"),
                                DBHelper.MakeParam("@SeguridadUsuarioDatosID", SqlDbType.Int, 0, 1)
                                };
                                Convert.ToInt32(DBHelper.ExecuteScalar("[usp_ImportarBeneficiario_Insertar]", dbParams));
                            }
                            catch (Exception)
                            {

                                throw;
                            }
                        }
                }
            }
            return 0; 
        }
        public static SqlDataReader ObtenerBeneficiario()
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
   
                };
            return DBHelper.ExecuteDataReader("usp_Importar_ImportadoExcel", dbParams);
        }
        private static string CargarValorSaime(string cedula )
        {
            string resultado = "";
            int contador = 0;
                foreach (var saime in Saime.ObtenerDatosSaime(cedula))
                {
                    //Si ocurre algún error de conexión en la BD SAIME se sale de la busqueda
                    if (saime.Contains("ERROR "))
                    {
                        break;
                    }
                    switch (contador)
                    {
                        case 0:
                             contador = 1;
                            break;
                        case 1:
                                resultado = saime;
                                contador = 2;
                                break;
                        case 2:
                            resultado += " " + saime;
                            contador = 3;
                            break;

                    }
                }
                return resultado;
 
        }

    }
}