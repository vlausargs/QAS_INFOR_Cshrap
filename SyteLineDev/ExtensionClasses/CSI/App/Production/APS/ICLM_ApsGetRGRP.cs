//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetRGRP.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetRGRP
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsGetRGRPSp(
			int? AltNo,
			string Filter = null);
	}
}

