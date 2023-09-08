//PROJECT NAME: Finance
//CLASS NAME: IFinRptXMLBufCheck.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptXMLBufCheck
	{
		(int? ReturnCode,
			string Infobar) FinRptXMLBufCheckSp(
			Guid? ProcessID,
			string ReportId,
			string Infobar);
	}
}

