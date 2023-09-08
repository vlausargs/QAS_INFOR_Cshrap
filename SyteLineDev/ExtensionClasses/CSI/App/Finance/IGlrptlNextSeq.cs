//PROJECT NAME: Finance
//CLASS NAME: IGlrptlNextSeq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IGlrptlNextSeq
	{
		(int? ReturnCode, int? NextSeq,
		string PromptMsg,
		string Infobar) GlrptlNextSeqSp(string RptId,
		int? CurSeq,
		int? NextSeq,
		string PromptMsg,
		string Infobar);
	}
}

