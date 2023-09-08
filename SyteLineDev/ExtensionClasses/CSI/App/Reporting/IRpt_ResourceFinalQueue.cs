//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceFinalQueue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceFinalQueue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceFinalQueueSp(string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

