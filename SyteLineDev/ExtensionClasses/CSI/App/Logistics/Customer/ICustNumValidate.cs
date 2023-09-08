//PROJECT NAME: Logistics
//CLASS NAME: ICustNumValidate.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustNumValidate
	{
		(int? ReturnCode, string Infobar) CustNumValidateSp(string CustNum,
			string BankRouting,
			string BankAccount,
			string Infobar);
	}
}

