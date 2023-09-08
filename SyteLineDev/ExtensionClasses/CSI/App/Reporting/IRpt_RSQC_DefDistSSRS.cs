//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_DefDistSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_DefDistSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_DefDistSSRSSp(string begitem = null,
		string enditem = null,
		DateTime? begtdate = null,
		DateTime? endtdate = null,
		string reftype = null,
		int? displayheader = 0,
		string psite = null);
	}
}

