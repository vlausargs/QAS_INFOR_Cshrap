//PROJECT NAME: Finance
//CLASS NAME: FinStmt.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinStmt : IFinStmt
	{
		readonly IApplicationDB appDB;
		
		public FinStmt(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Infobar,
			string InfobarAcct) FinStmtSp(
			string FinStmtRptId = null,
			int? FinStmtAcctDetail = null,
			int? FinStmtUnit1Detail = null,
			int? FinStmtUnit2Detail = null,
			int? FinStmtUnit3Detail = null,
			int? FinStmtUnit4Detail = null,
			string FinStmtReportType = null,
			string FinStmtCurrCode = null,
			DateTime? FinStmtCurrTransDate = null,
			int? CurrTransDateOffset = null,
			string FinStmtSiteGroup = null,
			string FinStmtLineSummaryLevel = null,
			DateTime? FinStmtYrStart = null,
			int? YrStartOffset = null,
			int? FinStmtPeriod = null,
			DateTime? FinStmtPerStart = null,
			int? PerStartOffset = null,
			DateTime? FinStmtPerEnd = null,
			int? PerEndOffset = null,
			string FinStmtSAcctUnit1 = null,
			string FinStmtSAcctUnit2 = null,
			string FinStmtSAcctUnit3 = null,
			string FinStmtSAcctUnit4 = null,
			string FinStmtEAcctUnit1 = null,
			string FinStmtEAcctUnit2 = null,
			string FinStmtEAcctUnit3 = null,
			string FinStmtEAcctUnit4 = null,
			string FinStmtAcctSort = null,
			string Infobar = null,
			string InfobarAcct = null,
			Guid? RptSessionId = null)
		{
			RptIdType _FinStmtRptId = FinStmtRptId;
			ListYesNoType _FinStmtAcctDetail = FinStmtAcctDetail;
			ListYesNoType _FinStmtUnit1Detail = FinStmtUnit1Detail;
			ListYesNoType _FinStmtUnit2Detail = FinStmtUnit2Detail;
			ListYesNoType _FinStmtUnit3Detail = FinStmtUnit3Detail;
			ListYesNoType _FinStmtUnit4Detail = FinStmtUnit4Detail;
			ShortDescType _FinStmtReportType = FinStmtReportType;
			CurrCodeType _FinStmtCurrCode = FinStmtCurrCode;
			DateType _FinStmtCurrTransDate = FinStmtCurrTransDate;
			DateOffsetType _CurrTransDateOffset = CurrTransDateOffset;
			SiteGroupType _FinStmtSiteGroup = FinStmtSiteGroup;
			ShortDescType _FinStmtLineSummaryLevel = FinStmtLineSummaryLevel;
			DateType _FinStmtYrStart = FinStmtYrStart;
			DateOffsetType _YrStartOffset = YrStartOffset;
			FinPeriodType _FinStmtPeriod = FinStmtPeriod;
			DateType _FinStmtPerStart = FinStmtPerStart;
			DateOffsetType _PerStartOffset = PerStartOffset;
			DateType _FinStmtPerEnd = FinStmtPerEnd;
			DateOffsetType _PerEndOffset = PerEndOffset;
			UnitCode1Type _FinStmtSAcctUnit1 = FinStmtSAcctUnit1;
			UnitCode2Type _FinStmtSAcctUnit2 = FinStmtSAcctUnit2;
			UnitCode3Type _FinStmtSAcctUnit3 = FinStmtSAcctUnit3;
			UnitCode4Type _FinStmtSAcctUnit4 = FinStmtSAcctUnit4;
			UnitCode1Type _FinStmtEAcctUnit1 = FinStmtEAcctUnit1;
			UnitCode2Type _FinStmtEAcctUnit2 = FinStmtEAcctUnit2;
			UnitCode3Type _FinStmtEAcctUnit3 = FinStmtEAcctUnit3;
			UnitCode4Type _FinStmtEAcctUnit4 = FinStmtEAcctUnit4;
			ShortDescType _FinStmtAcctSort = FinStmtAcctSort;
			InfobarType _Infobar = Infobar;
			InfobarType _InfobarAcct = InfobarAcct;
			RowPointerType _RptSessionId = RptSessionId;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinStmtSp";
				
				appDB.AddCommandParameter(cmd, "FinStmtRptId", _FinStmtRptId, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtAcctDetail", _FinStmtAcctDetail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtUnit1Detail", _FinStmtUnit1Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtUnit2Detail", _FinStmtUnit2Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtUnit3Detail", _FinStmtUnit3Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtUnit4Detail", _FinStmtUnit4Detail, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtReportType", _FinStmtReportType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtCurrCode", _FinStmtCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtCurrTransDate", _FinStmtCurrTransDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurrTransDateOffset", _CurrTransDateOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtSiteGroup", _FinStmtSiteGroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtLineSummaryLevel", _FinStmtLineSummaryLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtYrStart", _FinStmtYrStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "YrStartOffset", _YrStartOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtPeriod", _FinStmtPeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtPerStart", _FinStmtPerStart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerStartOffset", _PerStartOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtPerEnd", _FinStmtPerEnd, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PerEndOffset", _PerEndOffset, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtSAcctUnit1", _FinStmtSAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtSAcctUnit2", _FinStmtSAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtSAcctUnit3", _FinStmtSAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtSAcctUnit4", _FinStmtSAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtEAcctUnit1", _FinStmtEAcctUnit1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtEAcctUnit2", _FinStmtEAcctUnit2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtEAcctUnit3", _FinStmtEAcctUnit3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtEAcctUnit4", _FinStmtEAcctUnit4, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FinStmtAcctSort", _FinStmtAcctSort, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "InfobarAcct", _InfobarAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RptSessionId", _RptSessionId, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Infobar = _Infobar;
				InfobarAcct = _InfobarAcct;
				
				return (Severity, Infobar, InfobarAcct);
			}
		}
	}
}
