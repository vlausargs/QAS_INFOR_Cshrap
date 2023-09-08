//PROJECT NAME: Finance
//CLASS NAME: IFinRptLinSXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLinSXML
	{
		(int? ReturnCode,
			string Infobar) FinRptLinSXMLSp(
			string FromReportId,
			int? StartSeq,
			int? EndSeq,
			int? Delayed,
			string ToSite,
			string ToReportId,
			string FromSitePrefix,
			string Infobar);
	}
}

