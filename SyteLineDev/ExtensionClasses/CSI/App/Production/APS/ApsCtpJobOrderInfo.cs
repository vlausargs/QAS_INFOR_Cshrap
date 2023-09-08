//PROJECT NAME: CSIAPS
//CLASS NAME: ApsCtpJobOrderInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production.APS
{
    public interface IApsCtpJobOrderInfo
    {
        int ApsCtpJobOrderInfoSp(JobType PJob,
                                 SuffixType PSuffix,
                                 JobStatusType PJobStat,
                                 DateType PEndDate,
                                 ItemType PItem,
                                 JobTypeType PJobType,
                                 RefTypeIKOTType PJobOrdType,
                                 CoProjTrnNumType PJobOrdNum,
                                 CoProjTaskTrnLineType PJobOrdLine,
                                 CoReleaseType PJobOrdRel,
                                 JobType PJobRefJob,
                                 SuffixType PJobRefSuf,
                                 OperNumType PJobRefOper,
                                 JobmatlSequenceType PJobRefSeq,
                                 CoProductMixType PCoProductMix,
                                 ref ApsOrderType PApsOrderId,
                                 ref ApsCategoryType PCategory,
                                 ref ApsBitFlagsType PFlags,
                                 ref DateTimeType PApsDueDate,
                                 ref ApsMaterialType PApsItem,
                                 ref WhseType PWhse,
                                 ref ApsOrdTypeType POrdType);
    }

    public class ApsCtpJobOrderInfo : IApsCtpJobOrderInfo
    {
        readonly IApplicationDB appDB;

        public ApsCtpJobOrderInfo(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int ApsCtpJobOrderInfoSp(JobType PJob,
                                        SuffixType PSuffix,
                                        JobStatusType PJobStat,
                                        DateType PEndDate,
                                        ItemType PItem,
                                        JobTypeType PJobType,
                                        RefTypeIKOTType PJobOrdType,
                                        CoProjTrnNumType PJobOrdNum,
                                        CoProjTaskTrnLineType PJobOrdLine,
                                        CoReleaseType PJobOrdRel,
                                        JobType PJobRefJob,
                                        SuffixType PJobRefSuf,
                                        OperNumType PJobRefOper,
                                        JobmatlSequenceType PJobRefSeq,
                                        CoProductMixType PCoProductMix,
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
                cmd.CommandText = "ApsCtpJobOrderInfoSp";

                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobStat", PJobStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PEndDate", PEndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobType", PJobType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobOrdType", PJobOrdType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobOrdNum", PJobOrdNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobOrdLine", PJobOrdLine, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobOrdRel", PJobOrdRel, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobRefJob", PJobRefJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobRefSuf", PJobRefSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobRefOper", PJobRefOper, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobRefSeq", PJobRefSeq, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PCoProductMix", PCoProductMix, ParameterDirection.Input);
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
