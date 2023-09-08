//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetInvplan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetInvplan
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetInvplanSp(string PSite,
		string POrder,
		int? PFlags,
		int? AltNo);
	}
}

