//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_LoadXMLData.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_LoadXMLData
	{
		int? BOMBulkImport_LoadXMLDataSp(
			string xmlFileName,
			string xmlData);
	}
}

