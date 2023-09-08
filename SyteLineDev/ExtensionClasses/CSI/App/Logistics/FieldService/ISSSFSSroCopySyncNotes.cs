//PROJECT NAME: Logistics
//CLASS NAME: ISSSFSSroCopySyncNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.FieldService
{
	public interface ISSSFSSroCopySyncNotes
	{
		(int? ReturnCode,
			string Infobar) SSSFSSroCopySyncNotesSp(
			Guid? FromRowPointer,
			string FromTableName,
			Guid? ToRowPointer,
			string ToTableName,
			int? InsertObjectNote,
			string Infobar);
	}
}

