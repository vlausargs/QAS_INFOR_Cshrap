//PROJECT NAME: Data
//CLASS NAME: IGetLastExpDateOfCoShip.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetLastExpDateOfCoShip
	{
		DateTime? GetLastExpDateOfCoShipFn(
			string CoNum,
			int? CoLine);
	}
}

