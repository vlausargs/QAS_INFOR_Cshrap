//PROJECT NAME: Production
//CLASS NAME: ICLM_GetMATLPPSnnns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_GetMATLPPSnnns
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetMATLPPSnnnsSp(string MATERIALID = null,
		int? AltNum = 0,
		string FilterString = null);
	}
}

