//PROJECT NAME: Reporting
//CLASS NAME: IRPT_ContentionInquiry.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRPT_ContentionInquiry
	{
		(ICollectionLoadResponse Data, int? ReturnCode) RPT_ContentionInquirySP(
			string pSite,
			string Group,
			DateTime? StartDate,
			DateTime? EndDate,
			int? ALTNO,
			string DisplayType,
			int? RecordCap,
			int? Interval,
			string Period,
			string GroupType,
			int? ExcludeInfinite);
	}
}

