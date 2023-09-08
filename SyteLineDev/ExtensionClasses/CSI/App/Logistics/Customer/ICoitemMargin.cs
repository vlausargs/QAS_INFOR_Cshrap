//PROJECT NAME: Logistics
//CLASS NAME: ICoitemMargin.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICoitemMargin
	{
		decimal? CoitemMarginFn(
			string CoNum,
			int? CoLine,
			int? CoRelease,
			int? PercentOrValue);
	}
}

