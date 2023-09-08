//PROJECT NAME: Logistics
//CLASS NAME: IGetCustDefaultShipSite.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCustDefaultShipSite
	{
		(int? ReturnCode, string ShipSite,
		string Infobar) GetCustDefaultShipSiteSp(string CustNum,
		int? CustSeq,
		string CoLcrNum,
		string ShipSite,
		string Infobar);
	}
}

