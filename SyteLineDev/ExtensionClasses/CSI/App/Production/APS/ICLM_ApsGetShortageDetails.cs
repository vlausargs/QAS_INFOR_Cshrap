//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetShortageDetails.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetShortageDetails
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetShortageDetailsSp(int? Matltag,
		int? AltNo,
		string FilterString = null);
	}
}

