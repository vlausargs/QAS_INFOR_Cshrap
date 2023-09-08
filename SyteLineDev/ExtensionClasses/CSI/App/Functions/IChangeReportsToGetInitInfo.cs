//PROJECT NAME: Data
//CLASS NAME: IChangeReportsToGetInitInfo.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IChangeReportsToGetInitInfo
	{
		(int? ReturnCode,
			string ReportToSite,
			DateTime? CutoffDate,
			int? Recover,
			string Infobar) ChangeReportsToGetInitInfoSp(
			string ReportToSite,
			DateTime? CutoffDate,
			int? Recover,
			string Infobar);
	}
}

