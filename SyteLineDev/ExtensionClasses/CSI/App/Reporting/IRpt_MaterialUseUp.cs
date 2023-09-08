//PROJECT NAME: Reporting
//CLASS NAME: IRpt_MaterialUseUp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_MaterialUseUp
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_MaterialUseUpSp(int? IncludeSupply,
		string ItemStarting = null,
		string ItemEnding = null,
		string Whse = null,
		DateTime? HardBreakDate = null,
		string pSite = null,
		int? IncludePLNs = 0);
	}
}

