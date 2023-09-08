//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_COC.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_COC
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_COCSp(
			string BegCoc = null,
			string EndCoc = null,
			int? BegRcvr = null,
			int? EndRcvr = null,
			string BegCoNum = null,
			string EndCoNum = null,
			int? BegLine = null,
			int? EndLine = null,
			int? BegRel = null,
			int? EndRel = null,
			string BegCust = null,
			string EndCust = null,
			int? PrintCustNotes = null,
			int? PrintOrderNotes = null,
			int? PrintQCCustNotes = null,
			int? PrintRcvrNotes = null,
			int? PrintCocNotes = null,
			int? ShowTests = null,
			int? PrintInternal = null,
			int? PrintExternal = null,
			string ref_type = null);
	}
}

