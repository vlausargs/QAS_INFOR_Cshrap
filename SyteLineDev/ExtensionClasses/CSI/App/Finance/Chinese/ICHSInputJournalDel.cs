//PROJECT NAME: Finance
//CLASS NAME: ICHSInputJournalDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance.Chinese
{
	public interface ICHSInputJournalDel
	{
		(int? ReturnCode,
		string Infobar) CHSInputJournalDelSp(
			Guid? SessionId,
			string Infobar);
	}
}

