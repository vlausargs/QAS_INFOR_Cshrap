//PROJECT NAME: Material
//CLASS NAME: IItemPreDisplay.cs

using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.SQL.UDDT;

namespace CSI.Material
{
	public interface IItemPreDisplay
	{
		(int? ReturnCode, int? CanUpdateRevTrack,
		string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		int? use_wholesale_price,
		int? use_backflush,
		string ConfigServerId,
		string ConfigHeaderNameSpace,
		string Configurator,
		string ConfiguratorURL,
		string ConfigDeploymentPath,
		int? AvailCfg,
		int? AllowFcstBomSupplyItems,
		string Infobar,
		int? CostItemAtWhse,
		string LinearDimensionUM,
		string DensityUM,
		string AreaUM,
		string BulkMassUM,
		string ReamMassUM,
		string LotPrefix,
		int? LotTracked,
		string IssueBy,
		int? SerialTracked,
		string SerialPrefix,
		string CostType,
		int? PreassignLots,
		int? PreassignSerials) ItemPreDisplaySp(int? CanUpdateRevTrack,
		string ApsParmApsmode,
		int? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		int? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		int? use_wholesale_price,
		int? use_backflush,
		string ConfigServerId,
		string ConfigHeaderNameSpace,
		string Configurator,
		string ConfiguratorURL,
		string ConfigDeploymentPath,
		int? AvailCfg,
		int? AllowFcstBomSupplyItems,
		string Infobar,
		string PSite = null,
		int? CostItemAtWhse = null,
		string LinearDimensionUM = null,
		string DensityUM = null,
		string AreaUM = null,
		string BulkMassUM = null,
		string ReamMassUM = null,
		string LotPrefix = null,
		int? LotTracked = null,
		string IssueBy = null,
		int? SerialTracked = null,
		string SerialPrefix = null,
		string CostType = null,
		int? PreassignLots = null,
		int? PreassignSerials = null);
	}
}

