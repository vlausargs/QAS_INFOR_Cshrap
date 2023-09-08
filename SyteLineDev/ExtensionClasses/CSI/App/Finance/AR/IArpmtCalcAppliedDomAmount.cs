//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcAppliedDomAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcAppliedDomAmount
	{
		decimal? ArpmtCalcAppliedDomAmountFn(
			string PBankCode,
			string PCustNum,
			string PType,
			int? PCheckNum,
			string PCreditMemoNum);
	}
}

