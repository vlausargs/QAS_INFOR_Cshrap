//PROJECT NAME: Data
//CLASS NAME: ISSSGetNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ISSSGetNotes
	{
		string SSSGetNotesFn(
			Guid? RowPointer);
	}
}

