//PROJECT NAME: Production
//CLASS NAME: IJobP4.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobP4
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar) JobP4Sp(
			Guid? JobtranRP,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar,
			string DocumentNum = null,
			string JournalId = null);
	}
}

