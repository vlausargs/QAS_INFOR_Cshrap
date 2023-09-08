//PROJECT NAME: Data
//CLASS NAME: INotesDelete.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface INotesDelete
	{
		int? NotesDeleteSp(
			string Object,
			Guid? RowPointer);
	}
}

