//PROJECT NAME: Finance
//CLASS NAME: FinStmtPreviewDefaults.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Finance
{
	public class FinStmtPreviewDefaults : IFinStmtPreviewDefaults
	{
		readonly IApplicationDB appDB;
		
		
		public FinStmtPreviewDefaults(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string pSource1,
		string pRange1,
		int? pFiscalYear1,
		int? pCurPeriod1,
		string pSource2,
		string pRange2,
		int? pFiscalYear2,
		int? pCurPeriod2,
		DateTime? pCurPerStart1,
		DateTime? pCurPerEnd1,
		DateTime? pCurPerStart2,
		DateTime? pCurPerEnd2) FinStmtPreviewDefaultsSp(string pSource1,
		string pRange1,
		int? pFiscalYear1,
		int? pCurPeriod1,
		string pSource2,
		string pRange2,
		int? pFiscalYear2,
		int? pCurPeriod2,
		DateTime? pCurPerStart1,
		DateTime? pCurPerEnd1,
		DateTime? pCurPerStart2,
		DateTime? pCurPerEnd2,
		string pReportID)
		{
			GlrpthcSourceType _pSource1 = pSource1;
			GlrpthcRangeType _pRange1 = pRange1;
			FiscalYearType _pFiscalYear1 = pFiscalYear1;
			FinPeriodType _pCurPeriod1 = pCurPeriod1;
			GlrpthcSourceType _pSource2 = pSource2;
			GlrpthcRangeType _pRange2 = pRange2;
			FiscalYearType _pFiscalYear2 = pFiscalYear2;
			FinPeriodType _pCurPeriod2 = pCurPeriod2;
			DateType _pCurPerStart1 = pCurPerStart1;
			DateType _pCurPerEnd1 = pCurPerEnd1;
			DateType _pCurPerStart2 = pCurPerStart2;
			DateType _pCurPerEnd2 = pCurPerEnd2;
			RptIdType _pReportID = pReportID;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "FinStmtPreviewDefaultsSp";
				
				appDB.AddCommandParameter(cmd, "pSource1", _pSource1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRange1", _pRange1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pFiscalYear1", _pFiscalYear1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPeriod1", _pCurPeriod1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pSource2", _pSource2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pRange2", _pRange2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pFiscalYear2", _pFiscalYear2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPeriod2", _pCurPeriod2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPerStart1", _pCurPerStart1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPerEnd1", _pCurPerEnd1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPerStart2", _pCurPerStart2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pCurPerEnd2", _pCurPerEnd2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "pReportID", _pReportID, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				pSource1 = _pSource1;
				pRange1 = _pRange1;
				pFiscalYear1 = _pFiscalYear1;
				pCurPeriod1 = _pCurPeriod1;
				pSource2 = _pSource2;
				pRange2 = _pRange2;
				pFiscalYear2 = _pFiscalYear2;
				pCurPeriod2 = _pCurPeriod2;
				pCurPerStart1 = _pCurPerStart1;
				pCurPerEnd1 = _pCurPerEnd1;
				pCurPerStart2 = _pCurPerStart2;
				pCurPerEnd2 = _pCurPerEnd2;
				
				return (Severity, pSource1, pRange1, pFiscalYear1, pCurPeriod1, pSource2, pRange2, pFiscalYear2, pCurPeriod2, pCurPerStart1, pCurPerEnd1, pCurPerStart2, pCurPerEnd2);
			}
		}
	}
}
