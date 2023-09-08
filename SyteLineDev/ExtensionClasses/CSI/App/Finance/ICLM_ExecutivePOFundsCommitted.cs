//PROJECT NAME: Finance
//CLASS NAME: ICLM_ExecutivePOFundsCommitted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_ExecutivePOFundsCommitted
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExecutivePOFundsCommittedSp(string FilterString = null,
		string POStatus = null);
	}
}

