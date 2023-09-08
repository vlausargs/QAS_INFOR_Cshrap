//PROJECT NAME: Material
//CLASS NAME: ICLM_GetPortalItemPricingOptions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_GetPortalItemPricingOptions
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetPortalItemPricingOptionsSp(string Item,
		string CustNum,
		int? B2BPricingOptions,
		string CurrCode,
		string PrimarySite,
		string ResellerSlsman,
		string PricingPrecalculationRule,
		int? GenericIfNoCustSpecific,
		string ShipFromSite,
		string LCID,
		string Infobar);
	}
}

