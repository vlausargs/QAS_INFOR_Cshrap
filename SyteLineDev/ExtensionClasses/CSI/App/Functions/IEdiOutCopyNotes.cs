//PROJECT NAME: Data
//CLASS NAME: IEdiOutCopyNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IEdiOutCopyNotes
	{
		int? EdiOutCopyNotesSp(
			string FromObject,
			Guid? FromRowPointer);
	}
}

