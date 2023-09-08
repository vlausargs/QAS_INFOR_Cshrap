//PROJECT NAME: Finance
//CLASS NAME: IFinRptLineDefaultSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLineDefaultSeq
	{
		(int? ReturnCode, int? FirstSeq,
		int? LastSeq,
		string Infobar) FinRptLineDefaultSeqSp(string RptId,
		int? FirstSeq,
		int? LastSeq,
		string Infobar);
	}
}

