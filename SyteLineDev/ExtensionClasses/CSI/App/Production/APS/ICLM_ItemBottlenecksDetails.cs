//PROJECT NAME: Production
//CLASS NAME: ICLM_ItemBottlenecksDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ItemBottlenecksDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ItemBottlenecksDetailsSp(string Item = null,
		int? ALTNO = null);
	}
}

