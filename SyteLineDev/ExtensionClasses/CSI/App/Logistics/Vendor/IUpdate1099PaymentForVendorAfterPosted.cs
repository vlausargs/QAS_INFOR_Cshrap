//PROJECT NAME: Logistics
//CLASS NAME: IUpdate1099PaymentForVendorAfterPosted.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IUpdate1099PaymentForVendorAfterPosted
	{
		(int? ReturnCode, string Inforbar) Update1099PaymentForVendorAfterPostedSp(string VendNum,
		int? Curr1099Reportable = 0,
		decimal? AmtPaid = null,
		DateTime? DistDate = null,
		string Inforbar = null);
	}
}

