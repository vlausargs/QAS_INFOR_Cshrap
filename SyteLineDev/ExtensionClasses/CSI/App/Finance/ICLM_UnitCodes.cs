//PROJECT NAME: Finance
//CLASS NAME: ICLM_UnitCodes.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Finance
{
	public interface ICLM_UnitCodes
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_UnitCodesSp(int? UnitCodeNumber);
	}
}

