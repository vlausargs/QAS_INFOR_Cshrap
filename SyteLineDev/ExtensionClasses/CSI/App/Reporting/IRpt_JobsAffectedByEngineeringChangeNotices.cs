//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobsAffectedByEngineeringChangeNotices.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobsAffectedByEngineeringChangeNotices
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JobsAffectedByEngineeringChangeNoticesSp(int? ECNStarting = null,
		int? ECNEnding = null,
		string ECNStatus = null,
		string JobType = null,
		int? ECNPrintWHEREUsed = null,
		int? DisplayHeader = null,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null);
	}
}

