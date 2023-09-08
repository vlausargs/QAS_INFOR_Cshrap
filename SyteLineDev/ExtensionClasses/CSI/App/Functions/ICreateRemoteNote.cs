//PROJECT NAME: Data
//CLASS NAME: ICreateRemoteNote.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICreateRemoteNote
	{
		(int? ReturnCode,
			string Infobar) CreateRemoteNoteSp(
			string TableName,
			Guid? RowPointer,
			string ReportNotesViewDescription,
			string ReportNotesViewNote,
			int? ReportNotesViewIsInternalNote,
			string Infobar);
	}
}

