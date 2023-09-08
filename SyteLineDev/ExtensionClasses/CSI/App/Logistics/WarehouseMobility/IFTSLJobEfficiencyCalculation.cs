//PROJECT NAME: Logistics
//CLASS NAME: IFTSLJobEfficiencyCalculation.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Logistics.WarehouseMobility
{
	public interface IFTSLJobEfficiencyCalculation
	{
		(int? ReturnCode, int? Color) FTSLJobEfficiencyCalculationSp(string Job,
		int? Suffix,
		int? Operation,
		DateTime? CurrDate,
		int? RefreshInterval,
		decimal? HighEfficiencyLevel,
		decimal? MediumEfficiencyLevel,
		DateTime? StartTime,
		int? Color);
	}
}

