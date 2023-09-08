//PROJECT NAME: CSIProduct
//CLASS NAME: GetItemByJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.Production
{
    public interface IGetItemByJob
    {
        int GetItemByJobSp(JobType pJob,
                           SuffixType pSuffix,
                           ref ItemType pItem,
                           ref DescriptionType pDescription,
                           ref ListYesNoType pSerialTracked,
                           ref ListYesNoType pLotTracked,
                           ref LotPrefixType pLotPrefix,
                           ref InfobarType Infobar,
                           ref SerialPrefixType pSerialPrefix,
                           ref ListYesNoType pCostCode,
                           ref ListYesNoType pPeassignSerials,
                           ref ListYesNoType pPreassignLots,
                           ref ListYesNoType pParentJobPeassignSerials,
                           ref ListYesNoType pParentJobPreassignLots);
    }

    public class GetItemByJob : IGetItemByJob
    {
        readonly IApplicationDB appDB;

        public GetItemByJob(IApplicationDB appDB)
        {
            this.appDB = appDB;
        }

        public int GetItemByJobSp(JobType pJob,
                                  SuffixType pSuffix,
                                  ref ItemType pItem,
                                  ref DescriptionType pDescription,
                                  ref ListYesNoType pSerialTracked,
                                  ref ListYesNoType pLotTracked,
                                  ref LotPrefixType pLotPrefix,
                                  ref InfobarType Infobar,
                                  ref SerialPrefixType pSerialPrefix,
                                  ref ListYesNoType pCostCode,
                                  ref ListYesNoType pPeassignSerials,
                                  ref ListYesNoType pPreassignLots,
                                  ref ListYesNoType pParentJobPeassignSerials,
                                  ref ListYesNoType pParentJobPreassignLots)
        {
            using (IDbCommand cmd = appDB.CreateCommand())
            {

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "GetItemByJobSp";

                appDB.AddCommandParameter(cmd, "pJob", pJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pSuffix", pSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "pItem", pItem, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pDescription", pDescription, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pSerialTracked", pSerialTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pLotTracked", pLotTracked, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pLotPrefix", pLotPrefix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "Infobar", Infobar, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pSerialPrefix", pSerialPrefix, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pCostCode", pCostCode, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pPeassignSerials", pPeassignSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pPreassignLots", pPreassignLots, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pParentJobPeassignSerials", pParentJobPeassignSerials, ParameterDirection.InputOutput);
                appDB.AddCommandParameter(cmd, "pParentJobPreassignLots", pParentJobPreassignLots, ParameterDirection.InputOutput);

                var Severity = appDB.ExecuteNonQuery(cmd);

                return Severity;
            }
        }
    }
}
