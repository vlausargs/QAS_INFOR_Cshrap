//PROJECT NAME: Reporting
//CLASS NAME: IRPT_PR02HriEmpCurPayrollTxs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_PR02HriEmpCurPayrollTxs
	{
		(int? ReturnCode,
			string Infobar) RPT_PR02HriEmpCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			int? pIdx,
			string pListTDe,
			string pListTAmt,
			int? pTCanCost,
			string Infobar);
	}
}

