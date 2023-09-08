//PROJECT NAME: Material
//CLASS NAME: ICLM_TransactionDetailMTrAmt.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface ICLM_TransactionDetailMTrAmt
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_TransactionDetailMTrAmtSp(decimal? PMatlTransNum,
		string PSite);
	}
}

