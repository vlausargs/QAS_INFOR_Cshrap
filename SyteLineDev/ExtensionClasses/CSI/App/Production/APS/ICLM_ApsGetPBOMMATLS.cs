//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetPBOMMATLS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetPBOMMATLS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetPBOMMATLSSp(int? AltNo,
		string BOMID,
		int? ALTID,
		string FilterString = null);
	}
}

