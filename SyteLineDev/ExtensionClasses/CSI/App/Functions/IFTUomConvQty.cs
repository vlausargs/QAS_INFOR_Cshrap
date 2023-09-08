//PROJECT NAME: Data
//CLASS NAME: IFTUomConvQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFTUomConvQty
	{
		decimal? FTUomConvQtyFn(
			decimal? QtyToBeConverted,
			decimal? UomConvFactor,
			string FromBase);
	}
}

