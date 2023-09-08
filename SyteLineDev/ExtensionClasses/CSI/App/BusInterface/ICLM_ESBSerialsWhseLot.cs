//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBSerialsWhseLot.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBSerialsWhseLot
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBSerialsWhseLotSp(string Item,
		string Warehouse,
		string Lot,
		string HoldCode);
	}
}

