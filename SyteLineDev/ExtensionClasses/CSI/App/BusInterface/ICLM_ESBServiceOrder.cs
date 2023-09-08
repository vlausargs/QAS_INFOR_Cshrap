//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBServiceOrder.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBServiceOrder
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBServiceOrderSp(string SroNum);
	}
}

