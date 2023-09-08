//PROJECT NAME: Logistics
//CLASS NAME: IGetCustomerWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface IGetCustomerWhse
	{
		(int? ReturnCode, string Whse) GetCustomerWhseSp(string CustNum,
		int? CustSeq,
		string Whse);
	}
}

