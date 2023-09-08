//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PayrollDistributionLog.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PayrollDistributionLog : IRpt_PayrollDistributionLog
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
        readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PayrollDistributionLog(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PayrollDistributionLogSp(string EmployeeStarting = null,
		string EmployeeEnding = null,
		int? TransactionStatus = null,
		string EmployeeType = null,
		int? DisplayHeader = null,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null)
		{
			EmpNumType _EmployeeStarting = EmployeeStarting;
			EmpNumType _EmployeeEnding = EmployeeEnding;
			FlagNyType _TransactionStatus = TransactionStatus;
			InfobarType _EmployeeType = EmployeeType;
			ListYesNoType _DisplayHeader = DisplayHeader;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PayrollDistributionLogSp";
				
				appDB.AddCommandParameter(cmd, "EmployeeStarting", _EmployeeStarting, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeEnding", _EmployeeEnding, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TransactionStatus", _TransactionStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmployeeType", _EmployeeType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
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
