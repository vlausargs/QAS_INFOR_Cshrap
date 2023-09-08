//PROJECT NAME: Data
//CLASS NAME: IGlbankChangeDraftStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IGlbankChangeDraftStatus
	{
		(int? ReturnCode,
			string Infobar) GlbankChangeDraftStatusSp(
			string BankHdrBankCode,
			int? GlbankCheckNum,
			decimal? GlbankDomCheckAmt,
			decimal? GlbankCheckAmt,
			string Infobar,
			DateTime? CheckDate = null);
	}
}

