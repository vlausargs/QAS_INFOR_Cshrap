//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLATTR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetMATLATTR
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetMATLATTRSp(int? AltNo,
		string MatID = null,
		string Filter = null);
	}
}

