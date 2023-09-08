//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobsAffectedByEngineeringChangeNotices.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_JobsAffectedByEngineeringChangeNotices : IRpt_JobsAffectedByEngineeringChangeNotices
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_JobsAffectedByEngineeringChangeNotices(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobsAffectedByEngineeringChangeNoticesSp(int? ECNStarting = null,
		int? ECNEnding = null,
		string ECNStatus = null,
		string JobType = null,
		int? ECNPrintWHEREUsed = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null)
		{
			EcnNumType _ECNStarting = ECNStarting;
			EcnNumType _ECNEnding = ECNEnding;
			StringType _ECNStatus = ECNStatus;
			StringType _JobType = JobType;
			ListYesNoType _ECNPrintWHEREUsed = ECNPrintWHEREUsed;
			ListYesNoType _DisplayHeader = DisplayHeader;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_JobsAffectedByEngineeringChangeNoticesSp";
				
				appDB.AddCommandParameter(cmd, "ECNStarting", _ECNStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNEnding", _ECNEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNStatus", _ECNStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobType", _JobType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECNPrintWHEREUsed", _ECNPrintWHEREUsed, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
