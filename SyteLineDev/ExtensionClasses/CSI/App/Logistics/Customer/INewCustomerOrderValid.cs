//PROJECT NAME: Logistics
//CLASS NAME: INewCustomerOrderValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface INewCustomerOrderValid
	{
		(int? ReturnCode, string Infobar) NewCustomerOrderValidSp(int? CoTableFlag,
		string CoNum,
		string Infobar);
	}
}

