//PROJECT NAME: Data
//CLASS NAME: GetSalesPeriod.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class GetSalesPeriod : IGetSalesPeriod
    {
        readonly IApplicationDB appDB;


        public GetSalesPeriod(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string GetSalesPeriodFn(DateTime? TransDate)
        {
            DateTimeType _TransDate = TransDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[GetSalesPeriod](@TransDate)";

                appDB.AddCommandParameter(cmd, "TransDate", _TransDate, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }
    }
}
