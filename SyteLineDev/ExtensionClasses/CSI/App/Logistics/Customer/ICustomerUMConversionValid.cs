//PROJECT NAME: Logistics
//CLASS NAME: ICustomerUMConversionValid.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustomerUMConversionValid
	{
		(int? ReturnCode, string Infobar) CustomerUMConversionValidSp(string ItemUM,
		string CustUM,
		string Infobar);
	}
}

