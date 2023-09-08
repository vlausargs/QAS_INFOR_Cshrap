//PROJECT NAME: Employee
//CLASS NAME: CLM_PR01VRPVoidChecksRange.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Employee
{
	public class CLM_PR01VRPVoidChecksRange : ICLM_PR01VRPVoidChecksRange
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public CLM_PR01VRPVoidChecksRange(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) CLM_PR01VRPVoidChecksRangeSp(string pBankCode,
		string pStartDept,
		string pEndDept,
		string pStartEmpNum,
		string pEndEmpNum,
		int? pPrintZeroChecks,
		string pEmpType,
		string PStartEmpCate = null,
		string PEndEmpCate = null)
		{
			if(bunchedLoadCollection != null)
			bunchedLoadCollection.StartBunching();
			
			try
			{
				BankCodeType _pBankCode = pBankCode;
				DeptType _pStartDept = pStartDept;
				DeptType _pEndDept = pEndDept;
				EmpNumType _pStartEmpNum = pStartEmpNum;
				EmpNumType _pEndEmpNum = pEndEmpNum;
				FlagNyType _pPrintZeroChecks = pPrintZeroChecks;
				StringType _pEmpType = pEmpType;
				EmpCategoryType _PStartEmpCate = PStartEmpCate;
				EmpCategoryType _PEndEmpCate = PEndEmpCate;
				
				using (IDbCommand cmd = appDB.CreateCommand())
				{
					DataTable dtReturn = new DataTable();
					
					cmd.CommandType = CommandType.StoredProcedure;
					cmd.CommandText = "CLM_PR01VRPVoidChecksRangeSp";
					
					appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pPrintZeroChecks", _pPrintZeroChecks, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PStartEmpCate", _PStartEmpCate, ParameterDirection.Input);
					appDB.AddCommandParameter(cmd, "PEndEmpCate", _PEndEmpCate, ParameterDirection.Input);
					
					IntType returnVal = 0;
					IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
					dbParm.DbType = DbType.Int32;
					
					dtReturn = appDB.ExecuteQuery(cmd);
					
					return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
				}
			}
			finally
			{
				if(bunchedLoadCollection != null)
				bunchedLoadCollection.EndBunching();
			}
		}
	}
}
