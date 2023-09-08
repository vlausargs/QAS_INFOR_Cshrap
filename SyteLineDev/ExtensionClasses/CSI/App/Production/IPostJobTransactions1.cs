//PROJECT NAME: Production
//CLASS NAME: IPostJobTransactions1.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IPostJobTransactions1
	{
		(int? ReturnCode, string Infobar,
		string PromptButtons) PostJobTransactions1Sp(Guid? SessionID,
		Guid? SJobtranRowPointer,
		int? PPostNeg,
		string CurWhse,
		string Infobar,
		string PromptButtons = null,
		string DocumentNum = null);
	}
}

