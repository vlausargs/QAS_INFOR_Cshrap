//PROJECT NAME: Data
//CLASS NAME: IStatBalI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IStatBalI
	{
		(int? ReturnCode,
			decimal? Balance,
			string Infobar) StatBalISp(
			string PType,
			DateTime? SDate,
			DateTime? EDate,
			string PAcct,
			string PAcctUnit1,
			string PAcctUnit2,
			string PAcctUnit3,
			string PAcctUnit4,
			string PHierarchy,
			decimal? Balance,
			string Infobar,
			string pSite = null,
			string PSort = null);
	}
}

