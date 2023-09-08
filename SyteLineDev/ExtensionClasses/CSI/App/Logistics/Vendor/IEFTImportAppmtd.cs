//PROJECT NAME: Logistics
//CLASS NAME: IEFTImportAppmtd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IEFTImportAppmtd
	{
		(int? ReturnCode, Guid? RefRowPointer,
		string Infobar) EFTImportAppmtdSp(string VendNum,
		string InvNum,
		int? Voucher,
		string Site,
		string BankCode,
		decimal? DetailAmount,
		DateTime? EffectiveDate,
		int? CheckSeq,
		Guid? RefRowPointer,
		string Infobar);
	}
}

