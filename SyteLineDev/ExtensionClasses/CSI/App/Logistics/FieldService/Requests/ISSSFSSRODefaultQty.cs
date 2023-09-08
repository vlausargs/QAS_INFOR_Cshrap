//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSRODefaultQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService.Requests
{
	public interface ISSSFSSRODefaultQty
	{
		(int? ReturnCode, decimal? Qty) SSSFSSRODefaultQtySp(string RefNum,
		int? RefLine,
		decimal? Qty);
	}
}

