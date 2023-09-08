//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_PopulateItemManufacturerData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_PopulateItemManufacturerData
	{
		(int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateItemManufacturerDataSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg);
	}
}

