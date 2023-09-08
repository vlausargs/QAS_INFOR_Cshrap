//PROJECT NAME: Logistics
//CLASS NAME: IAppmtCalcAppliedForAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtCalcAppliedForAmount
	{
		decimal? AppmtCalcAppliedForAmountFn(
			string PBankCode,
			string PVendNum,
			int? PCheckSeq);
	}
}

