//PROJECT NAME: Data
//CLASS NAME: IEXTSSSFSGetOrderInfoOrderQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEXTSSSFSGetOrderInfoOrderQty
	{
		decimal? EXTSSSFSGetOrderInfoOrderQtyFn(
			string OrderNum,
			int? OrderLine);
	}
}

