//PROJECT NAME: Data
//CLASS NAME: ICustomerValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerValid
	{
		(int? ReturnCode,
			string Infobar) CustomerValidSp(
			string CustNum,
			string Infobar);
	}
}

