//PROJECT NAME: Logistics
//CLASS NAME: ICohShipSiteDel.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICohShipSiteDel
	{
		int? CohShipSiteDelSp(
			string pOrigSite,
			string pCONum);
	}
}

