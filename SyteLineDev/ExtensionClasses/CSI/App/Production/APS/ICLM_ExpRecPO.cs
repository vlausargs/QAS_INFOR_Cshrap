//PROJECT NAME: Production
//CLASS NAME: ICLM_ExpRecPO.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_ExpRecPO
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_ExpRecPOSp(string ItemID,
		int? Pos,
		string PONum = null,
		int? POLine = 0);
	}
}

