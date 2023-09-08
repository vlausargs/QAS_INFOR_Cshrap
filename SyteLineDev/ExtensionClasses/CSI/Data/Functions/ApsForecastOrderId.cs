//PROJECT NAME: Data
//CLASS NAME: ApsForecastOrderId.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Data.Functions
{
    public class ApsForecastOrderId : IApsForecastOrderId
    {
        readonly IApplicationDB appDB;

        public ApsForecastOrderId(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public string ApsForecastOrderIdFn(
            string PItem,
            string PWhse,
            string PCustNum,
            DateTime? PDate)
        {
            ItemType _PItem = PItem;
            WhseType _PWhse = PWhse;
            CustNumType _PCustNum = PCustNum;
            DateTimeType _PDate = PDate;

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.Text;
                cmd.CommandText = "SELECT  dbo.[ApsForecastOrderId](@PItem, @PWhse, @PCustNum, @PDate)";

                appDB.AddCommandParameter(cmd, "PItem", _PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", _PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", _PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDate", _PDate, ParameterDirection.Input);

                var Output = appDB.ExecuteScalar<string>(cmd);

                return Output;
            }
        }

        public int? ApsForecastOrderIdSp()
        {

            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsForecastOrderIdSp";

                var Severity = appDB.ExecuteNonQuery(cmd);

                return (Severity);
            }
        }
    }
}
