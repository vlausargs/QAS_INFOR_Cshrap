//PROJECT NAME: Data
//CLASS NAME: GetCatalogRowPointer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class GetCatalogRowPointer : IGetCatalogRowPointer
    {
        readonly IApplicationDB appDB;


        public GetCatalogRowPointer(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public Guid? GetCatalogRowPointerFn(
            string CustNum)
        {
            CustNumType _CustNum = CustNum;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetCatalogRowPointer](@CustNum)";

                appDB.AddCommandParameter(cmd, "CustNum", _CustNum, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<Guid?>(cmd);

                return Output;
            }
        }
    }
}
