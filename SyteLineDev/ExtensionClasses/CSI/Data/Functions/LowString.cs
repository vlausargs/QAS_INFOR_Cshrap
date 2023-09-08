//PROJECT NAME: Data
//CLASS NAME: LowString.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;
using CSI.MG.MGCore;

namespace CSI.Data.Functions
{
    public class LowString : ILowString
    {
        readonly IApplicationDB appDB;

        public LowString(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string LowStringFn(
            string DataType)
        {
            StringType _DataType = DataType;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[LowString](@DataType)";

                appDB.AddCommandParameter(cmd, "DataType", _DataType, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
