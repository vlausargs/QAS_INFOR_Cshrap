//PROJECT NAME: Logistics
//CLASS NAME: ICalcUnitCredit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICalcUnitCredit
	{
		(int? ReturnCode, decimal? PUnitCreditConv,
		string Infobar,
		int? PIncludeTaxInPrice) CalcUnitCreditSp(string PRmaNum,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string PItem,
		string PUM,
		decimal? PQtyToReturnConv,
		string PPricecode,
		string PCustItem = null,
		decimal? PUnitCreditConv = null,
		string Infobar = null,
		int? PIncludeTaxInPrice = null);
	}
}

