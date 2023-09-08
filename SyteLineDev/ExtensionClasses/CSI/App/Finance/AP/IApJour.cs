//PROJECT NAME: Finance
//CLASS NAME: IApJour.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.AP
{
	public interface IApJour
	{
		(int? ReturnCode,
			string InfoBar) ApJourSp(
			string JournalID,
			string stat,
			int? PreRegister,
			string VendNum,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string InfoBar);
	}
}

