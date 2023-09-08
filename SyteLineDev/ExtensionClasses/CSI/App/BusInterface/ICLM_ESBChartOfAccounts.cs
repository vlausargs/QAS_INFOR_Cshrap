//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBChartOfAccounts.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBChartOfAccounts
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBChartOfAccountsSp(string Account);
	}
}

