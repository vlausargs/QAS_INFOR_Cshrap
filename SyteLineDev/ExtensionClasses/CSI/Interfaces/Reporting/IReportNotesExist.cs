//PROJECT NAME: App.Reporting
//CLASS NAME: IReportNotesExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IReportNotesExist
	{
		int? ReportNotesExistFn(string TableName, Guid? RowPointer, int? ShowInternal = 1, int? ShowExternal = 1, int? NoteExists = 1);
	}
}

