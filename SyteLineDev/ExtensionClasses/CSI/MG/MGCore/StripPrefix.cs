//PROJECT NAME: Data
//CLASS NAME: StripPrefix.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;

namespace CSI.MG.MGCore
{
    public class StripPrefix : IStripPrefix
    {
        readonly IApplicationDB appDB;


        public StripPrefix(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string StripPrefixFn(string Key)
        {
            LongListType _Key = Key;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[StripPrefix](@Key)";

                appDB.AddCommandParameter(cmd, "Key", _Key, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
