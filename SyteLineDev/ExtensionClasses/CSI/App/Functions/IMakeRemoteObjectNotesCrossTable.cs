//PROJECT NAME: Data
//CLASS NAME: IMakeRemoteObjectNotesCrossTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IMakeRemoteObjectNotesCrossTable
	{
		(int? ReturnCode,
			string Infobar) MakeRemoteObjectNotesCrossTableSp(
			string FromSite,
			string TableName,
			string ToWhereClause,
			string ToJoinClause,
			Guid? ToRowPointer,
			string TypeOfNote,
			decimal? FromToken,
			int? NoteType,
			int? NoteFlag,
			string Infobar,
			decimal? ToNoteToken);
	}
}

