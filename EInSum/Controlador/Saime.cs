using Npgsql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace Eisum
{
    public class Saime
    {
       public static List<string> ObtenerDatosSaime(string cedulaSolictante)
       {
            string cedula = "";
            List<string> datosSaime = new List<string>();
            try
            {
                using (NpgsqlConnection connection = new NpgsqlConnection())
                {

                    for (int i = 0; i < 3; i++)
                    {
                        if (cedulaSolictante.Length == 7)
                        {
                            if (i == 0)
                            {
                                cedula = "V0" + cedulaSolictante;
                            }
                            else
                            {
                                cedula = "E0" + cedulaSolictante;
                            }
                        }
                        else if (cedulaSolictante.Length == 6)
                        {
                            if (i == 0)
                            {
                                cedula = "V00" + cedulaSolictante;
                            }
                            else
                            {
                                cedula = "E00" + cedulaSolictante;
                            }
                        }
                        else if (cedulaSolictante.Length > 7)
                        {
                            if (i == 0)
                            {
                                cedula = "V" + cedulaSolictante;
                            }
                            else
                            {
                                cedula = "E" + cedulaSolictante;
                            }

                        }
                        connection.ConnectionString = "Server=172.16.0.41;Port=5432;Database=cdlp;User Id=postgres;Password = postgres;";
                        connection.Open();
                        NpgsqlCommand cmd = new NpgsqlCommand();
                        cmd.Connection = connection;
                        cmd.CommandText = "Select * from partner_card where ci = '" + cedula + "'";
                        //cmd.CommandText = "Select * from partner_card where name = 'Mariana' AND apellido1 = 'Ortiz'";
                        cmd.CommandType = CommandType.Text;

                        NpgsqlDataReader dr;
                        dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);

                        if (dr.HasRows)
                        {
                            while (dr.Read())
                            {
                                datosSaime.Add( dr["ci"].ToString().Replace("V", "").Replace("E", "").TrimStart('0'));
                                datosSaime.Add(dr["name"].ToString());
                                datosSaime.Add(dr["apellido1"].ToString());
                                datosSaime.Add(dr["gender"].ToString());
                                datosSaime.Add(dr["serial_ciudadano"].ToString());
                                //InsertarSAIME(dr["ci"].ToString().Replace("V", "").Replace("E", "").TrimStart('0'), dr["name"].ToString(), dr["apellido1"].ToString());
                                i = 2;
                                break;
                            }
                        }
                        dr.Close();
                        cmd.Dispose();
                        connection.Close();
                    }

                }
            }
            catch (Exception ex)
            {
                datosSaime.Add("ERROR " + ex.Message);
                return datosSaime;
            }
            return datosSaime;
        }
        public static int InsertarSAIME(string cedula, string nombre, string apellido)
        {
            try
            {
                System.Data.SqlClient.SqlParameter[] dbParams = new System.Data.SqlClient.SqlParameter[]
                {
                    Database.Classes.DBHelper.MakeParam("@Cedula", SqlDbType.VarChar, 0, cedula),
                    Database.Classes.DBHelper.MakeParam("@Nombre", SqlDbType.VarChar, 0, nombre),
                    Database.Classes.DBHelper.MakeParam("@Apellido", SqlDbType.VarChar, 0, apellido)
                };

                Database.Classes.DBHelper.ExecuteScalar("[usp_SAIME_Insertar]", dbParams);
                return 1;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}