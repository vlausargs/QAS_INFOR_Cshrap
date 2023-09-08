//PROJECT NAME: Logistics
//CLASS NAME: IFetchPreassignedLots.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IFetchPreassignedLots
	{
		(int? ReturnCode, string Infobar) FetchPreassignedLotsSp(string Item,
		string Prefix,
		int? Qty,
		string Infobar,
		string Site = null);
	}
}

