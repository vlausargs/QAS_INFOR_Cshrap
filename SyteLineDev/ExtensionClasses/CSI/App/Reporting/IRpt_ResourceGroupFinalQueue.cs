//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ResourceGroupFinalQueue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ResourceGroupFinalQueue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ResourceGroupFinalQueueSp(string ResourceStarting = null,
		string ResourceEnding = null,
		string ResourceGroupStarting = null,
		string ResourceGroupEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

