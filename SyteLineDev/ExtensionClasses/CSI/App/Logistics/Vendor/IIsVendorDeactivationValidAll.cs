//PROJECT NAME: Logistics
//CLASS NAME: IIsVendorDeactivationValidAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IIsVendorDeactivationValidAll
	{
		(int? ReturnCode, string Infobar) IsVendorDeactivationValidAllSp(string VendNum,
		int? Active = 1,
		string SiteRef = null,
		string Infobar = null);
	}
}

