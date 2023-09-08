//PROJECT NAME: Material
//CLASS NAME: IItemExtraInit.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemExtraInit
	{
		(int? ReturnCode, string LotPrefix,
		int? LotTracked,
		string IssueBy,
		int? SerialTracked,
		string SerialPrefix,
		string CostType,
		int? PreassignLots,
		int? PreassignSerials) ItemExtraInitSp(string LotPrefix,
		int? LotTracked,
		string IssueBy,
		int? SerialTracked,
		string SerialPrefix,
		string CostType,
		string PSite,
		int? PreassignLots,
		int? PreassignSerials);
	}
}

