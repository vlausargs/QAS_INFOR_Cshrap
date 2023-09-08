//PROJECT NAME: Finance
//CLASS NAME: IReturnedChecks.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IReturnedChecks
	{
		(int? ReturnCode, string Infobar) ReturnedChecksSp(string pBankCode,
		string pProcess,
		int? pProcessReturnedCheck,
		int? pProcessReturnedCheckDeposit,
		string Infobar);
	}
}

