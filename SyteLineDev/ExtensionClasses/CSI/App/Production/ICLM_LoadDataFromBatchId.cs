//PROJECT NAME: Production
//CLASS NAME: ICLM_LoadDataFromBatchId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_LoadDataFromBatchId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_LoadDataFromBatchIdSp(int? ProdBatchId,
		string ReturnType,
		string Loc);
	}
}

