//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInventoryCount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInventoryCount
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInventoryCountSp(string Item,
		string Whse);
	}
}

