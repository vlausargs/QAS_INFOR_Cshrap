//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_PopulateBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_PopulateBOM
	{
		(int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateBOMSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg);
	}
}

