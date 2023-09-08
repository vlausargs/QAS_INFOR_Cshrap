//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBOpportunityHeader.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBOpportunityHeader
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBOpportunityHeaderSp(string OppId);
	}
}

