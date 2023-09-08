//PROJECT NAME: Reporting
//CLASS NAME: Rpt_LettersOfCreditByVendor.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_LettersOfCreditByVendor : IRpt_LettersOfCreditByVendor
	{
		IApplicationDB appDB;
		IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_LettersOfCreditByVendor(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_LettersOfCreditByVendorSp(string pLcrStat = "POEC",
		string pCurrCode = null,
		int? pShowDetail = 0,
		string pStartVendor = null,
		string pEndVendor = null,
		string pStartVendLcrNum = null,
		string pEndVendLcrNum = null,
		DateTime? pStartIssueDate = null,
		DateTime? pEndIssueDate = null,
		DateTime? pStartEstCloseDate = null,
		DateTime? pEndEstCloseDate = null,
		int? pStartIssueDateOffset = null,
		int? pEndIssueDateOffset = null,
		int? pStartEstCloseDateOffset = null,
		int? pEndEstCloseDateOffset = null,
		int? PDisplayHeader = 1,
		string pSite = null)
		{
			StringType _pLcrStat = pLcrStat;
			StringType _pCurrCode = pCurrCode;
			ListYesNoType _pShowDetail = pShowDetail;
			HighLowCharType _pStartVendor = pStartVendor;
			HighLowCharType _pEndVendor = pEndVendor;
			HighLowCharType _pStartVendLcrNum = pStartVendLcrNum;
			HighLowCharType _pEndVendLcrNum = pEndVendLcrNum;
			GenericDateType _pStartIssueDate = pStartIssueDate;
			GenericDateType _pEndIssueDate = pEndIssueDate;
			GenericDateType _pStartEstCloseDate = pStartEstCloseDate;
			GenericDateType _pEndEstCloseDate = pEndEstCloseDate;
			DateOffsetType _pStartIssueDateOffset = pStartIssueDateOffset;
			DateOffsetType _pEndIssueDateOffset = pEndIssueDateOffset;
			DateOffsetType _pStartEstCloseDateOffset = pStartEstCloseDateOffset;
			DateOffsetType _pEndEstCloseDateOffset = pEndEstCloseDateOffset;
			ListYesNoType _PDisplayHeader = PDisplayHeader;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_LettersOfCreditByVendorSp";
				
				appDB.AddCommandParameter(cmd, "pLcrStat", _pLcrStat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pCurrCode", _pCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pShowDetail", _pShowDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendor", _pStartVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendor", _pEndVendor, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartVendLcrNum", _pStartVendLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndVendLcrNum", _pEndVendLcrNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartIssueDate", _pStartIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndIssueDate", _pEndIssueDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEstCloseDate", _pStartEstCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEstCloseDate", _pEndEstCloseDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartIssueDateOffset", _pStartIssueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndIssueDateOffset", _pEndIssueDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pStartEstCloseDateOffset", _pStartEstCloseDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pEndEstCloseDateOffset", _pEndEstCloseDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PDisplayHeader", _PDisplayHeader, ParameterDirection.Input);
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
