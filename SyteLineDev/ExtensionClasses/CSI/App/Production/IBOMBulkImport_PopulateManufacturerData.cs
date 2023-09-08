//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_PopulateManufacturerData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_PopulateManufacturerData
	{
		(int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateManufacturerDataSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg);
	}
}

