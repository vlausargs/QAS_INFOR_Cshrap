//PROJECT NAME: Data
//CLASS NAME: IAPP_IsAppHandledNotesTable.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IAPP_IsAppHandledNotesTable
	{
		(int? ReturnCode,
			int? IsAppHandled) APP_IsAppHandledNotesTableSp(
			string TableName,
			int? IsAppHandled);
	}
}

