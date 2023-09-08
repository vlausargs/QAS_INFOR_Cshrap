//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLPPS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetMATLPPS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetMATLPPSSp(int? AltNo,
		string MatID = null,
		string Filter = null);
	}
}

