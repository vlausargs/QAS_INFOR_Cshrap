//PROJECT NAME: Logistics
//CLASS NAME: ICLM_FTSLLoadPOXdocOrderItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface ICLM_FTSLLoadPOXdocOrderItems
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FTSLLoadPOXdocOrderItemsSp(string Item,
		string Whse,
		string Job,
		int? priority_1,
		int? priority_2,
		int? priority_3,
		int? priority_4,
		int? priority_5,
		int? future_days_1,
		int? future_days_2,
		int? future_days_3,
		int? future_days_4,
		int? future_days_5);
	}
}

