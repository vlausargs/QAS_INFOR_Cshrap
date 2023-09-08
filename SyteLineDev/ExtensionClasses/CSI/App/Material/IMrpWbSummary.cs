//PROJECT NAME: Material
//CLASS NAME: IMrpWbSummary.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IMrpWbSummary
	{
		(int? ReturnCode, decimal? PoCostWb,
		decimal? PrCostWb,
		decimal? JobCostWb,
		decimal? PsCostWb,
		decimal? MpsCostWb,
		decimal? ToCostWb,
		decimal? TotalCostWb,
		decimal? PoCostSelected,
		decimal? PrCostSelected,
		decimal? JobCostSelected,
		decimal? PsCostSelected,
		decimal? MpsCostSelected,
		decimal? ToCostSelected,
		decimal? TotalCostSelected,
		int? PoOrders,
		int? JobOrders,
		int? PsOrders,
		int? MpsOrders,
		int? ToOrders,
		int? PoLines,
		int? PrLines,
		int? PsLines,
		int? MpsLines,
		int? ToLines) MrpWbSummarySp(decimal? UserId,
		decimal? PoCostWb,
		decimal? PrCostWb,
		decimal? JobCostWb,
		decimal? PsCostWb,
		decimal? MpsCostWb,
		decimal? ToCostWb,
		decimal? TotalCostWb,
		decimal? PoCostSelected,
		decimal? PrCostSelected,
		decimal? JobCostSelected,
		decimal? PsCostSelected,
		decimal? MpsCostSelected,
		decimal? ToCostSelected,
		decimal? TotalCostSelected,
		int? PoOrders,
		int? JobOrders,
		int? PsOrders,
		int? MpsOrders,
		int? ToOrders,
		int? PoLines,
		int? PrLines,
		int? PsLines,
		int? MpsLines,
		int? ToLines);
	}
}

