//PROJECT NAME: Production
//CLASS NAME: ICLM_ApsWhatIfEXRCPTItem.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ApsWhatIfEXRCPTItem
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_ApsWhatIfEXRCPTItemSp(
			int? AltNo,
			string MaterialIdFilter = null);
	}
}

