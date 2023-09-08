//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_ValidateSQLCommands.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_ValidateSQLCommands
	{
		(int? ReturnCode,
			string Infobar) BOMBulkImport_ValidateSQLCommandsSp(
			string Infobar);
	}
}

