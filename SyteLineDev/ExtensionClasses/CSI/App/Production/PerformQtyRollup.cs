//PROJECT NAME: CSIProduct
//CLASS NAME: PerformQtyRollup.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IPerformQtyRollup
    {
        int PerformQtyRollupSp(QtyUnitType PNewJobitemQtyReleased,
                               QtyUnitType POldJobitemQtyReleased,
                               ProdMixQuantityType PNewRatio1,
                               ProdMixQuantityType POldRatio1,
                               JobType PJob,
                               SuffixType PSuffix,
                               ItemType PItem,
                               ItemType PJobItem,
                               QtyUnitType PJobitemQtyComplete,
                               QtyUnitType PJobQtyReleased,
                               JobStatusType PJobStat,
                               WhseType PWhse,
                               ref InfobarType Infobar);
    }

    public class PerformQtyRollup : IPerformQtyRollup
    {
        readonly IApplicationDB appDB;

        public PerformQtyRollup(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int PerformQtyRollupSp(QtyUnitType PNewJobitemQtyReleased,
                                      QtyUnitType POldJobitemQtyReleased,
                                      ProdMixQuantityType PNewRatio1,
                                      ProdMixQuantityType POldRatio1,
                                      JobType PJob,
                                      SuffixType PSuffix,
                                      ItemType PItem,
                                      ItemType PJobItem,
                                      QtyUnitType PJobitemQtyComplete,
                                      QtyUnitType PJobQtyReleased,
                                      JobStatusType PJobStat,
                                      WhseType PWhse,
                                      ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "PerformQtyRollupSp";

                appDB.AddCommandParameter(cmd, "PNewJobitemQtyReleased", PNewJobitemQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POldJobitemQtyReleased", POldJobitemQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PNewRatio1", PNewRatio1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "POldRatio1", POldRatio1, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJob", PJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSuffix", PSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PItem", PItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobItem", PJobItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobitemQtyComplete", PJobitemQtyComplete, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobQtyReleased", PJobQtyReleased, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PJobStat", PJobStat, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PWhse", PWhse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
