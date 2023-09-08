//PROJECT NAME: Finance
//CLASS NAME: IFinStmtPreviewDefaults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinStmtPreviewDefaults
	{
		(int? ReturnCode, string pSource1,
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
		string pReportID);
	}
}

