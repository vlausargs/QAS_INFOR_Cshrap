//PROJECT NAME: Logistics
//CLASS NAME: IIsVendorStatusDeactivationValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IIsVendorStatusDeactivationValid
	{
		(int? ReturnCode, string Infobar) IsVendorStatusDeactivationValidSp(string Stat,
		int? Active = 1,
		string Infobar = null);
	}
}

