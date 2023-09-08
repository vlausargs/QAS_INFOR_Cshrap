//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_TestResults.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_TestResults
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_TestResultsSp(
			string begitem = null,
			string enditem = null,
			DateTime? begtdate = null,
			DateTime? endtdate = null,
			string beginsp = null,
			string endinsp = null,
			string begrefnum = null,
			string endrefnum = null,
			int? begrcvr = null,
			int? endrcvr = null,
			string testtype = null,
			string reftype = null,
			int? PrintInternal = null,
			int? PrintExternal = null,
			int? displayheader = null,
			int? firstarticle = null);
	}
}

