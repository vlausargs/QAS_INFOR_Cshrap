//PROJECT NAME: Finance
//CLASS NAME: IFinRptLinCXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLinCXML
	{
		(int? ReturnCode,
			string Infobar) FinRptLinCXMLSp(
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

