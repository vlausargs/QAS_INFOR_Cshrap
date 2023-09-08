//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpForecastOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpForecastOrderInfo
    {
        int ApsCtpForecastOrderInfoSp(ItemType PItem,
                                      ref WhseType PWhse,
                                      CustNumType PCustNum,
                                      DateType PDate,
                                      ref ApsOrderType PApsOrderId,
                                      ref ApsCategoryType PCategory,
                                      ref ApsBitFlagsType PFlags,
                                      ref DateTimeType PApsDueDate,
                                      ref ApsMaterialType PApsItem,
                                      ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpForecastOrderInfo : IApsCtpForecastOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpForecastOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpForecastOrderInfoSp(ItemType PItem,
                                             ref WhseType PWhse,
                                             CustNumType PCustNum,
                                             DateType PDate,
                                             ref ApsOrderType PApsOrderId,
                                             ref ApsCategoryType PCategory,
                                             ref ApsBitFlagsType PFlags,
                                             ref DateTimeType PApsDueDate,
                                             ref ApsMaterialType PApsItem,
                                             ref ApsOrdTypeType POrdType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpForecastOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCustNum", PCustNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDate", PDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderId", PApsOrderId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCategory", PCategory, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags", PFlags, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsDueDate", PApsDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsItem", PApsItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POrdType", POrdType, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
