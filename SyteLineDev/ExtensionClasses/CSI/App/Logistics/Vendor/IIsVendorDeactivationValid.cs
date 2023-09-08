//PROJECT NAME: Logistics
//CLASS NAME: IIsVendorDeactivationValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IIsVendorDeactivationValid
	{
		(int? ReturnCode, string Infobar) IsVendorDeactivationValidSp(string VendNum,
		int? Active = 1,
		int? FromMethod = 1,
		string Infobar = null);
	}
}

