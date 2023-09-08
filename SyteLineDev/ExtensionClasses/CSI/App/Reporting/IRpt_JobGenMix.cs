//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JobGenMix.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JobGenMix
	{
		(ICollectionLoadResponse Data, int? ReturnCode, string Infobar) Rpt_JobGenMixSp(string PJob,
		int? PSuffix,
		Guid? SessionID,
		string Infobar,
		string BGSessionId = null,
		int? TaskId = null,
		string pSite = null,
		string BGUser = null);
	}
}

