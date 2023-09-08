//PROJECT NAME: Finance
//CLASS NAME: IAcctD.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IAcctD
	{
		(int? ReturnCode, string rDescription) AcctDSp(string pAccount,
		string rDescription);
	}
}

