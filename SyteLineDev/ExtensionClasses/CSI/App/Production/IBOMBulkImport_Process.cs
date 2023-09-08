//PROJECT NAME: Production
//CLASS NAME: IBOMBulkImport_Process.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IBOMBulkImport_Process
	{
		int? BOMBulkImport_ProcessSp(string xmlFileName,
		string xmlData);
	}
}

