//PROJECT NAME: Finance
//CLASS NAME: IChkAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IChkAcct
	{
		(int? ReturnCode, string Infobar) ChkAcctSp(string acct,
		DateTime? date,
		string Infobar,
		string Site = null);
	}
}

