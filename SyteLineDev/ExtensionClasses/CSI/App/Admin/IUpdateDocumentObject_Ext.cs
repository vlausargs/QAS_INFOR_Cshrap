//PROJECT NAME: Admin
//CLASS NAME: IUpdateDocumentObject_Ext.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IUpdateDocumentObject_Ext
	{
		(int? ReturnCode, string Infobar) UpdateDocumentObject_ExtSp(string DocumentName,
		decimal? Sequence,
		string Description,
		string DocumentType,
		string DocumentExtension,
		int? Internal,
		Guid? DocumentObjectRowPointer,
		string Revision,
		string Status,
		DateTime? effective_start_date,
		DateTime? effective_end_date,
		int? is_external,
		string Infobar);
	}
}

