//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCashSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCashSummary
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCashSummarySp();
	}
}

