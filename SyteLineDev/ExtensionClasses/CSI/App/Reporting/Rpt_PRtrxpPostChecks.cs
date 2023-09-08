//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PRtrxpPostChecks.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_PRtrxpPostChecks : IRpt_PRtrxpPostChecks
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_PRtrxpPostChecks(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_PRtrxpPostChecksSp(string pSessionIDChar = null,
		string pStartDept = null,
		string pEndDept = null,
		string pStartEmpNum = null,
		string pEndEmpNum = null,
		string pBankCode = null,
		string pEmpType = null,
		int? pPrintHeader = null,
		string BGSessionId = null,
		DateTime? pCheckDate = null,
		int? pCheckNum = null,
		int? pPrintZeroChecks = 0,
		string PStartEmpCate = null,
		string PEndEmpCate = null,
		string pSite = null)
		{
			StringType _pSessionIDChar = pSessionIDChar;
			DeptType _pStartDept = pStartDept;
			DeptType _pEndDept = pEndDept;
			EmpNumType _pStartEmpNum = pStartEmpNum;
			EmpNumType _pEndEmpNum = pEndEmpNum;
			BankCodeType _pBankCode = pBankCode;
			StringType _pEmpType = pEmpType;
			ListYesNoType _pPrintHeader = pPrintHeader;
			StringType _BGSessionId = BGSessionId;
			DateType _pCheckDate = pCheckDate;
			PrCheckNumType _pCheckNum = pCheckNum;
			ListYesNoType _pPrintZeroChecks = pPrintZeroChecks;
			EmpCategoryType _PStartEmpCate = PStartEmpCate;
			EmpCategoryType _PEndEmpCate = PEndEmpCate;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_PRtrxpPostChecksSp";
				
				appDB.AddCommandParameter(cmd, "pSessionIDChar", _pSessionIDChar, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartDept", _pStartDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndDept", _pEndDept, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEmpNum", _pStartEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEmpNum", _pEndEmpNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pBankCode", _pBankCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEmpType", _pEmpType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintHeader", _pPrintHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckDate", _pCheckDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCheckNum", _pCheckNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPrintZeroChecks", _pPrintZeroChecks, ParameterDirection.Input);
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
