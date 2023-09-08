//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpForecastID.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpForecastID
    {
        int ApsCtpForecastIDSp(ItemType PItem,
                               WhseType PWhse,
                               CustNumType PCustNum,
                               DateTimeType PDate,
                               ref ApsOrderType POrderID);
    }

    public class ApsCtpForecastID : IApsCtpForecastID
    {
        readonly IApplicationDB appDB;

        public ApsCtpForecastID(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpForecastIDSp(ItemType PItem,
                                      WhseType PWhse,
                                      CustNumType PCustNum,
                                      DateTimeType PDate,
                                      ref ApsOrderType POrderID)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpForecastIDSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDate", PDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POrderID", POrderID, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
