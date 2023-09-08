//PROJECT NAME: Logistics
//CLASS NAME: IFTSLQCSGetTestEachStatus.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLQCSGetTestEachStatus
	{
		(int? ReturnCode, int? PassStatus) FTSLQCSGetTestEachStatusSp(string RcvrNum,
		string Item,
		int? Sequence,
		decimal? ActualValue,
		int? PassStatus);
	}
}

