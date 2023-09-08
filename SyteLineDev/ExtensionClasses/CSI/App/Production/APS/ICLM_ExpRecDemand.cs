//PROJECT NAME: Production
//CLASS NAME: ICLM_ExpRecDemand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ExpRecDemand
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExpRecDemandSp(int? Pos,
		string DemandType,
		string DemandNum = null,
		int? DemandLineSuf = 0);
	}
}

