//PROJECT NAME: Finance
//CLASS NAME: IBankBal.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IBankBal
	{
		(int? ReturnCode, string Infobar) BankBalSp(string BankCode,
		string Infobar);
	}
}

