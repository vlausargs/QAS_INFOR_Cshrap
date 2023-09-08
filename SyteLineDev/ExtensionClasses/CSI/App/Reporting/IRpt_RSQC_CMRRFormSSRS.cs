//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_CMRRFormSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_CMRRFormSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_CMRRFormSSRSSp(string begcmr = null,
		string endcmr = null,
		string beginsp = null,
		string endinsp = null,
		DateTime? begcreatedate = null,
		DateTime? endcreatedate = null,
		DateTime? begclosedate = null,
		DateTime? endclosedate = null,
		int? printnotes = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		string psite = null);
	}
}

