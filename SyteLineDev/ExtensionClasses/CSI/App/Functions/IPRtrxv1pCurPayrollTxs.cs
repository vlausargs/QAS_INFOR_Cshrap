//PROJECT NAME: Data
//CLASS NAME: IPRtrxv1pCurPayrollTxs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRtrxv1pCurPayrollTxs
	{
		(int? ReturnCode,
			decimal? rTFreqMult,
			int? rErrorOccurred,
			string Infobar) PRtrxv1pCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			Guid? pFedRowPointer,
			string pBankHdrBankCode,
			decimal? rTFreqMult,
			int? rErrorOccurred,
			string Infobar,
			string DeptUnit);
	}
}

