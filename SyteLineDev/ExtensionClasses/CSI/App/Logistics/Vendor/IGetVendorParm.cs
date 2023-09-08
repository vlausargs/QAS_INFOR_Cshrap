//PROJECT NAME: Logistics
//CLASS NAME: IGetVendorParm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendorParm
	{
		(int? ReturnCode, string VendPriceBy) GetVendorParmSp(string VendNum,
		string VendPriceBy);
	}
}

