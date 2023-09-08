//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_TRRStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_TRRStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TRRStatusSSRSSp(string beginsp = null,
		string endinsp = null,
		DateTime? begcdate = null,
		DateTime? endcdate = null,
		DateTime? begcldate = null,
		DateTime? endcldate = null,
		string begtrr = null,
		string endtrr = null,
		int? openonly = 1,
		int? displayheader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

