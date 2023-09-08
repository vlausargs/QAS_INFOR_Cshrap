//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetItemId.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetItemId
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetItemIdSp(int? AltNo,
		string MaterialIdFilter = null);
	}
}

