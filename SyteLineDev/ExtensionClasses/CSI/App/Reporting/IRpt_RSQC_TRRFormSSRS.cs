//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_TRRFormSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_TRRFormSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TRRFormSSRSSp(string begtrr = null,
		string endtrr = null,
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

