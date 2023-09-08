//PROJECT NAME: CSIMaterial
//CLASS NAME: ItemPreDisplayEntry.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public interface IItemPreDisplayEntry
	{
		(int? ReturnCode, short? CanUpdateRevTrack, string ApsParmApsmode, byte? TrackTaxFreeimports, string RUserCode, decimal? POToleranceOver, decimal? POToleranceUnder, byte? Vchrauthorize, decimal? VchrOverPoCostTolerance, decimal? VchrUnderPoCostTolerance, byte? use_wholesale_price, byte? use_backflush, string ConfigServerId, string ConfigHeaderNameSpace, string Configurator, string ConfiguratorURL, string ConfigDeploymentPath, byte? AvailCfg, byte? AllowFcstBomSupplyItems, byte? CostItemAtWhse, string LinearDimensionUM, string DensityUM, string AreaUM, string BulkMassUM, string ReamMassUM, string LotPrefix, byte? LotTracked, string IssueBy, byte? SerialTracked, string SerialPrefix, string CostType, byte? PreassignLots, byte? PreassignSerials, string Infobar) ItemPreDisplayEntrySp(short? CanUpdateRevTrack,
		string ApsParmApsmode,
		byte? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		byte? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		byte? use_wholesale_price,
		byte? use_backflush,
		string ConfigServerId,
		string ConfigHeaderNameSpace,
		string Configurator,
		string ConfiguratorURL,
		string ConfigDeploymentPath,
		byte? AvailCfg,
		byte? AllowFcstBomSupplyItems,
		byte? CostItemAtWhse,
		string LinearDimensionUM,
		string DensityUM,
		string AreaUM,
		string BulkMassUM,
		string ReamMassUM,
		string LotPrefix,
		byte? LotTracked,
		string IssueBy,
		byte? SerialTracked,
		string SerialPrefix,
		string CostType,
		byte? PreassignLots,
		byte? PreassignSerials,
		string Infobar,
		string PSite = null);
	}
	
	public class ItemPreDisplayEntry : IItemPreDisplayEntry
	{
		readonly IApplicationDB appDB;
		
		public ItemPreDisplayEntry(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, short? CanUpdateRevTrack, string ApsParmApsmode, byte? TrackTaxFreeimports, string RUserCode, decimal? POToleranceOver, decimal? POToleranceUnder, byte? Vchrauthorize, decimal? VchrOverPoCostTolerance, decimal? VchrUnderPoCostTolerance, byte? use_wholesale_price, byte? use_backflush, string ConfigServerId, string ConfigHeaderNameSpace, string Configurator, string ConfiguratorURL, string ConfigDeploymentPath, byte? AvailCfg, byte? AllowFcstBomSupplyItems, byte? CostItemAtWhse, string LinearDimensionUM, string DensityUM, string AreaUM, string BulkMassUM, string ReamMassUM, string LotPrefix, byte? LotTracked, string IssueBy, byte? SerialTracked, string SerialPrefix, string CostType, byte? PreassignLots, byte? PreassignSerials, string Infobar) ItemPreDisplayEntrySp(short? CanUpdateRevTrack,
		string ApsParmApsmode,
		byte? TrackTaxFreeimports,
		string RUserCode,
		decimal? POToleranceOver,
		decimal? POToleranceUnder,
		byte? Vchrauthorize,
		decimal? VchrOverPoCostTolerance,
		decimal? VchrUnderPoCostTolerance,
		byte? use_wholesale_price,
		byte? use_backflush,
		string ConfigServerId,
		string ConfigHeaderNameSpace,
		string Configurator,
		string ConfiguratorURL,
		string ConfigDeploymentPath,
		byte? AvailCfg,
		byte? AllowFcstBomSupplyItems,
		byte? CostItemAtWhse,
		string LinearDimensionUM,
		string DensityUM,
		string AreaUM,
		string BulkMassUM,
		string ReamMassUM,
		string LotPrefix,
		byte? LotTracked,
		string IssueBy,
		byte? SerialTracked,
		string SerialPrefix,
		string CostType,
		byte? PreassignLots,
		byte? PreassignSerials,
		string Infobar,
		string PSite = null)
		{
			PrivilegeType _CanUpdateRevTrack = CanUpdateRevTrack;
			ApsModeType _ApsParmApsmode = ApsParmApsmode;
			ListYesNoType _TrackTaxFreeimports = TrackTaxFreeimports;
			UserCodeType _RUserCode = RUserCode;
			TolerancePercentType _POToleranceOver = POToleranceOver;
			TolerancePercentType _POToleranceUnder = POToleranceUnder;
			ListYesNoType _Vchrauthorize = Vchrauthorize;
			TolerancePercentType _VchrOverPoCostTolerance = VchrOverPoCostTolerance;
			TolerancePercentType _VchrUnderPoCostTolerance = VchrUnderPoCostTolerance;
			ListYesNoType _use_wholesale_price = use_wholesale_price;
			ListYesNoType _use_backflush = use_backflush;
			ConfiguratorServerIdType _ConfigServerId = ConfigServerId;
			ConfigNameSpaceType _ConfigHeaderNameSpace = ConfigHeaderNameSpace;
			ConfiguratorType _Configurator = Configurator;
			URLType _ConfiguratorURL = ConfiguratorURL;
			OSLocationType _ConfigDeploymentPath = ConfigDeploymentPath;
			FlagNyType _AvailCfg = AvailCfg;
			ListYesNoType _AllowFcstBomSupplyItems = AllowFcstBomSupplyItems;
			ListYesNoType _CostItemAtWhse = CostItemAtWhse;
			UMType _LinearDimensionUM = LinearDimensionUM;
			UMType _DensityUM = DensityUM;
			UMType _AreaUM = AreaUM;
			UMType _BulkMassUM = BulkMassUM;
			UMType _ReamMassUM = ReamMassUM;
			LotPrefixType _LotPrefix = LotPrefix;
			ListYesNoType _LotTracked = LotTracked;
			ListLocLotType _IssueBy = IssueBy;
			ListYesNoType _SerialTracked = SerialTracked;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			CostTypeType _CostType = CostType;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			InfobarType _Infobar = Infobar;
			SiteType _PSite = PSite;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemPreDisplayEntrySp";
				
				appDB.AddCommandParameter(cmd, "CanUpdateRevTrack", _CanUpdateRevTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ApsParmApsmode", _ApsParmApsmode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrackTaxFreeimports", _TrackTaxFreeimports, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "RUserCode", _RUserCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceOver", _POToleranceOver, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "POToleranceUnder", _POToleranceUnder, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Vchrauthorize", _Vchrauthorize, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrOverPoCostTolerance", _VchrOverPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VchrUnderPoCostTolerance", _VchrUnderPoCostTolerance, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "use_wholesale_price", _use_wholesale_price, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "use_backflush", _use_backflush, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfigServerId", _ConfigServerId, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfigHeaderNameSpace", _ConfigHeaderNameSpace, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Configurator", _Configurator, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfiguratorURL", _ConfiguratorURL, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ConfigDeploymentPath", _ConfigDeploymentPath, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AvailCfg", _AvailCfg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AllowFcstBomSupplyItems", _AllowFcstBomSupplyItems, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostItemAtWhse", _CostItemAtWhse, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LinearDimensionUM", _LinearDimensionUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DensityUM", _DensityUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AreaUM", _AreaUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "BulkMassUM", _BulkMassUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ReamMassUM", _ReamMassUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IssueBy", _IssueBy, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PSite", _PSite, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				CanUpdateRevTrack = _CanUpdateRevTrack;
				ApsParmApsmode = _ApsParmApsmode;
				TrackTaxFreeimports = _TrackTaxFreeimports;
				RUserCode = _RUserCode;
				POToleranceOver = _POToleranceOver;
				POToleranceUnder = _POToleranceUnder;
				Vchrauthorize = _Vchrauthorize;
				VchrOverPoCostTolerance = _VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = _VchrUnderPoCostTolerance;
				use_wholesale_price = _use_wholesale_price;
				use_backflush = _use_backflush;
				ConfigServerId = _ConfigServerId;
				ConfigHeaderNameSpace = _ConfigHeaderNameSpace;
				Configurator = _Configurator;
				ConfiguratorURL = _ConfiguratorURL;
				ConfigDeploymentPath = _ConfigDeploymentPath;
				AvailCfg = _AvailCfg;
				AllowFcstBomSupplyItems = _AllowFcstBomSupplyItems;
				CostItemAtWhse = _CostItemAtWhse;
				LinearDimensionUM = _LinearDimensionUM;
				DensityUM = _DensityUM;
				AreaUM = _AreaUM;
				BulkMassUM = _BulkMassUM;
				ReamMassUM = _ReamMassUM;
				LotPrefix = _LotPrefix;
				LotTracked = _LotTracked;
				IssueBy = _IssueBy;
				SerialTracked = _SerialTracked;
				SerialPrefix = _SerialPrefix;
				CostType = _CostType;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				Infobar = _Infobar;
				
				return (Severity, CanUpdateRevTrack, ApsParmApsmode, TrackTaxFreeimports, RUserCode, POToleranceOver, POToleranceUnder, Vchrauthorize, VchrOverPoCostTolerance, VchrUnderPoCostTolerance, use_wholesale_price, use_backflush, ConfigServerId, ConfigHeaderNameSpace, Configurator, ConfiguratorURL, ConfigDeploymentPath, AvailCfg, AllowFcstBomSupplyItems, CostItemAtWhse, LinearDimensionUM, DensityUM, AreaUM, BulkMassUM, ReamMassUM, LotPrefix, LotTracked, IssueBy, SerialTracked, SerialPrefix, CostType, PreassignLots, PreassignSerials, Infobar);
			}
		}
	}
}
