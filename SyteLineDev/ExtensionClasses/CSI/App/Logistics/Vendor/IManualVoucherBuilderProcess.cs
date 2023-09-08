//PROJECT NAME: Logistics
//CLASS NAME: IManualVoucherBuilderProcess.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface IManualVoucherBuilderProcess
	{
		int? ManualVoucherBuilderProcessSp(string PToSite,
		string PVendNum,
		string PInvNum,
		DateTime? PInvDate,
		DateTime? PDistDate,
		string PTxt,
		int? PGenerateDistributions,
		int? PFixedRate,
		decimal? PExchRate,
		decimal? PPurchAmt,
		decimal? PFreight,
		decimal? PDuty,
		decimal? PBrokerage,
		decimal? PInsurance,
		decimal? PLocFrt,
		decimal? PMiscCharges,
		decimal? PSalesTax,
		decimal? PSalesTax2,
		string PBuilderVoucherOrigSite,
		string PBuilderVoucher,
		DateTime? PTaxDate);
	}
}

