//PROJECT NAME: Logistics
//CLASS NAME: ICLM_GetCOLinesmobi.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICLM_GetCOLinesmobi
	{
		(ICollectionLoadResponse Data, int? ReturnCode) CLM_GetCOLinesmobiSp(string CoNum,
		string SiteRef,
		string FilterString = null);
	}
}

