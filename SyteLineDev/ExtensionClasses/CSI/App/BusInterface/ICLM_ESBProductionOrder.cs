//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBProductionOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBProductionOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBProductionOrderSp(string Job,
		int? Suffix = null);
	}
}

