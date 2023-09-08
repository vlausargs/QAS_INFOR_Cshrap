//PROJECT NAME: Logistics
//CLASS NAME: IDemandingPoSourceCoSync.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IDemandingPoSourceCoSync
	{
		(int? ReturnCode, string Infobar) DemandingPoSourceCoSyncSp(string ToSite,
		string FromSite,
		string SourceSite,
		string DemandingSite,
		string DemandingPO,
		string SourceCoNum,
		int? SourceCoLine,
		string Infobar,
		decimal? MatltranTransNum = null);
	}
}

