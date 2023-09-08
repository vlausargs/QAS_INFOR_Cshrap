//PROJECT NAME: Codes
//CLASS NAME: ICustomerPortalCreateCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICustomerPortalCreateCustomer
	{
		(int? ReturnCode, string CustNum,
		string Infobar) CustomerPortalCreateCustomerSp(string Username,
		string Name,
		string Email,
		string Password,
		string RetypePassword,
		string ResellerSlsman,
		string OrderCurrency,
		string CompanyName,
		int? LocaleId,
		string CustNum,
		string PrimarySite,
		string Infobar);
	}
}

