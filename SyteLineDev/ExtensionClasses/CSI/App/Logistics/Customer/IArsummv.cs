//PROJECT NAME: Logistics
//CLASS NAME: IArsummv.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IArsummv
	{
		(ICollectionLoadResponse Data, int? ReturnCode) ArsummvSp(string PCustNum,
		int? PCurrentSite,
		int? PSubordinate,
		int? PActive,
		string ArsummFilter,
		string SiteGroup = null,
		string CustaddrCurrCode = null,
		string Salesperson = null,
		int? IncludeDirectReports = null);
	}
}

