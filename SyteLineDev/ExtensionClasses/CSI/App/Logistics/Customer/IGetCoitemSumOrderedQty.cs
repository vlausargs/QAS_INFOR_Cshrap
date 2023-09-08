//PROJECT NAME: Logistics
//CLASS NAME: IGetCoitemSumOrderedQty.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCoitemSumOrderedQty
	{
		(int? ReturnCode, decimal? TotalOrdered) GetCoitemSumOrderedQtySp(string CoNum,
		int? CoLine,
		decimal? TotalOrdered);
	}
}

