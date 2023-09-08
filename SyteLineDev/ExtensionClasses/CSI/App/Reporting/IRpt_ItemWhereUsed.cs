//PROJECT NAME: Reporting
//CLASS NAME: IRpt_ItemWhereUsed.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_ItemWhereUsed
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_ItemWhereUsedSp(string StartingItem = null,
		string EndingItem = null,
		string StartingProductCode = null,
		string EndingProductCode = null,
		string IStat = null,
		string MatlType = null,
		string PMTCode = null,
		string pStocked = null,
		string ABCCode = null,
		int? PageBetweenItems = null,
		int? DisplayHeader = 1,
		string pSite = null,
		string BGUser = null);
	}
}

