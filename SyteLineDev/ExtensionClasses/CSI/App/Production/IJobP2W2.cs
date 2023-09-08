//PROJECT NAME: Production
//CLASS NAME: IJobP2W2.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IJobP2W2
	{
		(int? ReturnCode,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			Guid? TMatltranRecid,
			string Infobar) JobP2W2Sp(
			Guid? SJobtranRowPointer,
			Guid? SJobRowPointer,
			Guid? SWcRowPointer,
			Guid? SJobrouteRowPointer,
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

