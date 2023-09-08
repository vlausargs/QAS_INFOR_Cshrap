//PROJECT NAME: Data
//CLASS NAME: IGlbankChangeAPDraftStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlbankChangeAPDraftStatus
	{
		(int? ReturnCode,
			string Infobar) GlbankChangeAPDraftStatusSp(
			string RefNum,
			string BankHdrBankCode,
			int? GlbankCheckNum,
			decimal? GlbankDomCheckAmt,
			decimal? GlbankCheckAmt,
			string Infobar,
			DateTime? CheckDate = null);
	}
}

