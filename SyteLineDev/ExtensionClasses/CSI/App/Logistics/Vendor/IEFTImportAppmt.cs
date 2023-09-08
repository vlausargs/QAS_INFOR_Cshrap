//PROJECT NAME: Logistics
//CLASS NAME: IEFTImportAppmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IEFTImportAppmt
	{
		(int? ReturnCode, Guid? RefRowPointer,
		string Infobar) EFTImportAppmtSp(string VendNum,
		int? CheckNum,
		DateTime? CheckDate,
		decimal? DomCheckAmt,
		string Ref,
		string txt,
		string InvNum,
		string BankCode,
		string PayType,
		int? CheckSeq,
		decimal? ExchRate,
		decimal? ForCheckAmt,
		DateTime? DueDate,
		int? Factor,
		int? OffSet,
		Guid? RefRowPointer,
		string Infobar);
	}
}

