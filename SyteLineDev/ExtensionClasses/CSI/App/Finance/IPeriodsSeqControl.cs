//PROJECT NAME: Finance
//CLASS NAME: IPeriodsSeqControl.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IPeriodsSeqControl
	{
		decimal? PeriodsSeqControlFn(
			int? PeriodsSeqFiscalYear,
			string PeriodsSeqJourControlPrefix,
			int? Period,
			string Site);
	}
}

