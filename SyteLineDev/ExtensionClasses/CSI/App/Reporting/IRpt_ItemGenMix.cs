//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemGenMix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemGenMix
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_ItemGenMixSp(string PProdMix,
		int? PNetChange = 0,
		int? PPrintOperText = 1,
		int? PPageBtwOper = 0,
		int? PPrintMatlText = 1,
		int? PDisRefFields = 0,
		int? PDisEffDate = 0,
		DateTime? PEffectDate = null,
		int? ShowInternal = 0,
		int? ShowExternal = 0,
		int? DisplayHeader = 0,
		string Infobar = null,
		string BGSessionId = null,
		string pSite = null,
		string BGUser = null);
	}
}

