//PROJECT NAME: Material
//CLASS NAME: ICLM_TransactionDetailMatTran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_TransactionDetailMatTran
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TransactionDetailMatTranSp(decimal? PMatlTransNum,
		string PSite,
		string PRefNum = null);
	}
}

