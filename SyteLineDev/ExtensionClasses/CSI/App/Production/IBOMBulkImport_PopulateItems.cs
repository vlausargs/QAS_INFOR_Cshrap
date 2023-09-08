//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_PopulateItems.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_PopulateItems
	{
		(int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateItemsSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg);
	}
}

