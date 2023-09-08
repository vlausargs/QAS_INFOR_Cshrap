//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetWait.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetWait
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetWaitSp(string PSite,
		string POrder,
		int? AltNo);
	}
}

