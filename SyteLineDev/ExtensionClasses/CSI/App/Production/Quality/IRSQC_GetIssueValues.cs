//PROJECT NAME: Production
//CLASS NAME: IRSQC_GetIssueValues.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.Quality
{
	public interface IRSQC_GetIssueValues
	{
		(int? ReturnCode, string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		string Infobar) RSQC_GetIssueValuesSp(string o_acct,
		string o_account_unit1,
		string o_account_unit2,
		string o_account_unit3,
		string o_account_unit4,
		string Infobar);
	}
}

