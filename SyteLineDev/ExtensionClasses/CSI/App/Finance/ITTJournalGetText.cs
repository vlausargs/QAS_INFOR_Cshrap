//PROJECT NAME: Finance
//CLASS NAME: ITTJournalGetText.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ITTJournalGetText
	{
		(int? ReturnCode, string ROutOfRange,
		string RToPost,
		string RToPrint,
		string RPosted,
		string REmpty,
		string Infobar) TTJournalGetTextSp(string ROutOfRange,
		string RToPost,
		string RToPrint,
		string RPosted,
		string REmpty,
		string Infobar);
	}
}

