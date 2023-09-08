//PROJECT NAME: Codes
//CLASS NAME: ICLM_GetPortalOrderItemPriceChanges.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICLM_GetPortalOrderItemPriceChanges
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_GetPortalOrderItemPriceChangesSp(string CoNum,
		string CurrCode,
		string PrimarySite,
		string ResellerSlsman,
		string PricingPrecalculationRule,
		int? GenericIfNoCustSpecific,
		string Infobar);
	}
}

