//PROJECT NAME: Data
//CLASS NAME: ICopyObjectNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyObjectNotes
	{
		int? CopyObjectNotesSp(
			decimal? FromNoteHeaderToken,
			Guid? FromRowPointer,
			decimal? ToNoteHeaderToken,
			Guid? ToRowPointer,
			string ToObject);
	}
}

