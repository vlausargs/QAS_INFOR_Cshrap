//PROJECT NAME: Logistics
//CLASS NAME: ISaveAptrxp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ISaveAptrxp
	{
		(int? ReturnCode, string Infobar) SaveAptrxpSp(string VendNum,
		int? Voucher,
		int? VouchSeq,
		string PType,
		string Sites,
		int? HoldFlag,
		string VInvNum,
		DateTime? InvDate,
		DateTime? DiscDate,
		DateTime? DueDate,
		int? CheckNum,
		int? Active,
		int? OldVoucher,
		int? OldVouchSeq,
		int? Misc1099Reportable,
		string Infobar);
	}
}

