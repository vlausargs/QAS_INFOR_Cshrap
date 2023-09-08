//PROJECT NAME: Production
//CLASS NAME: IApsBomOrderQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsBomOrderQty
	{
		decimal? ApsBomOrderQtyFn(
			string pJob,
			int? pSuffix,
			int? pOperNum,
			decimal? pSequence);
	}
}

