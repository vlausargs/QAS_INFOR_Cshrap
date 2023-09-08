//PROJECT NAME: Employee
//CLASS NAME: Rpt_ExEmployeeOutstandingLoans.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class Rpt_ExEmployeeOutstandingLoans : IRpt_ExEmployeeOutstandingLoans
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_ExEmployeeOutstandingLoans(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_ExEmployeeOutstandingLoansSp(string EmployeeStarting = null,
		string EmployeeEnding = null,
		DateTime? HireDateStarting = null,
		DateTime? HireDateEnding = null,
		DateTime? TermDateStarting = null,
		DateTime? TermDateEnding = null,
		int? HireDateStartingOffset = null,
		int? HireDateEndingOffset = null,
		int? TermDateStartingOffset = null,
		int? TermDateEndingOffset = null,
		int? DisplayHeader = null,
		string pSite = null)
		{
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			DateType _HireDateStarting = HireDateStarting;
			DateType _HireDateEnding = HireDateEnding;
			DateType _TermDateStarting = TermDateStarting;
			DateType _TermDateEnding = TermDateEnding;
			DateOffsetType _HireDateStartingOffset = HireDateStartingOffset;
			DateOffsetType _HireDateEndingOffset = HireDateEndingOffset;
			DateOffsetType _TermDateStartingOffset = TermDateStartingOffset;
			DateOffsetType _TermDateEndingOffset = TermDateEndingOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_ExEmployeeOutstandingLoansSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HireDateStarting", _HireDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HireDateEnding", _HireDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermDateStarting", _TermDateStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermDateEnding", _TermDateEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HireDateStartingOffset", _HireDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "HireDateEndingOffset", _HireDateEndingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermDateStartingOffset", _TermDateStartingOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TermDateEndingOffset", _TermDateEndingOffset, ParameterDirection.Input);
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
