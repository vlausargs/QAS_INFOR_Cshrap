//PROJECT NAME: Finance
//CLASS NAME: IFinRptXMLBufDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptXMLBufDel
	{
		(int? ReturnCode,
			string Infobar) FinRptXMLBufDelSp(
			Guid? ProcessID,
			string ReportId,
			string Infobar);
	}
}

