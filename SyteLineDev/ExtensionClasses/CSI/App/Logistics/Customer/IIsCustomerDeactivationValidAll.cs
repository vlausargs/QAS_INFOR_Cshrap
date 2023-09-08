//PROJECT NAME: Logistics
//CLASS NAME: IIsCustomerDeactivationValidAll.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsCustomerDeactivationValidAll
	{
		(int? ReturnCode, string Infobar) IsCustomerDeactivationValidAllSp(string CustNum,
		int? Active = 1,
		string SiteRef = null,
		string Infobar = null);
	}
}

