//PROJECT NAME: Finance
//CLASS NAME: IMultiFSBTTLedgerPost.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IMultiFSBTTLedgerPost
	{
		(int? ReturnCode,
			string Infobar) MultiFSBTTLedgerPostSp(
			string FSBName,
			string Infobar);
	}
}

