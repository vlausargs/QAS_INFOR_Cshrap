//PROJECT NAME: Logistics
//CLASS NAME: ICLM_PricePromotions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_PricePromotions
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) CLM_PricePromotionsSp(string PCoNum = null,
		string PWhse = null,
		string PItem = null,
		DateTime? PCoOrderDate = null,
		string PromotionCode = null,
		string Infobar = null,
		string CustNum = null,
		int? CustSeq = null,
		string Slsman = null,
		int? FIP = 0);
	}
}

