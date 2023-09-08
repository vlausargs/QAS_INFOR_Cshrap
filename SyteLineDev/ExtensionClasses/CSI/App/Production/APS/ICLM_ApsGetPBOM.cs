//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetPBOM.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetPBOM
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsGetPBOMSp(
			int? AltNo,
			string Filter = null);
	}
}

