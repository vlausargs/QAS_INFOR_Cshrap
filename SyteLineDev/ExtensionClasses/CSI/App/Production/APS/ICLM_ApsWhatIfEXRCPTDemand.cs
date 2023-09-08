//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsWhatIfEXRCPTDemand.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsWhatIfEXRCPTDemand
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsWhatIfEXRCPTDemandSp(
			int? AltNo,
			string OrderIdFilter = null);
	}
}

