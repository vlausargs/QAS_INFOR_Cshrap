//PROJECT NAME: Production
//CLASS NAME: IProjJlabr.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IProjJlabr
	{
		(int? ReturnCode,
			string PCostCode,
			string Infobar) ProjJlabrSp(
			string PProjNum,
			int? PTaskNum,
			string PCostCode,
			string PUnit1,
			string PUnit2,
			Guid? SJobtranRowPointer,
			Guid? SWcRowPointer,
			Guid? MatltranRowPointer,
			string ControlPrefix,
			string ControlSite,
			int? ControlYear,
			int? ControlPeriod,
			decimal? ControlNumber,
			string Infobar);
	}
}

