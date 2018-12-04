using Database.Classes;
using Seguridad.Clases;
using System;
using System.Data;
using System.Data.SqlClient;

namespace Seguridad
{
    public partial class SeguridadObjetoGrupo
    {
        public static int InsertarObjetoGrupo(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
            {
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                    DBHelper.MakeParam("@SeguridadObjetoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadObjetoID)
            };

            return Convert.ToInt32(DBHelper.ExecuteScalar("usp_SeguridadObjetoGrupo_Insertar", dbParams));
        }
        public static DataSet EliminarObjetoGrupo(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadObjetoAccesoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadObjetoAccesoID),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadObjetoGrupo_EliminarObjetoGrupo", dbParams);
        }
        public static DataSet ObtenerObjetoGrupo(int SeguridadGrupoID, int SeguridadObjetoID)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, SeguridadGrupoID),
                    DBHelper.MakeParam("@SeguridadObjetoID", SqlDbType.Int, 0, SeguridadObjetoID)
                };

            return DBHelper.ExecuteDataSet("[usp_SeguridadObjetoGrupo_ObtenerObjetoGrupo]", dbParams);
        }
        public static DataSet ObtenerObjetosDeGrupo(CSeguridad objetoSeguridad)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@SeguridadGrupoID", SqlDbType.Int, 0, objetoSeguridad.SeguridadGrupoID),
                };

            return DBHelper.ExecuteDataSet("usp_SeguridadObjetoGrupo_ObtenerObjetosGrupo", dbParams);
        }
    }
}