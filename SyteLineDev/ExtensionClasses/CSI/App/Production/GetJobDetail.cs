//PROJECT NAME: CSIProduct
//CLASS NAME: GetJobDetail.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGetJobDetail
    {
        int GetJobDetailSp(JobType InJob,
                           SuffixType InSuffix,
                           ref ListYesNoType JobCoProdMix,
                           ref InfobarType JobFormattedJob,
                           ref ItemType JobItem,
                           ref DescriptionType JobItemDesc,
                           ref WhseType JobWhse,
                           ref ListYesNoType JobPreassignLots,
                           ref ListYesNoType JobPreassignSerials,
                           ref InfobarType Infobar);
    }

    public class GetJobDetail : IGetJobDetail
    {
        readonly IApplicationDB appDB;

        public GetJobDetail(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetJobDetailSp(JobType InJob,
                                  SuffixType InSuffix,
                                  ref ListYesNoType JobCoProdMix,
                                  ref InfobarType JobFormattedJob,
                                  ref ItemType JobItem,
                                  ref DescriptionType JobItemDesc,
                                  ref WhseType JobWhse,
                                  ref ListYesNoType JobPreassignLots,
                                  ref ListYesNoType JobPreassignSerials,
                                  ref InfobarType Infobar)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetJobDetailSp";

                appDB.AddCommandParameter(cmd, "InJob", InJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "InSuffix", InSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobCoProdMix", JobCoProdMix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobFormattedJob", JobFormattedJob, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobItem", JobItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobItemDesc", JobItemDesc, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobWhse", JobWhse, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobPreassignLots", JobPreassignLots, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "JobPreassignSerials", JobPreassignSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
