//PROJECT NAME: Material
//CLASS NAME: IGetCostItemAtWhse.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IGetCostItemAtWhse
	{
		(int? ReturnCode, int? CostItemAtWhse) GetCostItemAtWhseSP(int? CostItemAtWhse);
	}
}

