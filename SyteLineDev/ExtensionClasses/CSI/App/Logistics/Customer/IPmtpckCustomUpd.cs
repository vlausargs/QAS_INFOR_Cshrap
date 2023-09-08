//PROJECT NAME: Logistics
//CLASS NAME: IPmtpckCustomUpd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IPmtpckCustomUpd
	{
		int? PmtpckCustomUpdSp(string PBankCode,
		string PCustNum,
		string PType,
		int? PCheckNum,
		string PInvNum,
		int? PInvSeq,
		int? PCheckSeq,
		string PSite,
		DateTime? PInvDate,
		DateTime? PDueDate,
		DateTime? PDiscDate,
		string PCoNum,
		string PArtranType,
		string PApplyCustNum,
		string PPayType,
		decimal? PTcAmtAmount,
		decimal? PTcAmtOrigAmt,
		decimal? PTcAmtTotPaid,
		decimal? PTcAmtAmtApplied,
		decimal? PTcAmtDiscAmt,
		decimal? PTcAmtAllowAmt,
		decimal? PDomAmtApplied,
		decimal? PDomDiscAmt,
		decimal? PDomAllowAmt,
		decimal? PForAmtApplied,
		decimal? PForDiscAmt,
		decimal? PForAllowAmt,
		int? PFixedRate,
		decimal? PExchRate,
		string PDescription,
		string PRef,
		int? PPickFlag,
		string PAcct,
		string PAcctUnit1,
		string PAcctUnit2,
		string PAcctUnit3,
		string PAcctUnit4,
		string PDiscAcct,
		string PDiscAcctUnit1,
		string PDiscAcctUnit2,
		string PDiscAcctUnit3,
		string PDiscAcctUnit4,
		string PDoNum,
		int? PUseMultiDueDates,
		string PCreditMemoNum,
		Guid? PProcessId,
		decimal? PShipmentId,
		decimal? PTcAmtChargebackAmt,
		decimal? PDomChargebackAmt,
		decimal? PForChargebackAmt,
		string PTransactionCurrCode,
		decimal? PPaymentAmtApplied);
	}
}

