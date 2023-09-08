//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CurrencyRevaluation.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public interface IRpt_CurrencyRevaluation
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CurrencyRevaluationSp(byte? pRelGl = null,
		byte? pPostTrx = null,
		string pSCurrCode = null,
		string pECurrCode = null,
		byte? pRcvAcctType = null,
		byte? pPayAcctType = null,
		byte? pVouchPayAcctType = null,
		DateTime? pTTransDate = null,
		string pInvAdjAcct = null,
		string pInvAdjAcctUnit1 = null,
		string pInvAdjAcctUnit2 = null,
		string pInvAdjAcctUnit3 = null,
		string pInvAdjAcctUnit4 = null,
		short? DateOffset = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null,
		int? ReportType = 0);
	}
	
	public class Rpt_CurrencyRevaluation : IRpt_CurrencyRevaluation
	{
		IApplicationDB appDB;
        readonly IBunchedLoadCollection bunchedLoadCollection;
		IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_CurrencyRevaluation(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_CurrencyRevaluationSp(byte? pRelGl = null,
		byte? pPostTrx = null,
		string pSCurrCode = null,
		string pECurrCode = null,
		byte? pRcvAcctType = null,
		byte? pPayAcctType = null,
		byte? pVouchPayAcctType = null,
		DateTime? pTTransDate = null,
		string pInvAdjAcct = null,
		string pInvAdjAcctUnit1 = null,
		string pInvAdjAcctUnit2 = null,
		string pInvAdjAcctUnit3 = null,
		string pInvAdjAcctUnit4 = null,
		short? DateOffset = null,
		byte? DisplayHeader = null,
		int? TaskId = null,
		string pSite = null,
		int? ReportType = 0)
		{
			ListYesNoType _pRelGl = pRelGl;
			ListYesNoType _pPostTrx = pPostTrx;
			CurrCodeType _pSCurrCode = pSCurrCode;
			CurrCodeType _pECurrCode = pECurrCode;
			ListYesNoType _pRcvAcctType = pRcvAcctType;
			ListYesNoType _pPayAcctType = pPayAcctType;
			ListYesNoType _pVouchPayAcctType = pVouchPayAcctType;
			DateType _pTTransDate = pTTransDate;
			AcctType _pInvAdjAcct = pInvAdjAcct;
			UnitCode1Type _pInvAdjAcctUnit1 = pInvAdjAcctUnit1;
			UnitCode2Type _pInvAdjAcctUnit2 = pInvAdjAcctUnit2;
			UnitCode3Type _pInvAdjAcctUnit3 = pInvAdjAcctUnit3;
			UnitCode4Type _pInvAdjAcctUnit4 = pInvAdjAcctUnit4;
			DateOffsetType _DateOffset = DateOffset;
			ListYesNoType _DisplayHeader = DisplayHeader;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			GenericTypeType _ReportType = ReportType;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_CurrencyRevaluationSp";
				
				appDB.AddCommandParameter(cmd, "pRelGl", _pRelGl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPostTrx", _pPostTrx, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSCurrCode", _pSCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pECurrCode", _pECurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pRcvAcctType", _pRcvAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pPayAcctType", _pPayAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pVouchPayAcctType", _pVouchPayAcctType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pTTransDate", _pTTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcct", _pInvAdjAcct, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit1", _pInvAdjAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit2", _pInvAdjAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit3", _pInvAdjAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pInvAdjAcctUnit4", _pInvAdjAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DateOffset", _DateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DisplayHeader", _DisplayHeader, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaskId", _TaskId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "pSite", _pSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
				
				IntType returnVal = 0;
				IDbDataParameter dbParm = appDB.AddCommandParameter(cmd, "ReturnVal", returnVal, ParameterDirection.ReturnValue);
				dbParm.DbType = DbType.Int32;

                dtReturn = appDB.ExecuteQuery(cmd);

                return (dataTableToCollectionLoadResponse.Process(dtReturn), (int)((IDbDataParameter)cmd.Parameters["@ReturnVal"]).Value);
			}
		}
	}
}
