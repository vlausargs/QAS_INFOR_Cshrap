//PROJECT NAME: Reporting
//CLASS NAME: IRpt_JournalControlNumber.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_JournalControlNumber
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_JournalControlNumberSp(string CurId = null,
		string Type = null,
		int? ShowForeignAmounts = null,
		string PrefixStarting = null,
		string PrefixEnding = null,
		string SiteStarting = null,
		string SiteEnding = null,
		int? YearStarting = null,
		int? YearEnding = null,
		int? PeriodStarting = null,
		int? PeriodEnding = null,
		decimal? ControlNumberStarting = null,
		decimal? ControlNumberEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

