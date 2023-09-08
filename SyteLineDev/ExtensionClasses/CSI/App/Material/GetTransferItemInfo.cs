//PROJECT NAME: Material
//CLASS NAME: GetTransferItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Material
{
	public class GetTransferItemInfo : IGetTransferItemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetTransferItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Origin,
		decimal? UnitWeight,
		string UM,
		string ToRefType,
		string ToRefNum,
		int? ToRefLineSuf,
		int? ToRefRelease,
		string FrmRefType,
		string FrmRefNum,
		int? FrmRefLineSuf,
		int? FrmRefRelease,
		string TrnLoc,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string CommCode,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string Infobar,
		int? FromLotTrack,
		int? ToLotTrack,
		int? PreassignLots,
		int? FromSerialTrack,
		int? ToSerialTrack,
		int? PreassignSerials,
		string ToLotPrefix,
		string ToSerialPrefix,
		int? UseExistingLot,
		int? UseExistingSerial) GetTransferItemInfoSp(string TrnNum,
		string Item,
		string Pricecode,
		decimal? QtyReq,
		int? Update,
		int? TrnLine,
		string FromSite,
		string ToSite,
		string Origin,
		decimal? UnitWeight,
		string UM,
		string ToRefType,
		string ToRefNum,
		int? ToRefLineSuf,
		int? ToRefRelease,
		string FrmRefType,
		string FrmRefNum,
		int? FrmRefLineSuf,
		int? FrmRefRelease,
		string TrnLoc,
		decimal? UnitCost,
		decimal? UnitCostConv,
		decimal? MatlCost,
		decimal? LbrCost,
		decimal? FovhdCost,
		decimal? VovhdCost,
		decimal? OutCost,
		decimal? UnitPrice,
		decimal? UnitPriceConv,
		decimal? UnitMatCost,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCost,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCost,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCost,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCost,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCost,
		decimal? UnitLocFrtCostConv,
		decimal? UnitTotalCost,
		decimal? ExtPrice,
		string CommCode,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string Infobar,
		int? FromLotTrack,
		int? ToLotTrack,
		int? PreassignLots,
		int? FromSerialTrack,
		int? ToSerialTrack,
		int? PreassignSerials,
		string ToLotPrefix,
		string ToSerialPrefix,
		int? UseExistingLot,
		int? UseExistingSerial)
		{
			TrnNumType _TrnNum = TrnNum;
			ItemType _Item = Item;
			PriceCodeType _Pricecode = Pricecode;
			QtyUnitType _QtyReq = QtyReq;
			Flag _Update = Update;
			TrnLineType _TrnLine = TrnLine;
			SiteType _FromSite = FromSite;
			SiteType _ToSite = ToSite;
			EcCodeType _Origin = Origin;
			UnitWeightType _UnitWeight = UnitWeight;
			UMType _UM = UM;
			RefTypeIJOType _ToRefType = ToRefType;
			CoNumJobType _ToRefNum = ToRefNum;
			CoLineSuffixType _ToRefLineSuf = ToRefLineSuf;
			CoReleaseOperNumType _ToRefRelease = ToRefRelease;
			RefTypeIJKPRTType _FrmRefType = FrmRefType;
			JobPoReqNumType _FrmRefNum = FrmRefNum;
			SuffixPoReqLineType _FrmRefLineSuf = FrmRefLineSuf;
			PoReleaseType _FrmRefRelease = FrmRefRelease;
			LocType _TrnLoc = TrnLoc;
			CostPrcType _UnitCost = UnitCost;
			CostPrcType _UnitCostConv = UnitCostConv;
			CostPrcType _MatlCost = MatlCost;
			CostPrcType _LbrCost = LbrCost;
			CostPrcType _FovhdCost = FovhdCost;
			CostPrcType _VovhdCost = VovhdCost;
			CostPrcType _OutCost = OutCost;
			CostPrcType _UnitPrice = UnitPrice;
			CostPrcType _UnitPriceConv = UnitPriceConv;
			CostPrcType _UnitMatCost = UnitMatCost;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitFreightCost = UnitFreightCost;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCost = UnitDutyCost;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCost = UnitBrokerageCost;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCost = UnitInsuranceCost;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCost = UnitLocFrtCost;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			CostPrcType _UnitTotalCost = UnitTotalCost;
			CostPrcType _ExtPrice = ExtPrice;
			CommodityCodeType _CommCode = CommCode;
			FlagNyType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			InfobarType _Infobar = Infobar;
			ListYesNoType _FromLotTrack = FromLotTrack;
			ListYesNoType _ToLotTrack = ToLotTrack;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _FromSerialTrack = FromSerialTrack;
			ListYesNoType _ToSerialTrack = ToSerialTrack;
			ListYesNoType _PreassignSerials = PreassignSerials;
			LotPrefixType _ToLotPrefix = ToLotPrefix;
			SerialPrefixType _ToSerialPrefix = ToSerialPrefix;
			ListYesNoType _UseExistingLot = UseExistingLot;
			ListYesNoType _UseExistingSerial = UseExistingSerial;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetTransferItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "TrnNum", _TrnNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Pricecode", _Pricecode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyReq", _QtyReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Update", _Update, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrnLine", _TrnLine, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FromSite", _FromSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ToSite", _ToSite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToRefType", _ToRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToRefNum", _ToRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToRefLineSuf", _ToRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToRefRelease", _ToRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrmRefType", _FrmRefType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrmRefNum", _FrmRefNum, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrmRefLineSuf", _FrmRefLineSuf, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FrmRefRelease", _FrmRefRelease, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TrnLoc", _TrnLoc, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitCostConv", _UnitCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "MatlCost", _MatlCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LbrCost", _LbrCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FovhdCost", _FovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VovhdCost", _VovhdCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "OutCost", _OutCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPrice", _UnitPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitPriceConv", _UnitPriceConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCost", _UnitMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCost", _UnitFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCost", _UnitDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCost", _UnitBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCost", _UnitInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCost", _UnitLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitTotalCost", _UnitTotalCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ExtPrice", _ExtPrice, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromLotTrack", _FromLotTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLotTrack", _ToLotTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "FromSerialTrack", _FromSerialTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSerialTrack", _ToSerialTrack, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToLotPrefix", _ToLotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ToSerialPrefix", _ToSerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExistingLot", _UseExistingLot, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UseExistingSerial", _UseExistingSerial, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Origin = _Origin;
				UnitWeight = _UnitWeight;
				UM = _UM;
				ToRefType = _ToRefType;
				ToRefNum = _ToRefNum;
				ToRefLineSuf = _ToRefLineSuf;
				ToRefRelease = _ToRefRelease;
				FrmRefType = _FrmRefType;
				FrmRefNum = _FrmRefNum;
				FrmRefLineSuf = _FrmRefLineSuf;
				FrmRefRelease = _FrmRefRelease;
				TrnLoc = _TrnLoc;
				UnitCost = _UnitCost;
				UnitCostConv = _UnitCostConv;
				MatlCost = _MatlCost;
				LbrCost = _LbrCost;
				FovhdCost = _FovhdCost;
				VovhdCost = _VovhdCost;
				OutCost = _OutCost;
				UnitPrice = _UnitPrice;
				UnitPriceConv = _UnitPriceConv;
				UnitMatCost = _UnitMatCost;
				UnitMatCostConv = _UnitMatCostConv;
				UnitFreightCost = _UnitFreightCost;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitDutyCost = _UnitDutyCost;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitBrokerageCost = _UnitBrokerageCost;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCost = _UnitInsuranceCost;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCost = _UnitLocFrtCost;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				UnitTotalCost = _UnitTotalCost;
				ExtPrice = _ExtPrice;
				CommCode = _CommCode;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				Infobar = _Infobar;
				FromLotTrack = _FromLotTrack;
				ToLotTrack = _ToLotTrack;
				PreassignLots = _PreassignLots;
				FromSerialTrack = _FromSerialTrack;
				ToSerialTrack = _ToSerialTrack;
				PreassignSerials = _PreassignSerials;
				ToLotPrefix = _ToLotPrefix;
				ToSerialPrefix = _ToSerialPrefix;
				UseExistingLot = _UseExistingLot;
				UseExistingSerial = _UseExistingSerial;
				
				return (Severity, Origin, UnitWeight, UM, ToRefType, ToRefNum, ToRefLineSuf, ToRefRelease, FrmRefType, FrmRefNum, FrmRefLineSuf, FrmRefRelease, TrnLoc, UnitCost, UnitCostConv, MatlCost, LbrCost, FovhdCost, VovhdCost, OutCost, UnitPrice, UnitPriceConv, UnitMatCost, UnitMatCostConv, UnitFreightCost, UnitFreightCostConv, UnitDutyCost, UnitDutyCostConv, UnitBrokerageCost, UnitBrokerageCostConv, UnitInsuranceCost, UnitInsuranceCostConv, UnitLocFrtCost, UnitLocFrtCostConv, UnitTotalCost, ExtPrice, CommCode, SupplQtyReq, SupplQtyConvFactor, Infobar, FromLotTrack, ToLotTrack, PreassignLots, FromSerialTrack, ToSerialTrack, PreassignSerials, ToLotPrefix, ToSerialPrefix, UseExistingLot, UseExistingSerial);
			}
		}
	}
}
