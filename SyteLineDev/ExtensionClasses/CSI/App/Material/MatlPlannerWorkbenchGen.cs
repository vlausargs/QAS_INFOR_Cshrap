//PROJECT NAME: CSIMaterial
//CLASS NAME: MatlPlannerWorkbenchGen.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
    public interface IMatlPlannerWorkbenchGen
    {
        (ICollectionLoadResponse Data, int? ReturnCode) MatlPlannerWorkbenchGenSp(byte? DelPwbBatch,
                                                                                  byte? UsePln,
                                                                                  DateTime? EndDate,
                                                                                  string Source,
                                                                                  string PlannerCode,
                                                                                  string Buyer,
                                                                                  string Whse,
                                                                                  string Replenishment,
                                                                                  string ThingsToProcess,
                                                                                  string StartingItem,
                                                                                  string EndingItem,
                                                                                  string StartingOrder,
                                                                                  string EndingOrder,
                                                                                  string StartingProject,
                                                                                  string EndingProject,
                                                                                  string StartingTransfer,
                                                                                  string EndingTransfer,
                                                                                  string StartingJob,
                                                                                  string EndingJob,
                                                                                  short? StartingJobSuf,
                                                                                  short? EndingJobSuf,
                                                                                  decimal? UserId);
    }

    public class MatlPlannerWorkbenchGen : IMatlPlannerWorkbenchGen
    {
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;

        public MatlPlannerWorkbenchGen(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
        {
            this.appDB = appDB;
            this.bunchedLoadCollection = bunchedLoadCollection;
            this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
        }

        public (ICollectionLoadResponse Data, int? ReturnCode) MatlPlannerWorkbenchGenSp(byte? DelPwbBatch,
                                                                                         byte? UsePln,
                                                                                         DateTime? EndDate,
                                                                                         string Source,
                                                                                         string PlannerCode,
                                                                                         string Buyer,
                                                                                         string Whse,
                                                                                         string Replenishment,
                                                                                         string ThingsToProcess,
                                                                                         string StartingItem,
                                                                                         string EndingItem,
                                                                                         string StartingOrder,
                                                                                         string EndingOrder,
                                                                                         string StartingProject,
                                                                                         string EndingProject,
                                                                                         string StartingTransfer,
                                                                                         string EndingTransfer,
                                                                                         string StartingJob,
                                                                                         string EndingJob,
                                                                                         short? StartingJobSuf,
                                                                                         short? EndingJobSuf,
                                                                                         decimal? UserId)
        {
            ListYesNoType _DelPwbBatch = DelPwbBatch;
            ListYesNoType _UsePln = UsePln;
            DateType _EndDate = EndDate;
            StringType _Source = Source;
            UserCodeType _PlannerCode = PlannerCode;
            UsernameType _Buyer = Buyer;
            WhseType _Whse = Whse;
            StringType _Replenishment = Replenishment;
            StringType _ThingsToProcess = ThingsToProcess;
            ItemType _StartingItem = StartingItem;
            ItemType _EndingItem = EndingItem;
            CoNumType _StartingOrder = StartingOrder;
            CoNumType _EndingOrder = EndingOrder;
            ProjNumType _StartingProject = StartingProject;
            ProjNumType _EndingProject = EndingProject;
            TrnNumType _StartingTransfer = StartingTransfer;
            TrnNumType _EndingTransfer = EndingTransfer;
            JobType _StartingJob = StartingJob;
            JobType _EndingJob = EndingJob;
            SuffixType _StartingJobSuf = StartingJobSuf;
            SuffixType _EndingJobSuf = EndingJobSuf;
            TokenType _UserId = UserId;

            using (IDbCommand cmd = appDB.CreateCommand())
            {
                DataTable dtReturn = new DataTable();

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "MatlPlannerWorkbenchGenSp";

                appDB.AddCommandParameter(cmd, "DelPwbBatch", _DelPwbBatch, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UsePln", _UsePln, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndDate", _EndDate, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Source", _Source, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "PlannerCode", _PlannerCode, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "Replenishment", _Replenishment, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "ThingsToProcess", _ThingsToProcess, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingItem", _StartingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingItem", _EndingItem, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingOrder", _StartingOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingOrder", _EndingOrder, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingProject", _StartingProject, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingProject", _EndingProject, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingTransfer", _StartingTransfer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingTransfer", _EndingTransfer, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingJob", _StartingJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingJob", _EndingJob, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "StartingJobSuf", _StartingJobSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "EndingJobSuf", _EndingJobSuf, ParameterDirection.Input);
                appDB.AddCommandParameter(cmd, "UserId", _UserId, ParameterDirection.Input);

                IntType returnVal = 0;
                IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
                dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
            }
        }
    }
}
