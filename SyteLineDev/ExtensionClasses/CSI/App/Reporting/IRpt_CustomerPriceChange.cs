//PROJECT NAME: Reporting
//CLASS NAME: IRpt_CustomerPriceChange.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_CustomerPriceChange
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_CustomerPriceChangeSp(string FromProductCode,
		string ToProductCode,
		string FromItem,
		string ToItem,
		DateTime? FromEffectDate,
		DateTime? ToEffectDate,
		string FromCustNum,
		string ToCustNum,
		string FromCustType,
		string ToCustType,
		string FromEndUserType,
		string ToEndUserType,
		DateTime? NewEffectDate,
		int? UpdateCreate = 0,
		int? DisplayHeader = 0,
		string AmtType = "A",
		decimal? PriAmt = 0,
		string FromCurrCode = null,
		string ToCurrCode = null,
		string pSite = null);
	}
}

