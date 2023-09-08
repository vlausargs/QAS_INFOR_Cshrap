//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ProjRetTrans.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ProjRetTrans
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ProjRetTransSp(string StartingProjNum = null,
		string EndingProjNum = null,
		DateTime? PostDate = null,
		string InvoiceText = "PLS",
		int? PrintEuroTotal = 0,
		int? XLateToDomestic = 0,
		int? DoPost = 0,
		int? ShowInternal = 1,
		int? ShowExternal = 1,
		int? DisplayHeader = 1,
		int? TransReport = 1,
		decimal? UserId = null,
		string BGSessionId = null,
		string pSite = null);
	}
}

