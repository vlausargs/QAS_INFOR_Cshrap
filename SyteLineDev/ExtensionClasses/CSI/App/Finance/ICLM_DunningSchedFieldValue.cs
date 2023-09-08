//PROJECT NAME: Finance
//CLASS NAME: ICLM_DunningSchedFieldValue.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_DunningSchedFieldValue
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_DunningSchedFieldValueSp(string DunningGroup = null,
		int? StageId = null);
	}
}

