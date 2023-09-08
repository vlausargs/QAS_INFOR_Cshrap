//PROJECT NAME: Finance
//CLASS NAME: IFinRptLineGen.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLineGen
	{
		(int? ReturnCode, int? EndSeq,
		string Infobar) FinRptLineGenSp(string ReportId,
		string CopyType,
		string StartingAcct,
		string EndingAcct,
		string AccountTypes,
		int? DelExisting,
		int? InsertAfterLine,
		int? EndSeq,
		string Infobar);
	}
}

