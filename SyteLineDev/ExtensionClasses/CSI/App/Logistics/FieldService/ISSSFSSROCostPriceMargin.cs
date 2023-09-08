//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSROCostPriceMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSROCostPriceMargin
	{
		int? SSSFSSROCostPriceMarginSP(
			string ParentForm = null,
			string SRONum = null,
			int? SROLine = null,
			int? SROOper = null,
			string PartnerId = null,
			string Type = "P",
			DateTime? BEGTransDate = null,
			DateTime? ENDTransDate = null,
			int? IncludePosted = 1,
			int? IncludeUnposted = 1,
			string BillHold = null,
			string CustNum = null,
			int? CustSeq = null,
			string Whse = null,
			string BillCode = null,
			string InvNum = null,
			string Dept = null,
			DateTime? BEGPostDate = null,
			DateTime? ENDPostDate = null,
			string MatlItem = null,
			string MatlTransType = null,
			string LabrWorkCode = null,
			string MiscMiscCode = null,
			string MiscFSPayType = null);
	}
}

