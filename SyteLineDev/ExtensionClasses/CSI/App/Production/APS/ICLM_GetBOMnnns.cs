//PROJECT NAME: Production
//CLASS NAME: ICLM_GetBOMnnns.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_GetBOMnnns
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetBOMnnnsSp(
			string MATERIALID = null,
			int? AltNum = 0,
			string FilterString = null);
	}
}

