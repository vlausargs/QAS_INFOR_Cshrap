//PROJECT NAME: Reporting
//CLASS NAME: IRpt_Interactions.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_Interactions
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_InteractionsSp(string InteractionType = "C",
		decimal? BegInteractionID = null,
		decimal? EndInteractionID = null,
		string BegRefnum = null,
		string EndRefnum = null,
		DateTime? Beginteraction_date = null,
		DateTime? Endinteraction_date = null,
		DateTime? Begfollow_date = null,
		DateTime? Endfollow_date = null,
		string Begentered_by = null,
		string Endentered_by = null,
		string Begsalesman = null,
		string Endsalesman = null,
		string Begcontact = null,
		string Endcontact = null,
		string Begtopic = null,
		string Endtopic = null,
		string CommStat = null,
		string CommSort = null,
		int? StartingTransDateOffset = null,
		int? EndingTransDateOffset = null,
		int? StartingfollowDateOffset = null,
		int? EndingfollowDateOffset = null,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		string pSite = null);
	}
}

