//PROJECT NAME: Data
//CLASS NAME: IprjresQtyConv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IprjresQtyConv
	{
		decimal? prjresQtyConvFn(
			string PUM,
			string PItem,
			decimal? PQty,
			string Site = null);
	}
}

