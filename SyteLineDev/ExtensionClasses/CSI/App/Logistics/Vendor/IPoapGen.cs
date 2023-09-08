//PROJECT NAME: Logistics
//CLASS NAME: IPoapGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IPoapGen
	{
		(int? ReturnCode, int? PoVoucher,
		string Infobar) PoapGenSp(string PVendNum,
		string PVchAdj,
		int? PVoucher,
		DateTime? PDistDate,
		int? PIsEdi,
		int? PSeqNum,
		int? PPreRegister,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PInvNum,
		DateTime? PInvDate,
		string PTermsCode,
		string PAuthorizer,
		int? PFixedRate,
		decimal? PExchRate,
		string PFormTitle,
		string CalledFrom = null,
		Guid? PProcessId = null,
		int? PAutoVoucher = null,
		int? PoVoucher = null,
		string Infobar = null,
		string CurrCode = null,
		DateTime? PTaxDate = null);
	}
}

