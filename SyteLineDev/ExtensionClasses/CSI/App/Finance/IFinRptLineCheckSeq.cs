//PROJECT NAME: Finance
//CLASS NAME: IFinRptLineCheckSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLineCheckSeq
	{
		(int? ReturnCode, string Infobar) FinRptLineCheckSeqSp(string RptId,
		int? Seq,
		string Infobar);
	}
}

