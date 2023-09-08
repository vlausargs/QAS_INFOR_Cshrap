//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInventoryCountLine.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInventoryCountLine
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInventoryCountLineSp(string Item,
		string Whse);
	}
}

