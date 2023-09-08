//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PurchasedComponentsCrossReference.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PurchasedComponentsCrossReference
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PurchasedComponentsCrossReferenceSp(string JobStatus = null,
		string JobType = null,
		int? PageItems = null,
		int? DisplayVendor = null,
		string ItemStarting = null,
		string ItemEnding = null,
		int? DisplayHeader = null,
		string pSite = null);
	}
}

