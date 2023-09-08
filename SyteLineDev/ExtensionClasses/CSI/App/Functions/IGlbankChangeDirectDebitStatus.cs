//PROJECT NAME: Data
//CLASS NAME: IGlbankChangeDirectDebitStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlbankChangeDirectDebitStatus
	{
		(int? ReturnCode,
			string Infobar) GlbankChangeDirectDebitStatusSp(
			string BankHdrBankCode,
			int? GlbankCheckNum,
			decimal? GlbankDomCheckAmt,
			decimal? GlbankCheckAmt,
			string Infobar,
			DateTime? CheckDate = null);
	}
}

