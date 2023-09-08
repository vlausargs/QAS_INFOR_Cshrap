//PROJECT NAME: Finance
//CLASS NAME: IFinRptHdrXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptHdrXML
	{
		(int? ReturnCode,
			string Infobar) FinRptHdrXMLSp(
			string FromReportId,
			string ToSite,
			string ToReportId,
			string Infobar);
	}
}

