//PROJECT NAME: Reporting
//CLASS NAME: GetParmsSingleLineAddress.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class GetParmsSingleLineAddress : IGetParmsSingleLineAddress
    {
        readonly IApplicationDB appDB;

        public GetParmsSingleLineAddress(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetParmsSingleLineAddressSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetParmsSingleLineAddressSp]()";

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
