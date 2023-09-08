//PROJECT NAME: Logistics
//CLASS NAME: ITableSharedSites.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ITableSharedSites
	{
		(ICollectionLoadResponse Data,
		int? ReturnCode) TableSharedSitesSp(
			string TableName);
	}
}

