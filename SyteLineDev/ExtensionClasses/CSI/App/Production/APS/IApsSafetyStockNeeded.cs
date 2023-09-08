//PROJECT NAME: Production
//CLASS NAME: IApsSafetyStockNeeded.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSafetyStockNeeded
	{
		decimal? ApsSafetyStockNeededFn(
			string pItem);
	}
}

