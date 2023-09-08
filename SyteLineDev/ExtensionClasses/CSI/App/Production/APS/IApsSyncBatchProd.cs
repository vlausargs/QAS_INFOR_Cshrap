//PROJECT NAME: Production
//CLASS NAME: IApsSyncBatchProd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface IApsSyncBatchProd
	{
		int? ApsSyncBatchProdSp(
			Guid? Partition);
	}
}

