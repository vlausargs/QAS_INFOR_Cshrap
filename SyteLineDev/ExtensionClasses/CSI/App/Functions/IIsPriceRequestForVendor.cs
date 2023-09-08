//PROJECT NAME: Data
//CLASS NAME: IIsPriceRequestForVendor.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IIsPriceRequestForVendor
	{
		int? IsPriceRequestForVendorFn(
			string VendNum,
			string IprId);
	}
}

