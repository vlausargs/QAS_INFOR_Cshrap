//PROJECT NAME: Data
//CLASS NAME: ITHASaveAptrxp.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ITHASaveAptrxp
	{
		(int? ReturnCode,
			string Infobar) THASaveAptrxpSp(
			string VendNum,
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
			string Infobar);
	}
}

