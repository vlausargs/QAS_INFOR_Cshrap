//PROJECT NAME: Finance
//CLASS NAME: IJournalNoTableLockJob.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IJournalNoTableLockJob
	{
		(int? ReturnCode, string Infobar) JournalNoTableLockJobSp(string Infobar);
	}
}

