//PROJECT NAME: Finance
//CLASS NAME: IFinRptLineReSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptLineReSeq
	{
		(int? ReturnCode, string Infobar) FinRptLineReSeqSp(string PRptId,
		int? PFromSeq,
		int? PToSeq,
		int? PStartSeq,
		int? PStepSize,
		string Infobar);
	}
}

