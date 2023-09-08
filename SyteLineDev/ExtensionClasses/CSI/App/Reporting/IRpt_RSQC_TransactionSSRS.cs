//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_TransactionSSRS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_TransactionSSRS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TransactionSSRSSp(DateTime? begtdate = null,
		DateTime? endtdate = null,
		string begdcode = null,
		string enddcode = null,
		string begitem = null,
		string enditem = null,
		string beginsp = null,
		string endinsp = null,
		string beguser = null,
		string enduser = null,
		string reftype = null,
		string status = null,
		int? openonly = null,
		string begentity = null,
		string endentity = null,
		int? displayheader = null,
		string psite = null);
	}
}

