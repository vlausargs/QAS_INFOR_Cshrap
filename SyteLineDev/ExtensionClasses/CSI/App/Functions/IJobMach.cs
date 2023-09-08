//PROJECT NAME: Data
//CLASS NAME: IJobMach.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IJobMach
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar) JobMachSp(
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
			string JournalId = null);
	}
}

