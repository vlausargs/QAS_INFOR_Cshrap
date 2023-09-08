//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_PopulateRefDesignators.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_PopulateRefDesignators
	{
		(int? ReturnCode,
			int? Error,
			string ErrorMsg) BOMBulkImport_PopulateRefDesignatorsSp(
			string xmlFileName,
			int? Error,
			string ErrorMsg);
	}
}

