//PROJECT NAME: Finance
//CLASS NAME: ISSSCCIReturnFromCredit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.CreditCard
{
	public interface ISSSCCIReturnFromCredit
	{
		(int? ReturnCode,
			string Infobar) SSSCCIReturnFromCreditSp(
			Guid? RowPointer,
			string Infobar);
	}
}

