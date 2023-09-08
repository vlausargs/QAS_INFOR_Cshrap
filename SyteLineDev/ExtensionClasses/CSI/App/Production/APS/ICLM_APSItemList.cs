//PROJECT NAME: Production
//CLASS NAME: ICLM_APSItemList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production.APS
{
	public interface ICLM_APSItemList
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) CLM_APSItemListSp(
			int? AltNo,
			string ItemFilter = null);
	}
}

