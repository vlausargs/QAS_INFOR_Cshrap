//PROJECT NAME: Production
//CLASS NAME: IRevMsSeqCheckReq.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Projects
{
	public interface IRevMsSeqCheckReq
	{
		(int? ReturnCode, string MsgPrompt,
		string MsgButtons,
		string Infobar) RevMsSeqCheckReqSp(string PProjNum,
		string PMsNum,
		int? PTaskNum,
		string MsgPrompt,
		string MsgButtons,
		string Infobar);
	}
}

