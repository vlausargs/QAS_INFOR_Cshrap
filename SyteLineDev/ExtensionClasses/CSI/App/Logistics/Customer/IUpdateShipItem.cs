//PROJECT NAME: Logistics
//CLASS NAME: IUpdateShipItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IUpdateShipItem
	{
		(int? ReturnCode, string Infobar) UpdateShipItemSp(string CoNum,
		int? CoLine,
		int? CoRelease,
		int? Active,
		string Infobar,
		int? BatchId,
		int? DoLine);
	}
}

