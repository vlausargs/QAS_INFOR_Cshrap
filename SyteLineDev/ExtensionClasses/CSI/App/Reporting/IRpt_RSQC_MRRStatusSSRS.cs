//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_MRRStatusSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_MRRStatusSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_MRRStatusSSRSSp(string beginsp = null,
		string endinsp = null,
		DateTime? begcdate = null,
		DateTime? endcdate = null,
		DateTime? begsdate = null,
		DateTime? endsdate = null,
		DateTime? begcldate = null,
		DateTime? endcldate = null,
		string begmrr = null,
		string endmrr = null,
		string begitem = null,
		string enditem = null,
		string reftype = null,
		int? openonly = 1,
		int? displayheader = null,
		int? PrintNotes = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

