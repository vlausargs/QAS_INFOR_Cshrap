//PROJECT NAME: Finance
//CLASS NAME: IFinRptToSiteCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptToSiteCopy
	{
		(int? ReturnCode,
			int? RecordCnt,
			string Infobar) FinRptToSiteCopySp(
			string FromReportId,
			int? StartSeq,
			int? EndSeq,
			string ToSite,
			string ToReportId,
			int? RunMode,
			int? RecordCnt,
			string Infobar);
	}
}

