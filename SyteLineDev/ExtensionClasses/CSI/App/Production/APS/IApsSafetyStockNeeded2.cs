//PROJECT NAME: Production
//CLASS NAME: IApsSafetyStockNeeded2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSafetyStockNeeded2
	{
		decimal? ApsSafetyStockNeeded2Fn(
			string Item,
			string Whse);
	}
}

