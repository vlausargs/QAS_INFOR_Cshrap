//PROJECT NAME: Logistics
//CLASS NAME: IAppmtCalcCheckAmount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtCalcCheckAmount
	{
		(int? ReturnCode, decimal? POutCheckAmt,
		string Infobar) AppmtCalcCheckAmountSp(decimal? PExchRate,
		decimal? PInCheckAmt,
		string PVendCurr,
		DateTime? PCheckDate,
		int? PToVendor,
		decimal? POutCheckAmt,
		string Infobar);
	}
}

