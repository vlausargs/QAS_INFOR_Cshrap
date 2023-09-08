//PROJECT NAME: Logistics
//CLASS NAME: IGetDropShipToAddr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetDropShipToAddr
	{
		(int? ReturnCode, string ShipToAddress) GetDropShipToAddrSp(string ShipTo,
		string DropShipNo,
		int? DropSeqNo,
		string SiteRef,
		string ShipToAddress);
	}
}

