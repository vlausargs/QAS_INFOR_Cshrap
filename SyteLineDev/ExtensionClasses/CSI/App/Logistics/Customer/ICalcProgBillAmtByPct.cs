//PROJECT NAME: Logistics
//CLASS NAME: ICalcProgBillAmtByPct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICalcProgBillAmtByPct
	{
		(int? ReturnCode, decimal? BillAmount,
		decimal? CoitemPrice,
		string Infobar) CalcProgBillAmtByPctSp(string CoNum,
		int? CoLine,
		int? Percent,
		decimal? BillAmount,
		decimal? CoitemPrice,
		string Infobar);
	}
}

