//PROJECT NAME: Reporting
//CLASS NAME: ICHSRpt_PostedVchTrnxSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ICHSRpt_PostedVchTrnxSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CHSRpt_PostedVchTrnxSummarySp(string SessionId,
		string pSite = null);
	}
}

