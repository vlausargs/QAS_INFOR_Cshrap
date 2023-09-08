//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjRetInv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjRetInv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjRetInvSp(string StartingProjNum = null,
		string EndingProjNum = null,
		DateTime? PostDate = null,
		string InvoiceText = null,
		int? PrintEuroTotal = null,
		int? XLateToDomestic = null,
		int? DoPost = null,
		int? ShowInternal = null,
		int? ShowExternal = null,
		int? DisplayHeader = null,
		int? TransReport = null,
		int? PrintDiscountAmt = 0,
		decimal? UserId = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

