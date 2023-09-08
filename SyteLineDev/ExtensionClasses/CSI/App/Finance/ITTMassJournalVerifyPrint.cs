//PROJECT NAME: Finance
//CLASS NAME: ITTMassJournalVerifyPrint.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTMassJournalVerifyPrint
	{
		(int? ReturnCode, string Infobar) TTMassJournalVerifyPrintSp(Guid? PSessionID,
		string Infobar);
	}
}

