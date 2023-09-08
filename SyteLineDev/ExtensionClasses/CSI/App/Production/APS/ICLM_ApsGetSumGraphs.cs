//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSumGraphs.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSumGraphs
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSumGraphsSp(int? AltNo);
	}
}

