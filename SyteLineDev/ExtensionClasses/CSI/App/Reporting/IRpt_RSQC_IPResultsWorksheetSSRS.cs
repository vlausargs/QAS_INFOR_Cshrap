//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_IPResultsWorksheetSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_IPResultsWorksheetSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_IPResultsWorksheetSSRSSp(string begitem = null,
		string enditem = null,
		int? begopernum = null,
		int? endopernum = null,
		int? printworksheet = null,
		int? numentries = null,
		int? pagepertest = null,
		int? displayheader = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

