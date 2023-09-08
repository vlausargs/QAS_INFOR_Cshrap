//PROJECT NAME: POS
//CLASS NAME: ISSSPOSCreatePayh.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.POS
{
	public interface ISSSPOSCreatePayh
	{
		(int? ReturnCode,
			string BankCode,
			string Infobar) SSSPOSCreatePayhSp(
			string POSMCustNum,
			string CustomerBankCode,
			string PmtType,
			int? CheckNum,
			decimal? AmtToApply,
			Guid? PosmPaymentRowPointer,
			Guid? SessionID,
			string BankCode,
			string Infobar);
	}
}

