//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PickList.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PickList
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PickListSp(string ProcessId,
		string pSite = null);
	}
}

