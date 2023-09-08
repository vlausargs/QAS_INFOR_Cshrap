//PROJECT NAME: Finance
//CLASS NAME: IFinRptXMLBufCopyNotes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface IFinRptXMLBufCopyNotes
	{
		(int? ReturnCode,
			string Infobar) FinRptXMLBufCopyNotesSp(
			string FromSite,
			string TableName,
			Guid? FromRowPointer,
			Guid? ToRowPointer,
			string Infobar);
	}
}

