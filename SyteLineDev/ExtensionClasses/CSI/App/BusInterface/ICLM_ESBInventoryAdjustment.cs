//PROJECT NAME: BusInterface
//CLASS NAME: ICLM_ESBInventoryAdjustment.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.BusInterface
{
	public interface ICLM_ESBInventoryAdjustment
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ESBInventoryAdjustmentSp(decimal? TransNum);
	}
}

