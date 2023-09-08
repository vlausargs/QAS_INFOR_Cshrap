//PROJECT NAME: Production
//CLASS NAME: ICLM_GetJobDemandId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICLM_GetJobDemandId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetJobDemandIdSp(string PDemandType,
		string DemandIDFilter = null);
	}
}

