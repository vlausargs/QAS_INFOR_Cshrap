//PROJECT NAME: Production
//CLASS NAME: IGetBatchedProd.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface IGetBatchedProd
	{
		(int? ReturnCode, int? BatchedProdId) GetBatchedProdSp(int? BatchedProdId);
	}
}

