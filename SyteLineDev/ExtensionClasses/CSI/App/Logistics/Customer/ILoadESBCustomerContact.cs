//PROJECT NAME: Logistics
//CLASS NAME: ILoadESBCustomerContact.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ILoadESBCustomerContact
	{
		(int? ReturnCode, string Infobar) LoadESBCustomerContactSp(string CustNum,
		string Infobar);
	}
}

