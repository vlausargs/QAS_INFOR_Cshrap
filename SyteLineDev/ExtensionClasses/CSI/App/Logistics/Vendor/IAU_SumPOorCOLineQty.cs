//PROJECT NAME: Logistics
//CLASS NAME: IAU_SumPOorCOLineQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_SumPOorCOLineQty
	{
		decimal? AU_SumPOorCOLineQtyFn(
			string POorCONum,
			int? POorCoLine,
			string CalcType,
			string CalcColumnType);
	}
}

