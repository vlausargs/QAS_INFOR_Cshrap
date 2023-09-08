//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetOrdplan.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetOrdplan
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetOrdplanSp(string PSite,
		string POrder,
		int? AltNo);
	}
}

