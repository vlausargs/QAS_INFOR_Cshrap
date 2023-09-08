//PROJECT NAME: Data
//CLASS NAME: IVendCostIncludeTax.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IVendCostIncludeTax
	{
		(int? ReturnCode,
			int? POIncludeCost) VendCostIncludeTaxSp(
			string VendNum,
			int? POIncludeCost);
	}
}

