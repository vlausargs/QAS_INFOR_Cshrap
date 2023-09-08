//PROJECT NAME: Employee
//CLASS NAME: Rpt_NumberofEmployeesbyDept.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class Rpt_NumberofEmployeesbyDept : IRpt_NumberofEmployeesbyDept
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_NumberofEmployeesbyDept(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_NumberofEmployeesbyDeptSp(string StartingDept = null,
		string EndingDept = null,
		string EmpStatus = null,
		int? DisplayHeader = null,
		Guid? BGSessionID = null,
		string pSite = null,
		string BGUser = null)
		{
			DeptType _StartingDept = StartingDept;
			DeptType _EndingDept = EndingDept;
			EmpStatusType _EmpStatus = EmpStatus;
			ListYesNoType _DisplayHeader = DisplayHeader;
			RowPointerType _BGSessionID = BGSessionID;
			SiteType _pSite = pSite;
			UsernameType _BGUser = BGUser;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_NumberofEmployeesbyDeptSp";
				
				appDB.AddCommandParameter(cmd, "StartingDept", _StartingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EndingDept", _EndingDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EmpStatus", _EmpStatus, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionID", _BGSessionID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGUser", _BGUser, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;
				
				dtReturn = appDB.ExecuteQuery(cmd);
				
				return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
