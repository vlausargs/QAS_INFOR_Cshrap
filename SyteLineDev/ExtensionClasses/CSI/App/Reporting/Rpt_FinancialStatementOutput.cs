//PROJECT NAME: Reporting
//CLASS NAME: Rpt_FinancialStatementOutput.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Reporting
{
	public class Rpt_FinancialStatementOutput : IRpt_FinancialStatementOutput
	{
		readonly IApplicationDB appDB;
		readonly IBunchedLoadCollection bunchedLoadCollection;
		readonly IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse;
		
		public Rpt_FinancialStatementOutput(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection, IDataTableToCollectionLoadResponse dataTableToCollectionLoadResponse)
		{
			this.appDB = appDB;
			this.bunchedLoadCollection = bunchedLoadCollection;
			this.dataTableToCollectionLoadResponse = dataTableToCollectionLoadResponse;
		}
		
		public (ICollectionLoadResponse Data, int? ReturnCode) Rpt_FinancialStatementOutputSp(
			string ReportID = null,
			int? AcctDetail = null,
			int? Unit1Detail = null,
			int? Unit2Detail = null,
			int? Unit3Detail = null,
			int? Unit4Detail = null,
			string ReportType = null,
			string CurrCode = null,
			DateTime? CurrTransDate = null,
			int? CurrTransDateOffset = null,
			string SiteGroup = null,
			string LineSummaryLevel = null,
			DateTime? YrStart = null,
			int? YrStartOffset = null,
			int? Period = null,
			DateTime? PerStart = null,
			int? PerStartOffset = null,
			DateTime? PerEnd = null,
			int? PerEndOffset = null,
			string SAcctUnit1 = null,
			string SAcctUnit2 = null,
			string SAcctUnit3 = null,
			string SAcctUnit4 = null,
			string EAcctUnit1 = null,
			string EAcctUnit2 = null,
			string EAcctUnit3 = null,
			string EAcctUnit4 = null,
			string AcctSortRaw = null,
			string BGSessionId = null,
			int? TaskId = null,
			string pSite = null)
		{
			RptIdType _ReportID = ReportID;
			ListYesNoType _AcctDetail = AcctDetail;
			ListYesNoType _Unit1Detail = Unit1Detail;
			ListYesNoType _Unit2Detail = Unit2Detail;
			ListYesNoType _Unit3Detail = Unit3Detail;
			ListYesNoType _Unit4Detail = Unit4Detail;
			ShortDescType _ReportType = ReportType;
			CurrCodeType _CurrCode = CurrCode;
			DateType _CurrTransDate = CurrTransDate;
			DateOffsetType _CurrTransDateOffset = CurrTransDateOffset;
			SiteGroupType _SiteGroup = SiteGroup;
			ShortDescType _LineSummaryLevel = LineSummaryLevel;
			DateType _YrStart = YrStart;
			DateOffsetType _YrStartOffset = YrStartOffset;
			FinPeriodType _Period = Period;
			DateType _PerStart = PerStart;
			DateOffsetType _PerStartOffset = PerStartOffset;
			DateType _PerEnd = PerEnd;
			DateOffsetType _PerEndOffset = PerEndOffset;
			UnitCode1Type _SAcctUnit1 = SAcctUnit1;
			UnitCode2Type _SAcctUnit2 = SAcctUnit2;
			UnitCode3Type _SAcctUnit3 = SAcctUnit3;
			UnitCode4Type _SAcctUnit4 = SAcctUnit4;
			UnitCode1Type _EAcctUnit1 = EAcctUnit1;
			UnitCode2Type _EAcctUnit2 = EAcctUnit2;
			UnitCode3Type _EAcctUnit3 = EAcctUnit3;
			UnitCode4Type _EAcctUnit4 = EAcctUnit4;
			ShortDescType _AcctSortRaw = AcctSortRaw;
			StringType _BGSessionId = BGSessionId;
			TaskNumType _TaskId = TaskId;
			SiteType _pSite = pSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				DataTable dtReturn = new DataTable();
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "Rpt_FinancialStatementOutputSp";
				
				appDB.AddCommandParameter(cmd, "ReportID", _ReportID, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctDetail", _AcctDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit1Detail", _Unit1Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit2Detail", _Unit2Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit3Detail", _Unit3Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Unit4Detail", _Unit4Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReportType", _ReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrCode", _CurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrTransDate", _CurrTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrTransDateOffset", _CurrTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SiteGroup", _SiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LineSummaryLevel", _LineSummaryLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YrStart", _YrStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YrStartOffset", _YrStartOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Period", _Period, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStart", _PerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStartOffset", _PerStartOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEnd", _PerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEndOffset", _PerEndOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit1", _SAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit2", _SAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit3", _SAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SAcctUnit4", _SAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit1", _EAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit2", _EAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit3", _EAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EAcctUnit4", _EAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcctSortRaw", _AcctSortRaw, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BGSessionId", _BGSessionId, ParameterDirection.Input);
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
