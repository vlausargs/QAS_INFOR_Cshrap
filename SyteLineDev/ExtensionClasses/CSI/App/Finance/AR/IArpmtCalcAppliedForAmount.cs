//PROJECT NAME: Finance
//CLASS NAME: IArpmtCalcAppliedForAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AR
{
	public interface IArpmtCalcAppliedForAmount
	{
		decimal? ArpmtCalcAppliedForAmountFn(
			string PBankCode,
			string PCustNum,
			string PType,
			int? PCheckNum,
			string PCreditMemoNum);
	}
}

