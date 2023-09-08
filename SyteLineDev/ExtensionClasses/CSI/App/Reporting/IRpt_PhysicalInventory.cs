//PROJECT NAME: Reporting
//CLASS NAME: IRpt_PhysicalInventory.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Reporting
{
	public interface IRpt_PhysicalInventory
	{
		(ICollectionLoadResponse Data, int? ReturnCode) Rpt_PhysicalInventorySp(int? PQuantityZeroOnly = 0,
		string PProductCode = null,
		string PPlannerCode = null,
		string PWhse = null,
		string PSortBy = "I",
		int? PDisplayHeader = 1,
		string pSite = null);
	}
}

