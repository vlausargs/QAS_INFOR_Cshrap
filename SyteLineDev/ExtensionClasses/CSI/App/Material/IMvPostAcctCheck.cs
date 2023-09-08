//PROJECT NAME: Material
//CLASS NAME: IMvPostAcctCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMvPostAcctCheck
	{
		(int? ReturnCode,
			int? PostAcctChg,
			int? PostCostChg,
			string Infobar) MvPostAcctCheckSp(
			string Item,
			string FromWhse,
			string FromLoc,
			string ToWhse,
			string ToLoc,
			string ItemlocInvAcct,
			string ItemlocLbrAcct,
			string ItemlocFovhdAcct,
			string ItemlocVovhdAcct,
			string ItemlocOutAcct,
			decimal? ItemlocMatlCost,
			decimal? ItemlocLbrCost,
			decimal? ItemlocFovhdCost,
			decimal? ItemlocVovhdCost,
			decimal? ItemlocOutCost,
			string XItemlocInvAcct,
			string XItemlocLbrAcct,
			string XItemlocFovhdAcct,
			string XItemlocVovhdAcct,
			string XItemlocOutAcct,
			decimal? XItemlocMatlCost,
			decimal? XItemlocLbrCost,
			decimal? XItemlocFovhdCost,
			decimal? XItemlocVovhdCost,
			decimal? XItemlocOutCost,
			string ProdcodeInvAdjAcct,
			string ItemCostMethod,
			int? ItemLotTracked,
			int? PostAcctChg,
			int? PostCostChg,
			string Infobar);
	}
}

