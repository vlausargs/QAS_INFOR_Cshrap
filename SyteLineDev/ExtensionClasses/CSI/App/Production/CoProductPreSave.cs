//PROJECT NAME: CSIProduct
//CLASS NAME: CoProductPreSave.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface ICoProductPreSave
    {
        int CoProductPreSaveSp(JobType Job,
                               SuffixType Suffix,
                               ItemType JobItem,
                               ItemType JobitemItem,
                               JobStatusType JobStat,
                               QtyUnitType JobQtyReleased,
                               QtyUnitType NewJobitemQtyReleased,
                               QtyUnitType OldJobitemQtyReleased,
                               ProdMixQuantityType NewRatio1,
                               ProdMixQuantityType OldRatio1,
                               QtyUnitType JobitemQtyComplete,
                               ref RefTypeIKOTType OrderType,
                               ref CoProjTrnNumType OrderNum,
                               ref CoProjTaskTrnLineType OrderLine,
                               ref CoReleaseType OrderRelease,
                               ref InfobarType PromptMsg,
                               ref InfobarType PromptButtons,
                               ref InfobarType Infobar);
    }

    public class CoProductPreSave : ICoProductPreSave
    {
        readonly IApplicationDB appDB;

        public CoProductPreSave(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int CoProductPreSaveSp(JobType Job,
                                      SuffixType Suffix,
                                      ItemType JobItem,
                                      ItemType JobitemItem,
                                      JobStatusType JobStat,
                                      QtyUnitType JobQtyReleased,
                                      QtyUnitType NewJobitemQtyReleased,
                                      QtyUnitType OldJobitemQtyReleased,
                                      ProdMixQuantityType NewRatio1,
                                      ProdMixQuantityType OldRatio1,
                                      QtyUnitType JobitemQtyComplete,
                                      ref RefTypeIKOTType OrderType,
                                      ref CoProjTrnNumType OrderNum,
                                      ref CoProjTaskTrnLineType OrderLine,
                                      ref CoReleaseType OrderRelease,
                                      ref InfobarType PromptMsg,
                                      ref InfobarType PromptButtons,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "CoProductPreSaveSp";

                appDB.AddCommandParameter(cmd, "Job", Job, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Suffix", Suffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobItem", JobItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobitemItem", JobitemItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobStat", JobStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobQtyReleased", JobQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewJobitemQtyReleased", NewJobitemQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldJobitemQtyReleased", OldJobitemQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "NewRatio1", NewRatio1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OldRatio1", OldRatio1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobitemQtyComplete", JobitemQtyComplete, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "OrderType", OrderType, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrderNum", OrderNum, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrderLine", OrderLine, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "OrderRelease", OrderRelease, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptMsg", PromptMsg, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "PromptButtons", PromptButtons, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
