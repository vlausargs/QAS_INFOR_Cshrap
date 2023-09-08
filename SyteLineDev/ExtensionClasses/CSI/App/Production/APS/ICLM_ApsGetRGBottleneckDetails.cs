//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetRGBottleneckDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRGBottleneckDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetRGBottleneckDetailsSp(string Group,
		DateTime? StartDate,
		DateTime? EndDate,
		int? AltNo,
		string FilterString = null);
	}
}

