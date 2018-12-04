using Database.Classes;
using Seguridad.Clases;
using System;
using System.Data;
using System.Data.SqlClient;


namespace Seguridad
{
    public partial class SeguridadGrupo
    {
        public static int InsertarGrupo(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@NombreGrupo", SqlDbType.VarChar, 0, objetoSeguridad.NombreGrupo),
                    DBHelper.MakeParam("@DescripcionGrupo", SqlDbType.VarChar, 0, objetoSeguridad.DescripcionGrupo)
            };
            if (objetoSeguridad.SeguridadGrupoID == 0)
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadGrupo_Insertar]", dbParams));
            }
            else
            {
                return Convert.ToInt32(DBHelper.ExecuteScalar("[usp_SeguridadGrupo_Actualizar]", dbParams));
            }
        }
    }
}