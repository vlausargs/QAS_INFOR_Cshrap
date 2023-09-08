//PROJECT NAME: Data
//CLASS NAME: IGetCoitemQtyReady.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGetCoitemQtyReady
	{
		decimal? GetCoitemQtyReadyFn(
			string CoNum,
			int? CoLine,
			int? CoRelease);
	}
}

