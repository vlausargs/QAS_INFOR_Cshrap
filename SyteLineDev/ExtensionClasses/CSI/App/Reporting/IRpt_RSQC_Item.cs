//PROJECT NAME: Reporting
//CLASS NAME: IRpt_RSQC_Item.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_RSQC_Item
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_RSQC_ItemSp(string ItemStarting = null,
		string ItemEnding = null,
		int? PrintInternal = null,
		int? PrintExternal = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

