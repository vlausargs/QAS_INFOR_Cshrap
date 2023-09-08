//PROJECT NAME: Production
//CLASS NAME: IApsPurchaseOrderQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPurchaseOrderQty
	{
		decimal? ApsPurchaseOrderQtyFn(
			string pPoNum,
			int? pPoLine,
			int? pPoRelease);
	}
}

