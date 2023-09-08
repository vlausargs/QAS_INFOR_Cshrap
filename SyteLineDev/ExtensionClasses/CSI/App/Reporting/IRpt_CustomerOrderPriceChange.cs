//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CustomerOrderPriceChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CustomerOrderPriceChange
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerOrderPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		string FromCurrCode,
		string ToCurrCode,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? FromDueDate,
		DateTime? ToDueDate,
		int? DisplayHeader = 0,
		string AmtType = "A",
		decimal? PriAmt = 0,
		string pSite = null);
	}
}

