//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBProductionReceiverItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBProductionReceiverItem
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBProductionReceiverItemSp(decimal? TransNum,
		string RecordType);
	}
}

