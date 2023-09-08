//PROJECT NAME: Production
//CLASS NAME: ICLM_GetPPBatchedOperationType.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_GetPPBatchedOperationType
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_GetPPBatchedOperationTypeSp(
			int? BatchId,
			string BatchDefinition);
	}
}

