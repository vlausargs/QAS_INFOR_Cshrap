//PROJECT NAME: Finance
//CLASS NAME: ICLM_FixedAssetDetailTran.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_FixedAssetDetailTran
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_FixedAssetDetailTranSp(string Ref = null);
	}
}

