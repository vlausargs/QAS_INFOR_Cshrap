//PROJECT NAME: Logistics
//CLASS NAME: IIsVendorActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IIsVendorActive
	{
		(int? ReturnCode, string Infobar) IsVendorActiveSp(string VendNum,
		string Infobar);
	}
}

