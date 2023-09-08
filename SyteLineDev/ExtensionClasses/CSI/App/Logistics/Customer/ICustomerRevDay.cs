//PROJECT NAME: Logistics
//CLASS NAME: ICustomerRevDay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerRevDay
	{
		(int? ReturnCode, int? RevDayExist,
		string Infobar) CustomerRevDaySp(string CustNum,
		int? RevDayExist,
		string Infobar);
	}
}

