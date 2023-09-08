//PROJECT NAME: Data
//CLASS NAME: ICustomerSpecificUnitPriceExists.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Codes
{
	public interface ICustomerSpecificUnitPriceExists
	{
		int? CustomerSpecificUnitPriceExistsFn(
			string CustNum,
			string Item,
			string CurrCode);
	}
}

