//PROJECT NAME: Reporting
//CLASS NAME: IRpt_BulkPickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_BulkPickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_BulkPickListSp(
			string ProcessId,
			string pSite = null);
	}
}

