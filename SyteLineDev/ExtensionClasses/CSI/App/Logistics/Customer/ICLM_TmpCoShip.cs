//PROJECT NAME: Logistics
//CLASS NAME: ICLM_TmpCoShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_TmpCoShip
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TmpCoShipSp(Guid? ProcessId,
		string PCoNum,
		int? PCoLine,
		int? PCoRelease,
		string FilterString = null);
	}
}

