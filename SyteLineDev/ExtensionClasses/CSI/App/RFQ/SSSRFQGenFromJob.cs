//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQGenFromJob.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.MG;

namespace CSI.RFQ
{
    public interface ISSSRFQGenFromJob
    {
        DataTable SSSRFQGenFromJobSp(byte? Commit,
                                     string JobType,
                                     string StartJob,
                                     string EndJob,
                                     short? StartSuffix,
                                     short? EndSuffix,
                                     string StartProductCode,
                                     string EndProductCode,
                                     string StartItem,
                                     string EndItem,
                                     string GenMethod,
                                     string RollupMethod,
                                     byte? PurchasePartsOnly,
                                     byte? RollUpItems,
                                     string QtysToPrice,
                                     string AppendRfqNum,
                                     string PSessionId);
    }

    public class SSSRFQGenFromJob : ISSSRFQGenFromJob
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;

        public SSSRFQGenFromJob(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
        }

        public DataTable SSSRFQGenFromJobSp(byte? Commit,
                                            string JobType,
                                            string StartJob,
                                            string EndJob,
                                            short? StartSuffix,
                                            short? EndSuffix,
                                            string StartProductCode,
                                            string EndProductCode,
                                            string StartItem,
                                            string EndItem,
                                            string GenMethod,
                                            string RollupMethod,
                                            byte? PurchasePartsOnly,
                                            byte? RollUpItems,
                                            string QtysToPrice,
                                            string AppendRfqNum,
                                            string PSessionId)
        {
            ListYesNoType _Commit = Commit;
            JobTypeType _JobType = JobType;
            JobType _StartJob = StartJob;
            JobType _EndJob = EndJob;
            SuffixType _StartSuffix = StartSuffix;
            SuffixType _EndSuffix = EndSuffix;
            ProductCodeType _StartProductCode = StartProductCode;
            ProductCodeType _EndProductCode = EndProductCode;
            ItemType _StartItem = StartItem;
            ItemType _EndItem = EndItem;
            StringType _GenMethod = GenMethod;
            StringType _RollupMethod = RollupMethod;
            ListYesNoType _PurchasePartsOnly = PurchasePartsOnly;
            ListYesNoType _RollUpItems = RollUpItems;
            LongListType _QtysToPrice = QtysToPrice;
            RFQNumType _AppendRfqNum = AppendRfqNum;
            StringType _PSessionId = PSessionId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SSSRFQGenFromJobSp";

                appDB.AddCommandParameter(cmd, "Commit", _Commit, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartJob", _StartJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndJob", _EndJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartSuffix", _StartSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndSuffix", _EndSuffix, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartProductCode", _StartProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndProductCode", _EndProductCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartItem", _StartItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndItem", _EndItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "GenMethod", _GenMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RollupMethod", _RollupMethod, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PurchasePartsOnly", _PurchasePartsOnly, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "RollUpItems", _RollUpItems, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "QtysToPrice", _QtysToPrice, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "AppendRfqNum", _AppendRfqNum, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PSessionId", _PSessionId, ParameterDirection.Input);

                dtReturn = appDB.ExecuteQuery(cmd);

                return dtReturn;
            }
        }
    }
}
