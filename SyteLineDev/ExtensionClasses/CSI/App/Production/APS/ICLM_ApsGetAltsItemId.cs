//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetAltsItemId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetAltsItemId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetAltsItemIdSp(int? AltNo1,
		int? AltNo2,
		string ItemFilter = null);
	}
}

