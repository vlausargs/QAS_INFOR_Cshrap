//PROJECT NAME: Production
//CLASS NAME: IJobP2Wc.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobP2Wc
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar) JobP2WcSp(
			string TKeyValue1,
			Guid? SJobtranRowPointer,
			Guid? SJobRowPointer,
			Guid? SWcRowPointer,
			Guid? SJobrouteRowPointer,
			Guid? SJrtSchRowPointer,
			Guid? SProdvarRowPointer,
			Guid? SItemRowPointer,
			int? TCoby,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar,
			string DocumentNum = null,
			string JournalId = null);
	}
}

