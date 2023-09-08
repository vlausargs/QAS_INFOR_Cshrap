//PROJECT NAME: Finance
//CLASS NAME: IJournalGetCashAccountBankCode.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalGetCashAccountBankCode
	{
		(int? ReturnCode, string PBankCode,
		string PCurrCode) JournalGetCashAccountBankCodeSp(string PAcct,
		string PBankCode,
		string PCurrCode,
		string AcctUnit1 = null,
		string AcctUnit2 = null,
		string AcctUnit3 = null,
		string AcctUnit4 = null);
	}
}

