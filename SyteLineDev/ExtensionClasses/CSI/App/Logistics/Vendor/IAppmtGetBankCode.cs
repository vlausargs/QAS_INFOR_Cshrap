//PROJECT NAME: Logistics
//CLASS NAME: IAppmtGetBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAppmtGetBankCode
	{
		(int? ReturnCode, string PBankCode,
		string Infobar) AppmtGetBankCodeSp(string PPayType,
		int? PCheckNum,
		string PVendNum,
		DateTime? PCheckDate,
		decimal? PAmtPaid,
		string PBankCode,
		string Infobar);
	}
}

