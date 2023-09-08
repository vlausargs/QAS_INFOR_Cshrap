//PROJECT NAME: Data
//CLASS NAME: ConvertINStr.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ConvertINStr : IConvertINStr
    {
        readonly IApplicationDB appDB;

        public ConvertINStr(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ConvertINStrFn(
            string List)
        {
            LongListType _List = List;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ConvertINStr](@List)";

                appDB.AddCommandParameter(cmd, "List", _List, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
