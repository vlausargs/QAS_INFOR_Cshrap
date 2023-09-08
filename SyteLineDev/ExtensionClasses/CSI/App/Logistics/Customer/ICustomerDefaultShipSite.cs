//PROJECT NAME: Logistics
//CLASS NAME: ICustomerDefaultShipSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerDefaultShipSite
	{
		int? CustomerDefaultShipSiteSp(string Co_Num = null,
		string Co_Type = null,
		int? Co_Line = null);
	}
}

