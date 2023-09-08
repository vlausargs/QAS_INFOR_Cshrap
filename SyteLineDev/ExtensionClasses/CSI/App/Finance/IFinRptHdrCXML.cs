//PROJECT NAME: Finance
//CLASS NAME: IFinRptHdrCXML.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptHdrCXML
	{
		(int? ReturnCode,
			string Infobar) FinRptHdrCXMLSp(
			string FromReportId,
			string ToSite,
			string ToReportId,
			string Infobar);
	}
}

