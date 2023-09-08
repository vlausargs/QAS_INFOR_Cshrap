//PROJECT NAME: Logistics
//CLASS NAME: IAppmtCalcAppliedDomAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtCalcAppliedDomAmount
	{
		decimal? AppmtCalcAppliedDomAmountFn(
			string PBankCode,
			string PVendNum,
			int? PCheckSeq);
	}
}

