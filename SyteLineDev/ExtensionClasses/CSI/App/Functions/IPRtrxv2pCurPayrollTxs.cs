//PROJECT NAME: Data
//CLASS NAME: IPRtrxv2pCurPayrollTxs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPRtrxv2pCurPayrollTxs
	{
		(int? ReturnCode,
			int? rErrorOccurred,
			string Infobar) PRtrxv2pCurPayrollTxsSp(
			Guid? pPrtrxRowPointer,
			int? rErrorOccurred,
			string Infobar,
			string DeptUnit);
	}
}

