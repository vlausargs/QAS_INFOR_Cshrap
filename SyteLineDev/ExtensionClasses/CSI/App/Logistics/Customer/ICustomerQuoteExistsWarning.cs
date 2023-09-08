//PROJECT NAME: Logistics
//CLASS NAME: ICustomerQuoteExistsWarning.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerQuoteExistsWarning
	{
		(int? ReturnCode,
		string Infobar) CustomerQuoteExistsWarningSp(
			string CoNum,
			string CustQuote,
			string CustNum,
			string ProspectId,
			string Infobar);
	}
}

