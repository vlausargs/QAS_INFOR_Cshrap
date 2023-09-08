//PROJECT NAME: Data
//CLASS NAME: ICanChangeBlnShipSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanChangeBlnShipSite
	{
		int? CanChangeBlnShipSiteFn(
			string CoNum,
			int? CoLine,
			string ShipSite);
	}
}

