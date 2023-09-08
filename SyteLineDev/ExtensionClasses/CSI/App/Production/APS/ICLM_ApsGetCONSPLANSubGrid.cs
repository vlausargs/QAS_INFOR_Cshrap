//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetCONSPLANSubGrid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetCONSPLANSubGrid
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetCONSPLANSubGridSp(int? AltNo,
		int? MatlTag,
		string FilterString);
	}
}

