//PROJECT NAME: Production
//CLASS NAME: IApsSyncBatchProdJS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncBatchProdJS
	{
		int? ApsSyncBatchProdJSSp(
			Guid? Partition);
	}
}

