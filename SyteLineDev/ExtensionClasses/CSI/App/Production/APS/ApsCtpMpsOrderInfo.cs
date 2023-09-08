//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpMpsOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpMpsOrderInfo
    {
        int ApsCtpMpsOrderInfoSp(ItemType PItem,
                                 UnknownRefNumLastTranType PRefNum,
                                 DateType PDate,
                                 ref ApsOrderType PApsOrderId,
                                 ref ApsCategoryType PCategory,
                                 ref ApsBitFlagsType PFlags,
                                 ref DateTimeType PApsDueDate,
                                 ref ApsMaterialType PApsItem,
                                 ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpMpsOrderInfo : IApsCtpMpsOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpMpsOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpMpsOrderInfoSp(ItemType PItem,
                                        UnknownRefNumLastTranType PRefNum,
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
                cmd.CommandText = "ApsCtpMpsOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefNum", PRefNum, ParameterDirection.Input);
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
