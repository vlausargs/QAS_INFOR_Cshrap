//PROJECT NAME: Data
//CLASS NAME: HighDecimal.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class HighDecimal : IHighDecimal
    {
        readonly IApplicationDB appDB;


        public HighDecimal(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public decimal? HighDecimalFn(
            string DataType)
        {
            StringType _DataType = DataType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[HighDecimal](@DataType)";

                appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<decimal?>(cmd);

                return Output;
            }
        }
    }
}
