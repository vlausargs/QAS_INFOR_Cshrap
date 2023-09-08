//PROJECT NAME: Logistics
//CLASS NAME: IAppmtCalcCheckAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtCalcCheckAmt
	{
		(int? ReturnCode, decimal? PExchRate,
		decimal? POutCheckAmt,
		string Infobar) AppmtCalcCheckAmtSp(decimal? PExchRate,
		decimal? PInCheckAmt,
		string PCustCurr,
		DateTime? PRecptDate,
		int? PToCustomer,
		decimal? POutCheckAmt,
		string Infobar);
	}
}

