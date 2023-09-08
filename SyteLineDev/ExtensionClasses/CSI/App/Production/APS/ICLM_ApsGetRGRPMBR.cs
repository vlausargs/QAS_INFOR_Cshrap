//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetRGRPMBR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRGRPMBR
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRGRPMBRSp(string PRgId,
		int? AltNo,
		string FilterString = null);
	}
}

