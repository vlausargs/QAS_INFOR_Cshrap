//PROJECT NAME: Production
//CLASS NAME: ICurrentMaterialsItemChg.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Production
{
	public interface ICurrentMaterialsItemChg
	{
		(int? ReturnCode, int? BomSeq,
		int? DerMatlExist,
		decimal? DerUOMConvFactor,
		int? MatlSerialTracked,
		int? MatlLotTracked,
		string Description,
		string MatlType,
		string Units,
		string MatlStat,
		string UM,
		string DerUM,
		string MatlUM,
		int? MatlLowLevel,
		int? Backflush,
		string BflushLoc,
		string RefType,
		int? PhantomFlag,
		int? DerBflushLocRequired,
		decimal? Cost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? CostConv,
		decimal? MatlCostConv,
		decimal? LbrCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Fmatlovhd,
		decimal? Vmatlovhd,
		int? Kit,
		int? PreassignLots,
		string LotPrefix,
		string Infobar,
		int? MOShared,
		decimal? MOSecondsPerCycle,
		decimal? MOFormulaMatlWeight,
		string MOFormulaMatlWeightUnits,
		string Revision) CurrentMaterialsItemChgSp(string Item,
		string WC,
		int? LocalNegFlag,
		string Job,
		int? Suffix,
		Guid? JobmatlRowPointer,
		int? BomSeq,
		int? DerMatlExist,
		decimal? DerUOMConvFactor,
		int? MatlSerialTracked,
		int? MatlLotTracked,
		string Description,
		string MatlType,
		string Units,
		string MatlStat,
		string UM,
		string DerUM,
		string MatlUM,
		int? MatlLowLevel,
		int? Backflush,
		string BflushLoc,
		string RefType,
		int? PhantomFlag,
		int? DerBflushLocRequired,
		decimal? Cost,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? CostConv,
		decimal? MatlCostConv,
		decimal? LbrCostConv,
		decimal? FovhdCostConv,
		decimal? VovhdCostConv,
		decimal? OutCostConv,
		decimal? Fmatlovhd,
		decimal? Vmatlovhd,
		int? Kit,
		int? PreassignLots,
		string LotPrefix,
		string Infobar,
		int? OperNum = null,
		int? MOShared = null,
		decimal? MOSecondsPerCycle = null,
		decimal? MOFormulaMatlWeight = null,
		string MOFormulaMatlWeightUnits = null,
		string Revision = null);
	}
}

