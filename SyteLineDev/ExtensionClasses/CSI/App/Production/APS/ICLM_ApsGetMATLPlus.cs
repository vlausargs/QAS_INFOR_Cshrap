//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLPlus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetMATLPlus
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsGetMATLPlusSp(
			int? AltNo,
			string MaterialIdFilter = null);
	}
}

