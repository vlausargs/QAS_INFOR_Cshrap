//PROJECT NAME: Production
//CLASS NAME: ICLM_APSOrderList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_APSOrderList
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_APSOrderListSp(
			int? AltNo,
			string MsgOrderFilter = null);
	}
}

