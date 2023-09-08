//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpTransferOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpTransferOrderInfo
    {
        int ApsCtpTransferOrderInfoSp(TrnNumType PTrnNum,
                                      TrnLineType PTrnLine,
                                      SiteType PFromSite,
                                      SiteType PToSite,
                                      ref WhseType PFromWhse,
                                      ref WhseType PToWhse,
                                      DateType PSchShipDate,
                                      DateType PSchRcvDate,
                                      ItemType PItem,
                                      RefTypeIJKPRTType PRefType,
                                      JobPoProjReqTrnNumType PRefNum,
                                      SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                      ref ApsOrderType PApsOrderId,
                                      ref ApsCategoryType PCategory,
                                      ref ApsBitFlagsType PFlags,
                                      ref ApsBitFlagsType PFlags2,
                                      ref DateTimeType PApsDueDate,
                                      ref SiteType PApsSite,
                                      ref ApsMaterialType PApsItem,
                                      ref IntType PIsTransferOut,
                                      ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpTransferOrderInfo : IApsCtpTransferOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpTransferOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpTransferOrderInfoSp(TrnNumType PTrnNum,
                                             TrnLineType PTrnLine,
                                             SiteType PFromSite,
                                             SiteType PToSite,
                                             ref WhseType PFromWhse,
                                             ref WhseType PToWhse,
                                             DateType PSchShipDate,
                                             DateType PSchRcvDate,
                                             ItemType PItem,
                                             RefTypeIJKPRTType PRefType,
                                             JobPoProjReqTrnNumType PRefNum,
                                             SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                             ref ApsOrderType PApsOrderId,
                                             ref ApsCategoryType PCategory,
                                             ref ApsBitFlagsType PFlags,
                                             ref ApsBitFlagsType PFlags2,
                                             ref DateTimeType PApsDueDate,
                                             ref SiteType PApsSite,
                                             ref ApsMaterialType PApsItem,
                                             ref IntType PIsTransferOut,
                                             ref ApsOrdTypeType POrdType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpTransferOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PTrnNum", PTrnNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTrnLine", PTrnLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFromSite", PFromSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PToSite", PToSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PFromWhse", PFromWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PToWhse", PToWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PSchShipDate", PSchShipDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSchRcvDate", PSchRcvDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefType", PRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefNum", PRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefLineSuf", PRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderId", PApsOrderId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCategory", PCategory, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags", PFlags, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags2", PFlags2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsDueDate", PApsDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsSite", PApsSite, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsItem", PApsItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PIsTransferOut", PIsTransferOut, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POrdType", POrdType, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
