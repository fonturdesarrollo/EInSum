using Database.Classes;
using System.Data;
using System.Data.SqlClient;


namespace Admin
{
    public partial class Autocomplete
    {

        public static DataSet ObtenerRifOrganizacion(string sQuery, int codigoEstado, int codigoBloque)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                    DBHelper.MakeParam("@EstadoID", SqlDbType.Int, 0, codigoEstado),
                    DBHelper.MakeParam("@BloqueID", SqlDbType.Int, 0, codigoBloque)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerOrganizacionPorRIF", dbParams);
        }
        public static DataSet ObtenerCedulaBeneficiario(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerBeneficiarioPorCedula", dbParams);
        }
        public static DataSet ObtenerNombreInsumo(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerNombreInsumo", dbParams);
        }
        public static DataSet ObtenerPlacaAsignadaJornada(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Placa", SqlDbType.VarChar, 0, sQuery)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerPlacaAsignadaJornada", dbParams);
        }
        public static DataSet ObtenerEmpresas(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerEmpresas", dbParams);
        }
        public static DataSet ObtenerEmpresaSucursal(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerEmpresaSucursal", dbParams);
        }

        //SEGURIDAD ***************************************************
        public static DataSet ObtenerUsuarios(string sQuery, int codigoSucursal)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                    DBHelper.MakeParam("@EmpresaSucursalID", SqlDbType.Int, 0, codigoSucursal)
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerUsuarios", dbParams);
        }
        public static DataSet ObtenerGrupos(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerGrupos", dbParams);
        }
        public static DataSet ObtenerObjetos(string sQuery)
        {
            SqlParameter[] dbParams = new SqlParameter[]
                {
                    DBHelper.MakeParam("@Query", SqlDbType.VarChar, 0, sQuery),
                };
            return DBHelper.ExecuteDataSet("usp_Autocomplete_ObtenerObjetos", dbParams);
        }
        // *****************************************************************
    }
}