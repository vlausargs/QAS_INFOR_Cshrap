//PROJECT NAME: Finance
//CLASS NAME: IFinRptLinXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLinXML
	{
		(int? ReturnCode,
			int? RecordCnt,
			string Infobar) FinRptLinXMLSp(
			string FromReportId,
			int? StartSeq,
			int? EndSeq,
			int? Delayed,
			string ToSite,
			string ToReportId,
			string ToSitePrefix,
			string FromSitePrefix,
			int? RunMode,
			int? RecordCnt,
			string Infobar);
	}
}

