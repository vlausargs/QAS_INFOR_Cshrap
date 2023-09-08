//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PrintW2Forms.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PrintW2Forms : IRpt_PrintW2Forms
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PrintW2Forms(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PrintW2FormsSp(DateTime? YearStartDate,
		DateTime? YearEndDate,
		int? W3Information = 0,
		int? ConsolidateState = 0,
		string EmpNumStarting = null,
		string EmpNumEnding = null,
		int? EmpTypeHourlyPerm = null,
		int? EmpTypeSalaryPerm = null,
		string pSite = null)
		{
			DateType _YearStartDate = YearStartDate;
			DateType _YearEndDate = YearEndDate;
			ListYesNoType _W3Information = W3Information;
			ListYesNoType _ConsolidateState = ConsolidateState;
			EmpNumType _EmpNumStarting = EmpNumStarting;
			EmpNumType _EmpNumEnding = EmpNumEnding;
			PrivilegeType _EmpTypeHourlyPerm = EmpTypeHourlyPerm;
			PrivilegeType _EmpTypeSalaryPerm = EmpTypeSalaryPerm;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PrintW2FormsSp";
				
				appDB.AddCommandParameter(cmd, "YearStartDate", _YearStartDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YearEndDate", _YearEndDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "W3Information", _W3Information, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ConsolidateState", _ConsolidateState, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNumStarting", _EmpNumStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpNumEnding", _EmpNumEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpTypeHourlyPerm", _EmpTypeHourlyPerm, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpTypeSalaryPerm", _EmpTypeSalaryPerm, ParameterDirection.Input);
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
