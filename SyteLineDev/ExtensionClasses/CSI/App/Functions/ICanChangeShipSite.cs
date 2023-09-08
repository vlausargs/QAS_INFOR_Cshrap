//PROJECT NAME: Data
//CLASS NAME: ICanChangeShipSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICanChangeShipSite
	{
		int? CanChangeShipSiteFn(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			string ShipSite);
	}
}

