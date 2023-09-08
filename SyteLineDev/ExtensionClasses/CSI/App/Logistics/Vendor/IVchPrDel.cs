//PROJECT NAME: Logistics
//CLASS NAME: IVchPrDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IVchPrDel
	{
		(int? ReturnCode, string Infobar) VchPrDelSp(int? BegPreRegister,
		int? EndPreRegister,
		string BegVendNum,
		string EndVendNum,
		DateTime? BegVchDate,
		DateTime? EndVchDate,
		int? DateNulChk,
		string Infobar,
		int? StartingVoucherDateOffset = null,
		int? EndingVoucherDateOffset = null);
	}
}

