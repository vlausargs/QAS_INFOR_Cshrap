//PROJECT NAME: Reporting
//CLASS NAME: ILedgerConsolCommit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface ILedgerConsolCommit
	{
		(int? ReturnCode,
			string Infobar) LedgerConsolCommitSp(
			Guid? SessionID,
			string Site,
			string Infobar,
			string CopyFullSite,
			string Entity);
	}
}

