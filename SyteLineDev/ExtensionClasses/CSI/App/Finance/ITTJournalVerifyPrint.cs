//PROJECT NAME: Finance
//CLASS NAME: ITTJournalVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalVerifyPrint
	{
		(int? ReturnCode, Guid? PSessionID,
		string Infobar) TTJournalVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

