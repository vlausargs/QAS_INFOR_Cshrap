//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetMATLPBOMS.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetMATLPBOMS
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetMATLPBOMSSp(int? AltNo,
		string MatID = null,
		string Filter = null);
	}
}

