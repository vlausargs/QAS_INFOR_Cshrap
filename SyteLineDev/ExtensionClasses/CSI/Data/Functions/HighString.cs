//PROJECT NAME: Data
//CLASS NAME: HighString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class HighString : IHighString
    {
        readonly IApplicationDB appDB;

        public HighString(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string HighStringFn(
            string DataType)
        {
            StringType _DataType = DataType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[HighString](@DataType)";

                appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
