//PROJECT NAME: Finance
//CLASS NAME: IExtFin_GetSTaxDebitCreditAmountsForInvNum.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.ExtFin
{
	public interface IExtFin_GetSTaxDebitCreditAmountsForInvNum
	{
		ICollectionLoadResponse ExtFin_GetSTaxDebitCreditAmountsForInvNumFn(
			string InvNum,
			int? InvSeq);
	}
}

