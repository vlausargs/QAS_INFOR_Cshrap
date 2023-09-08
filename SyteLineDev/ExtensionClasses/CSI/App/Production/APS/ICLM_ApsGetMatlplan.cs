//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMatlplan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetMatlplan
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetMatlplanSp(string PSite,
		string POrder,
		int? AltNo);
	}
}

