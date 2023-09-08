//PROJECT NAME: Logistics
//CLASS NAME: ICLM_ServiceOrders.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ICLM_ServiceOrders
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ServiceOrdersSp(string OrderFilter,
		string SlsmanList,
		string FilterString,
		string PSiteGroup = null);
	}
}

