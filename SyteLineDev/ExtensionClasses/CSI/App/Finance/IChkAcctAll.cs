//PROJECT NAME: Finance
//CLASS NAME: IChkAcctAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IChkAcctAll
	{
		(int? ReturnCode, string Infobar) ChkAcctAllSp(string acct,
		DateTime? date,
		string pSite,
		string Infobar);
	}
}

