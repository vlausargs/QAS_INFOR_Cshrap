//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadXdocOrderItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadXdocOrderItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadXdocOrderItemsSp(string Item,
		string Whse,
		string Job,
		int? priority_1,
		int? priority_2,
		int? priority_3,
		int? priority_4,
		int? future_days_1,
		int? future_days_2,
		int? future_days_3,
		int? future_days_4);
	}
}

