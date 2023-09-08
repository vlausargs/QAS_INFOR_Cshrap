//PROJECT NAME: Logistics
//CLASS NAME: IIsCustomerActive.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IIsCustomerActive
	{
		(int? ReturnCode, string Infobar) IsCustomerActiveSp(string CustNum,
		string Infobar);
	}
}

