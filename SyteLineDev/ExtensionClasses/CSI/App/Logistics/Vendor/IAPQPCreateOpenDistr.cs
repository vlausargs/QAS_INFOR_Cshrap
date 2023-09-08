//PROJECT NAME: Logistics
//CLASS NAME: IAPQPCreateOpenDistr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IAPQPCreateOpenDistr
	{
		int? APQPCreateOpenDistrSp(Guid? SessionId,
		int? Selected,
		string AptrxpTypeDesc,
		int? Voucher,
		string SiteRef,
		string VendNum,
		DateTime? DueDate,
		string BankCode,
		int? CheckSeq,
		string ApplyVendNum,
		int? CheckNum,
		decimal? DomAmtPaid,
		decimal? ExchRate,
		decimal? ForAmtPaid,
		Guid? AppmtRowPointer);
	}
}

