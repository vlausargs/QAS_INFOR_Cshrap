using CSI.MG;
using System.Data;
using System.Data.SqlClient;

namespace CSI.Data.SQL
{
    public class SQLAddCommandParameterWithValue : IAddCommandParameterWithValue
    {
        public IDbDataParameter AddCommandParameterWithValue(IDbCommand cmd, string name, object value, ParameterDirection direction = ParameterDirection.Input)
        {
            var dataParameter = new SqlParameter("@" + name, SqlDbType.NVarChar);
            dataParameter.Direction = direction;
            //dataParameter.Size = csiData.Length;

            if (value == null)
                dataParameter.Value = System.DBNull.Value;
            else
                dataParameter.Value = value;

            cmd.Parameters.Add(dataParameter);


            return dataParameter;
        }
    }
}