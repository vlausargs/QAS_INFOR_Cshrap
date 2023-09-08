//PROJECT NAME: Reporting
//CLASS NAME: Rpt_UnpostedProjectLaborTransaction.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_UnpostedProjectLaborTransaction : IRpt_UnpostedProjectLaborTransaction
	{
        readonly IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_UnpostedProjectLaborTransaction(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_UnpostedProjectLaborTransactionSp(string ProjectStarting = null,
		string ProjectEnding = null,
		int? TaskStarting = null,
		int? TaskEnding = null,
		DateTime? TransactionDateStarting = null,
		DateTime? TransactionDateEnding = null,
		string EmployeeStarting = null,
		string EmployeeEnding = null,
		int? DateStartingOffSET = null,
		int? DateEndingOffSET = null,
		int? PrintCost = 0,
		int? DisplayHeader = null,
		Guid? PSessionID = null,
		string pSite = null)
		{
			ProjNumType _ProjectStarting = ProjectStarting;
			ProjNumType _ProjectEnding = ProjectEnding;
			TaskNumType _TaskStarting = TaskStarting;
			TaskNumType _TaskEnding = TaskEnding;
			DateType _TransactionDateStarting = TransactionDateStarting;
			DateType _TransactionDateEnding = TransactionDateEnding;
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			DateOffsetType _DateStartingOffSET = DateStartingOffSET;
			DateOffsetType _DateEndingOffSET = DateEndingOffSET;
			ListYesNoType _PrintCost = PrintCost;
			ListYesNoType _DisplayHeader = DisplayHeader;
			RowPointerType _PSessionID = PSessionID;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_UnpostedProjectLaborTransactionSp";
				
				appDB.AddCommandParameter(cmd, "ProjectStarting", _ProjectStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProjectEnding", _ProjectEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskStarting", _TaskStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskEnding", _TaskEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDateStarting", _TransactionDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionDateEnding", _TransactionDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateStartingOffSET", _DateStartingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateEndingOffSET", _DateEndingOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintCost", _PrintCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PSessionID", _PSessionID, ParameterDirection.Input);
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
