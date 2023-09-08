//PROJECT NAME: Logistics
//CLASS NAME: IAU_CheckPoLineAndBlanket.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAU_CheckPoLineAndBlanket
	{
		(int? ReturnCode, string Item,
		string UM,
		string Description,
		string VendorItem,
		string VendorUM,
		string Infobar) AU_CheckPoLineAndBlanketSp(string PoNum,
		int? PoLine,
		string Item,
		string UM,
		string Description,
		string VendorItem,
		string VendorUM,
		string Infobar);
	}
}

