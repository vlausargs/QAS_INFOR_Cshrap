//PROJECT NAME: Finance
//CLASS NAME: ITTJournalVerifyCloseForm.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalVerifyCloseForm
	{
		(int? ReturnCode, string Infobar) TTJournalVerifyCloseFormSp(Guid? PSessionID,
		string Infobar);
	}
}

