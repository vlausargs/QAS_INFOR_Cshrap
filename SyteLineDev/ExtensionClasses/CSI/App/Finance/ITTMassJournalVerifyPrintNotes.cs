//PROJECT NAME: Finance
//CLASS NAME: ITTMassJournalVerifyPrintNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTMassJournalVerifyPrintNotes
	{
		(int? ReturnCode, int? CompleteFlag,
		string Infobar) TTMassJournalVerifyPrintNotesSp(string PSessionID,
		int? CompleteFlag,
		string Infobar);
	}
}

