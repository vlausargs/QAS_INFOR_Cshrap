//PROJECT NAME: Logistics
//CLASS NAME: ISSSRMXValAcct.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ISSSRMXValAcct
	{
		(int? ReturnCode,
			string Infobar) SSSRMXValAcctSp(
			string Acct,
			string Infobar);
	}
}

