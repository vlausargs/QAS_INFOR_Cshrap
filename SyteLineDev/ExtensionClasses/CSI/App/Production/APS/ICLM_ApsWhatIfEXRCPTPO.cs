//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsWhatIfEXRCPTPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsWhatIfEXRCPTPO
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsWhatIfEXRCPTPOSp(
			int? AltNo,
			string MATERIALID,
			string OrderIdFilter = null);
	}
}

