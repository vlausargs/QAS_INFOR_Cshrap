//PROJECT NAME: Production
//CLASS NAME: ICopyNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICopyNotes
	{
		int? CopyNotesSp(string FromObject,
		Guid? FromRowPointer,
		string ToObject,
		Guid? ToRowPointer);
	}
}

