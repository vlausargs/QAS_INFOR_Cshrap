//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_ProcessSQLCommands.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_ProcessSQLCommands
	{
		(int? ReturnCode,
			string Infobar) BOMBulkImport_ProcessSQLCommandsSp(
			string Infobar);
	}
}

