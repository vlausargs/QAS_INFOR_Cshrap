//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetORDATTR.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetORDATTR
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetORDATTRSp(int? AltNo,
		string OrdID = null);
	}
}

