//PROJECT NAME: Finance
//CLASS NAME: IFinRptXMLBufCopy.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptXMLBufCopy
	{
		(int? ReturnCode,
			string Infobar) FinRptXMLBufCopySp(
			Guid? ProcessID,
			string ReportId,
			string FromSite,
			string Infobar);
	}
}

