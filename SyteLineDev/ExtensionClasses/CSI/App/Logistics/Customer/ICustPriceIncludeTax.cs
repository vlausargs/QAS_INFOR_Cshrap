//PROJECT NAME: Logistics
//CLASS NAME: ICustPriceIncludeTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.Customer
{
	public interface ICustPriceIncludeTax
	{
		(int? ReturnCode, int? CustIncludePrice) CustPriceIncludeTaxSp(string CustNum,
		int? CustSeq,
		int? CustIncludePrice,
		string PSite = null);
	}
}

