//PROJECT NAME: Data
//CLASS NAME: IPlannedPurchasesExist.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IPlannedPurchasesExist
	{
		int? PlannedPurchasesExistFn(
			string Item,
			DateTime? EndDate);
	}
}

