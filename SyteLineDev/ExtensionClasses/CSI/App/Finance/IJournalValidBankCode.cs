//PROJECT NAME: Finance
//CLASS NAME: IJournalValidBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalValidBankCode
	{
		(int? ReturnCode, string PCurrCode,
		string Infobar) JournalValidBankCodeSp(string PBankCode,
		string PAcct,
		string PCurrCode,
		string Infobar,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null);
	}
}

