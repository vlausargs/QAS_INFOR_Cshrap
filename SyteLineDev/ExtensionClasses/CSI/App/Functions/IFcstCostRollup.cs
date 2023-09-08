//PROJECT NAME: Data
//CLASS NAME: IFcstCostRollup.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Functions
{
	public interface IFcstCostRollup
	{
		(int? ReturnCode,
			string Infobar) FcstCostRollupSp(
			string ProjNum,
			int? TaskNum,
			string CostCode,
			decimal? CostChange,
			DateTime? DueDate,
			string Infobar);
	}
}

