//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpCustomerOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpCustomerOrderInfo
    {
        int ApsCtpCustomerOrderInfoSp(CoNumType PCoNum,
                                      CoLineType PCoLine,
                                      CoReleaseType PCoRelease,
                                      DateType PRequestDate,
                                      DateType PDueDate,
                                      RefTypeIJKPRTType PRefType,
                                      JobPoProjReqTrnNumType PRefNum,
                                      SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                      SiteType PShipSite,
                                      CoitemStatusType PStat,
                                      ItemType PItem,
                                      ref ApsOrderType PApsOrderId,
                                      ref ApsCategoryType PCategory,
                                      ref ApsBitFlagsType PFlags,
                                      ref ApsBitFlagsType PFlags2,
                                      ref DateTimeType PApsRequestDate,
                                      ref DateTimeType PApsDueDate,
                                      ref ApsMaterialType PApsItem,
                                      ref WhseType PWhse,
                                      ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpCustomerOrderInfo : IApsCtpCustomerOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpCustomerOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpCustomerOrderInfoSp(CoNumType PCoNum,
                                             CoLineType PCoLine,
                                             CoReleaseType PCoRelease,
                                             DateType PRequestDate,
                                             DateType PDueDate,
                                             RefTypeIJKPRTType PRefType,
                                             JobPoProjReqTrnNumType PRefNum,
                                             SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                             SiteType PShipSite,
                                             CoitemStatusType PStat,
                                             ItemType PItem,
                                             ref ApsOrderType PApsOrderId,
                                             ref ApsCategoryType PCategory,
                                             ref ApsBitFlagsType PFlags,
                                             ref ApsBitFlagsType PFlags2,
                                             ref DateTimeType PApsRequestDate,
                                             ref DateTimeType PApsDueDate,
                                             ref ApsMaterialType PApsItem,
                                             ref WhseType PWhse,
                                             ref ApsOrdTypeType POrdType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpCustomerOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PCoNum", PCoNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoLine", PCoLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoRelease", PCoRelease, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRequestDate", PRequestDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefType", PRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefNum", PRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefLineSuf", PRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PShipSite", PShipSite, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PStat", PStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderId", PApsOrderId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCategory", PCategory, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags", PFlags, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags2", PFlags2, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsRequestDate", PApsRequestDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsDueDate", PApsDueDate, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PApsItem", PApsItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "POrdType", POrdType, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
