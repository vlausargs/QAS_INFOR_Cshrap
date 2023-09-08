//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LettersofCreditbyCustomer.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LettersofCreditbyCustomer : IRpt_LettersofCreditbyCustomer
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LettersofCreditbyCustomer(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LettersofCreditbyCustomerSp(string SCustNum = null,
		string ECustNum = null,
		string LcrStat = null,
		string CurrCode = null,
		int? ShowDetail = null,
		string SLcrNum = null,
		string ELcrNum = null,
		DateTime? StIssueDate = null,
		DateTime? EIssueDate = null,
		DateTime? SCloseDate = null,
		DateTime? ECloseDate = null,
		int? SIssueDateOffSET = null,
		int? EIssueDateOffSET = null,
		int? SCloseDateOffSET = null,
		int? ECloseDateOffSET = null,
		int? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null)
		{
			CustNumType _SCustNum = SCustNum;
			CustNumType _ECustNum = ECustNum;
			StringType _LcrStat = LcrStat;
			CurrCodeType _CurrCode = CurrCode;
			FlagNyType _ShowDetail = ShowDetail;
			LcrNumType _SLcrNum = SLcrNum;
			LcrNumType _ELcrNum = ELcrNum;
			DateType _StIssueDate = StIssueDate;
			DateType _EIssueDate = EIssueDate;
			DateType _SCloseDate = SCloseDate;
			DateType _ECloseDate = ECloseDate;
			DateOffsetType _SIssueDateOffSET = SIssueDateOffSET;
			DateOffsetType _EIssueDateOffSET = EIssueDateOffSET;
			DateOffsetType _SCloseDateOffSET = SCloseDateOffSET;
			DateOffsetType _ECloseDateOffSET = ECloseDateOffSET;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LettersofCreditbyCustomerSp";
				
				appDB.AddCommandParameter(cmd, "SCustNum", _SCustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECustNum", _ECustNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LcrStat", _LcrStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowDetail", _ShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SLcrNum", _SLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ELcrNum", _ELcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StIssueDate", _StIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EIssueDate", _EIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCloseDate", _SCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECloseDate", _ECloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SIssueDateOffSET", _SIssueDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EIssueDateOffSET", _EIssueDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SCloseDateOffSET", _SCloseDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ECloseDateOffSET", _ECloseDateOffSET, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
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
