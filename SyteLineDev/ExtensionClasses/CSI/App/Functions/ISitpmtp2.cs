//PROJECT NAME: Data
//CLASS NAME: ISitpmtp2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISitpmtp2
	{
		(int? ReturnCode,
			decimal? CorpAmountPosted,
			decimal? DomPaidAmount,
			decimal? ForPaidAmount,
			int? Success,
			int? TOpenIsDone,
			string Infobar) Sitpmtp2Sp(
			Guid? TSessionId,
			string TVVchpckSite,
			int? TVVchpckVoucher,
			string TOVchpckSite,
			int? TOVchpckVoucher,
			Guid? RowidAppmt,
			decimal? WireExchangeRate,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			decimal? CorpAmountPosted,
			decimal? DomPaidAmount,
			decimal? ForPaidAmount,
			int? Success,
			int? TOpenIsDone,
			string Infobar);
	}
}

