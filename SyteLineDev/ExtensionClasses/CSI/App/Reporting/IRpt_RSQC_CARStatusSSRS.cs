//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CARStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CARStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CARStatusSSRSSp(string beginsp = null,
		string endinsp = null,
		DateTime? begcdate = null,
		DateTime? endcdate = null,
		DateTime? begddate = null,
		DateTime? endddate = null,
		DateTime? begcldate = null,
		DateTime? endcldate = null,
		string begitem = null,
		string enditem = null,
		string reftype = null,
		int? openonly = null,
		int? shownotes = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		int? displayheader = null,
		string psite = null);
	}
}

