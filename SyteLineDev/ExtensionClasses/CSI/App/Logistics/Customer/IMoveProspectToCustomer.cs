//PROJECT NAME: Logistics
//CLASS NAME: IMoveProspectToCustomer.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IMoveProspectToCustomer
	{
		(int? ReturnCode, string OutCustNum,
		string Infobar) MoveProspectToCustomerSp(string ProspectId,
		string NewCustNum,
		string BankCode,
		string OutCustNum,
		string Infobar);
	}
}

