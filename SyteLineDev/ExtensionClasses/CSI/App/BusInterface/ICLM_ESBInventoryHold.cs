//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInventoryHold.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInventoryHold
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInventoryHoldSp(string Item,
		string Whse,
		string Loc,
		string Lot,
		string OldHoldCode,
		string NewHoldCode);
	}
}

