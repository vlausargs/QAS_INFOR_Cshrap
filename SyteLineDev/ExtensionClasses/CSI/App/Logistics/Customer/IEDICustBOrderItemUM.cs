//PROJECT NAME: Logistics
//CLASS NAME: IEDICustBOrderItemUM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IEDICustBOrderItemUM
	{
		(int? ReturnCode, string ItemUM) EDICustBOrderItemUMSp(string Item,
		string CustNum,
		string ItemUM);
	}
}

