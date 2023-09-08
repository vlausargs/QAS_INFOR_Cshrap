//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsGetSHIFTEXDI.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsGetSHIFTEXDI
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ApsGetSHIFTEXDISp(int? AltNo,
		string ResID = null,
		string Filter = null);
	}
}

