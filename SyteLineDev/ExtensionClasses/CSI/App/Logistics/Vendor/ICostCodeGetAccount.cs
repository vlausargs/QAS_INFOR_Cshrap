//PROJECT NAME: Logistics
//CLASS NAME: ICostCodeGetAccount.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Vendor
{
	public interface ICostCodeGetAccount
	{
		(int? ReturnCode, string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string Description,
		int? IsControlAcct) CostCodeGetAccountSp(string CostCode,
		string ProjNum,
		string Acct,
		string AcctUnit1,
		string AcctUnit2,
		string AcctUnit3,
		string AcctUnit4,
		string Description,
		int? IsControlAcct);
	}
}

