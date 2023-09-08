//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectTransactions.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_ProjectTransactions : IRpt_ProjectTransactions
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ProjectTransactions(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjectTransactionsSp(string StartingProject = null,
		string EndingProject = null,
		string CostClass = null,
		string ProjectStatus = null,
		int? StartingTask = null,
		int? EndingTask = null,
		DateTime? StartingTransDate = null,
		int? StartingTransDateOffset = null,
		DateTime? EndingTransDate = null,
		int? EndingTransDateOffset = null,
		string StartingCostCode = null,
		string EndingCostCode = null,
		int? PrintCost = 0,
		int? DisplayHeader = 1,
		string pSite = null,
		string DocumentNumStarting = null,
		string DocumentNumEnding = null)
		{
			ProjNumType _StartingProject = StartingProject;
			ProjNumType _EndingProject = EndingProject;
			InfobarType _CostClass = CostClass;
			InfobarType _ProjectStatus = ProjectStatus;
			TaskNumType _StartingTask = StartingTask;
			TaskNumType _EndingTask = EndingTask;
			DateType _StartingTransDate = StartingTransDate;
			DateOffsetType _StartingTransDateOffset = StartingTransDateOffset;
			DateType _EndingTransDate = EndingTransDate;
			DateOffsetType _EndingTransDateOffset = EndingTransDateOffset;
			CostCodeType _StartingCostCode = StartingCostCode;
			CostCodeType _EndingCostCode = EndingCostCode;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			DocumentNumType _DocumentNumStarting = DocumentNumStarting;
			DocumentNumType _DocumentNumEnding = DocumentNumEnding;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ProjectTransactionsSp";
				
				appDB.AddCommandParameter(cmd, "StartingProject", _StartingProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingProject", _EndingProject, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostClass", _CostClass, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectStatus", _ProjectStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTask", _StartingTask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTask", _EndingTask, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDate", _StartingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingTransDateOffset", _StartingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDate", _EndingTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingTransDateOffset", _EndingTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StartingCostCode", _StartingCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingCostCode", _EndingCostCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumStarting", _DocumentNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DocumentNumEnding", _DocumentNumEnding, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
