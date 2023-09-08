//PROJECT NAME: Finance
//CLASS NAME: ICLM_DunningCustHistory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_DunningCustHistory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DunningCustHistorySp(string CustNum = null);
	}
}

