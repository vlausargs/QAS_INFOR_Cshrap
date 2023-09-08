//PROJECT NAME: THLOC
//CLASS NAME: IRemoteSaveAptrxp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.THLOC
{
	public interface IRemoteSaveAptrxp
	{
		(int? ReturnCode, string Infobar) RemoteSaveAptrxpSp(string VendNum,
		int? Voucher,
		int? VouchSeq,
		string PType,
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

