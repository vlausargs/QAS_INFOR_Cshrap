//PROJECT NAME: Production
//CLASS NAME: IJobP2W.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobP2W
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar) JobP2WSp(
			string TKeyValue1,
			int? TMach,
			int? TCoby,
			Guid? SJobtranRowPointer,
			Guid? SJobRowPointer,
			Guid? SDeptRowPointer,
			Guid? SWcRowPointer,
			Guid? SJobrouteRowPointer,
			Guid? SJrtSchRowPointer,
			Guid? SProdvarRowPointer,
			Guid? SItemRowPointer,
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

