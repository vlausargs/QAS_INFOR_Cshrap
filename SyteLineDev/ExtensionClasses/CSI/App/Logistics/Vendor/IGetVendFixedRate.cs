//PROJECT NAME: Logistics
//CLASS NAME: IGetVendFixedRate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IGetVendFixedRate
	{
			(int? ReturnCode,
			int? FixedRate,
			string Infobar) 
		GetVendFixedRateSp(
			string VendNum,
			string CurrCode,
			int? FixedRate,
			string Infobar);
	}
}

