//PROJECT NAME: Data
//CLASS NAME: ICopyObjectNotesBulk.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface ICopyObjectNotesBulk
	{
		int? CopyObjectNotesBulkSp(
			decimal? FromNoteHeaderToken,
			decimal? ToNoteHeaderToken);
	}
}

