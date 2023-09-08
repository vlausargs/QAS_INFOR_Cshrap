//PROJECT NAME: Logistics
//CLASS NAME: IHomepage_CustomerProductCodeBacklog.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IHomepage_CustomerProductCodeBacklog
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) Homepage_CustomerProductCodeBacklogSp(
			string CustNum = null,
			string ProductCode = null,
			string SiteRef = null,
			string FilterString = null);
	}
}

