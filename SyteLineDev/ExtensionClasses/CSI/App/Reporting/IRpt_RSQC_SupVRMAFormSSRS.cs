//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_SupVRMAFormSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_SupVRMAFormSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_SupVRMAFormSSRSSp(string begitem = null,
		string enditem = null,
		string begvend = null,
		string endvend = null,
		int? begvrma = null,
		int? endvrma = null,
		string sortby = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

