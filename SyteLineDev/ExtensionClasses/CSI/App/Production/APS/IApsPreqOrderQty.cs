//PROJECT NAME: Data
//CLASS NAME: IApsPreqOrderQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsPreqOrderQty
	{
		decimal? ApsPreqOrderQtyFn(
			string pReqNum,
			int? pReqLine);
	}
}

