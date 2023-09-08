//PROJECT NAME: Finance
//CLASS NAME: ICHSInputJournalIns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSInputJournalIns
	{
		(int? ReturnCode, string Infobar) CHSInputJournalInsSp(decimal? TransNum,
		string Acct,
		DateTime? TransDate,
		decimal? DomAmt,
		string Ref,
		string VendNum,
		string Voucher,
		int? CheckNum,
		DateTime? CheckDate,
		string FromSite,
		string FromId,
		decimal? VouchSeq,
		string RefType,
		decimal? MatlTransNum,
		decimal? DTransNum,
		string BankCode,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string CurrCode,
		decimal? ExchRate,
		decimal? ForAmount,
		string Site,
		string Hierarchy,
		string Consolidated,
		string ControlPrefix,
		string ControlSite,
		int? ControlYear,
		int? ControlPeriod,
		decimal? ControlNumber,
		int? Year,
		int? Period,
		string CHVouNum,
		int? Line,
		Guid? SessionId,
		string Infobar);
	}
}

