//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpProjectOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpProjectOrderInfo
    {
        int ApsCtpProjectOrderInfoSp(ProjNumType PProjNum,
                                     TaskNumType PTaskNum,
                                     ProjmatlSeqType PSeq,
                                     DateType PDueDate,
                                     RefTypeIJKPRTType PRefType,
                                     JobPoProjReqTrnNumType PRefNum,
                                     SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                     ItemType PItem,
                                     ref ApsOrderType PApsOrderId,
                                     ref ApsCategoryType PCategory,
                                     ref ApsBitFlagsType PFlags,
                                     ref DateTimeType PApsDueDate,
                                     ref ApsMaterialType PApsItem,
                                     ref WhseType PWhse,
                                     ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpProjectOrderInfo : IApsCtpProjectOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpProjectOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpProjectOrderInfoSp(ProjNumType PProjNum,
                                            TaskNumType PTaskNum,
                                            ProjmatlSeqType PSeq,
                                            DateType PDueDate,
                                            RefTypeIJKPRTType PRefType,
                                            JobPoProjReqTrnNumType PRefNum,
                                            SuffixPoLineProjTaskReqTrnLineType PRefLineSuf,
                                            ItemType PItem,
                                            ref ApsOrderType PApsOrderId,
                                            ref ApsCategoryType PCategory,
                                            ref ApsBitFlagsType PFlags,
                                            ref DateTimeType PApsDueDate,
                                            ref ApsMaterialType PApsItem,
                                            ref WhseType PWhse,
                                            ref ApsOrdTypeType POrdType)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "ApsCtpProjectOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PProjNum", PProjNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PTaskNum", PTaskNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSeq", PSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PDueDate", PDueDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefType", PRefType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefNum", PRefNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PRefLineSuf", PRefLineSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PApsOrderId", PApsOrderId, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PCategory", PCategory, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PFlags", PFlags, ParameterDirection.InputOutput);
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
