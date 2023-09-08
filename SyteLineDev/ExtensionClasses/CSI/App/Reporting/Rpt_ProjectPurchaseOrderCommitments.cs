//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectPurchaseOrderCommitments.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectPurchaseOrderCommitments : IRpt_ProjectPurchaseOrderCommitments
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectPurchaseOrderCommitments(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectPurchaseOrderCommitmentsSp(string ProjNumStarting = null,
		string ProjNumEnding = null,
		int? TaskNumStarting = null,
		int? TaskNumEnding = null,
		string ProjectStatus = null,
		string POLineResStatus = null,
		string JobStarting = null,
		string JobEnding = null,
		int? JobStartSuffix = null,
		int? JobEndSuffix = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		string pSite = null)
		{
			ProjNumType _ProjNumStarting = ProjNumStarting;
			ProjNumType _ProjNumEnding = ProjNumEnding;
			TaskNumType _TaskNumStarting = TaskNumStarting;
			TaskNumType _TaskNumEnding = TaskNumEnding;
			InfobarType _ProjectStatus = ProjectStatus;
			InfobarType _POLineResStatus = POLineResStatus;
			JobPoReqNumType _JobStarting = JobStarting;
			JobPoReqNumType _JobEnding = JobEnding;
			SuffixType _JobStartSuffix = JobStartSuffix;
			SuffixType _JobEndSuffix = JobEndSuffix;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectPurchaseOrderCommitmentsSp";
				
				appDB.AddCommandParameter(cmd, "ProjNumStarting", _ProjNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjNumEnding", _ProjNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNumStarting", _TaskNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskNumEnding", _TaskNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStatus", _ProjectStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "POLineResStatus", _POLineResStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStarting", _JobStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEnding", _JobEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobStartSuffix", _JobStartSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobEndSuffix", _JobEndSuffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
