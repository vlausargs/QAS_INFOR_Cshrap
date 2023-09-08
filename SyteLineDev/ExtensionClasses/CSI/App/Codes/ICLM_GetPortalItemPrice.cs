//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetPortalItemPrice.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetPortalItemPrice
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetPortalItemPriceSp(string ItemRange,
		string ItemPricingSite,
		string CustNum,
		string ResellerCustNum,
		string CurrCode,
		int? IsB2B,
		string Infobar);
	}
}

