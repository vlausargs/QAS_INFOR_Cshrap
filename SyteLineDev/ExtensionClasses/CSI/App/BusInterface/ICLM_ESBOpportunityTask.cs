//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBOpportunityTask.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBOpportunityTask
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBOpportunityTaskSp(string OppId);
	}
}

