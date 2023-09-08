//PROJECT NAME: Finance
//CLASS NAME: IPeriodsRemoteSave.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPeriodsRemoteSave
	{
		(int? ReturnCode,
			string Infobar) PeriodsRemoteSaveSp(
			string pMode,
			int? FiscalYear,
			DateTime? PerStart1,
			DateTime? PerStart2,
			DateTime? PerStart3,
			DateTime? PerStart4,
			DateTime? PerStart5,
			DateTime? PerStart6,
			DateTime? PerStart7,
			DateTime? PerStart8,
			DateTime? PerStart9,
			DateTime? PerStart10,
			DateTime? PerStart11,
			DateTime? PerStart12,
			DateTime? PerStart13,
			DateTime? PerEnd1,
			DateTime? PerEnd2,
			DateTime? PerEnd3,
			DateTime? PerEnd4,
			DateTime? PerEnd5,
			DateTime? PerEnd6,
			DateTime? PerEnd7,
			DateTime? PerEnd8,
			DateTime? PerEnd9,
			DateTime? PerEnd10,
			DateTime? PerEnd11,
			DateTime? PerEnd12,
			DateTime? PerEnd13,
			string PerStat1,
			string PerStat2,
			string PerStat3,
			string PerStat4,
			string PerStat5,
			string PerStat6,
			string PerStat7,
			string PerStat8,
			string PerStat9,
			string PerStat10,
			string PerStat11,
			string PerStat12,
			string PerStat13,
			int? CurPer,
			int? Closed,
			string Infobar,
			int? RepFromTrigger = 0,
			string RepFromSite = null,
			string UETListPairs = null);
	}
}

