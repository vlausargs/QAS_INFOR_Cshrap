//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCOFilter.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCOFilter
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCOFilterSp(string PCOLineStatus,
		string PCONum);
	}
}

