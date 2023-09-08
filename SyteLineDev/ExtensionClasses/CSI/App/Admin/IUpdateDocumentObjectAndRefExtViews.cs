//PROJECT NAME: Admin
//CLASS NAME: IUpdateDocumentObjectAndRefExtViews.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Admin
{
	public interface IUpdateDocumentObjectAndRefExtViews
	{
		(int? ReturnCode, Guid? DocumentObjectRowPointer,
		string Infobar) UpdateDocumentObjectAndRefExtViewsSp(string TableName,
		Guid? TableRowPointer,
		decimal? RefSequence,
		Guid? DocumentObjectRowPointer,
		Guid? RowPointer,
		string DocumentName,
		decimal? Sequence,
		string Description,
		string DocumentType,
		string DocumentExtension,
		int? Internal,
		string Revision,
		string Status,
		DateTime? effective_start_date,
		DateTime? effective_end_date,
		int? is_external,
		byte[] DocumentObject = null,
		string Infobar = null);
	}
}

