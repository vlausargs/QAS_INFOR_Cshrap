//PROJECT NAME: Logistics
//CLASS NAME: IChkPay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IChkPay
	{
		(int? ReturnCode, string TPayhold,
		string Infobar) ChkPaySp(string VendorVendNum,
		string TPayhold,
		string Infobar);
	}
}

