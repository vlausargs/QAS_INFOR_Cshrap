//PROJECT NAME: Logistics
//CLASS NAME: GetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetItemInfo : IGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public GetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Description,
		string UM,
		int? SerialTracked,
		string Revision,
		string DrawingNbr,
		string CostType,
		string PMTCode,
		decimal? CurMatCost,
		decimal? CurMatCostConv,
		decimal? CurFreightCost,
		decimal? CurFreightCostConv,
		decimal? CurDutyCost,
		decimal? CurDutyCostConv,
		decimal? CurBrokerageCost,
		decimal? CurBrokerageCostConv,
		decimal? CurInsuranceCost,
		decimal? CurInsuranceCostConv,
		decimal? CurLocFrtCost,
		decimal? CurLocFrtCostConv,
		string CommCode,
		string Origin,
		decimal? UnitWeight,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string PromptMsg,
		string Infobar,
		int? LotTracked,
		int? PreassignLots,
		int? PreassignSerials,
		string LotPrefix,
		string SerialPrefix,
		int? IsOpenNonInvForm) GetItemInfoSp(string Item,
		string Description,
		string UM,
		int? SerialTracked,
		string Revision,
		string DrawingNbr,
		string CostType,
		string PMTCode,
		decimal? CurMatCost,
		decimal? CurMatCostConv,
		decimal? CurFreightCost,
		decimal? CurFreightCostConv,
		decimal? CurDutyCost,
		decimal? CurDutyCostConv,
		decimal? CurBrokerageCost,
		decimal? CurBrokerageCostConv,
		decimal? CurInsuranceCost,
		decimal? CurInsuranceCostConv,
		decimal? CurLocFrtCost,
		decimal? CurLocFrtCostConv,
		string CommCode,
		string Origin,
		decimal? UnitWeight,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		string PromptMsg,
		string Infobar,
		string Site = null,
		int? LotTracked = null,
		int? PreassignLots = null,
		int? PreassignSerials = null,
		string LotPrefix = null,
		string SerialPrefix = null,
		string Whse = null,
		int? IsOpenNonInvForm = 0)
		{
			ItemType _Item = Item;
			DescriptionType _Description = Description;
			UMType _UM = UM;
			ListYesNoType _SerialTracked = SerialTracked;
			RevisionType _Revision = Revision;
			DrawingNbrType _DrawingNbr = DrawingNbr;
			CostTypeType _CostType = CostType;
			PMTCodeType _PMTCode = PMTCode;
			CostPrcType _CurMatCost = CurMatCost;
			CostPrcType _CurMatCostConv = CurMatCostConv;
			CostPrcType _CurFreightCost = CurFreightCost;
			CostPrcType _CurFreightCostConv = CurFreightCostConv;
			CostPrcType _CurDutyCost = CurDutyCost;
			CostPrcType _CurDutyCostConv = CurDutyCostConv;
			CostPrcType _CurBrokerageCost = CurBrokerageCost;
			CostPrcType _CurBrokerageCostConv = CurBrokerageCostConv;
			CostPrcType _CurInsuranceCost = CurInsuranceCost;
			CostPrcType _CurInsuranceCostConv = CurInsuranceCostConv;
			CostPrcType _CurLocFrtCost = CurLocFrtCost;
			CostPrcType _CurLocFrtCostConv = CurLocFrtCostConv;
			CommodityCodeType _CommCode = CommCode;
			EcCodeType _Origin = Origin;
			UnitWeightType _UnitWeight = UnitWeight;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _ItemExists = ItemExists;
			FlagNyType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			Infobar _PromptMsg = PromptMsg;
			Infobar _Infobar = Infobar;
			SiteType _Site = Site;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			LotPrefixType _LotPrefix = LotPrefix;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			WhseType _Whse = Whse;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "GetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DrawingNbr", _DrawingNbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurMatCost", _CurMatCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurMatCostConv", _CurMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurFreightCost", _CurFreightCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurFreightCostConv", _CurFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurDutyCost", _CurDutyCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurDutyCostConv", _CurDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurBrokerageCost", _CurBrokerageCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurBrokerageCostConv", _CurBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurInsuranceCost", _CurInsuranceCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurInsuranceCostConv", _CurInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurLocFrtCost", _CurLocFrtCost, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CurLocFrtCostConv", _CurLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsg", _PromptMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Description = _Description;
				UM = _UM;
				SerialTracked = _SerialTracked;
				Revision = _Revision;
				DrawingNbr = _DrawingNbr;
				CostType = _CostType;
				PMTCode = _PMTCode;
				CurMatCost = _CurMatCost;
				CurMatCostConv = _CurMatCostConv;
				CurFreightCost = _CurFreightCost;
				CurFreightCostConv = _CurFreightCostConv;
				CurDutyCost = _CurDutyCost;
				CurDutyCostConv = _CurDutyCostConv;
				CurBrokerageCost = _CurBrokerageCost;
				CurBrokerageCostConv = _CurBrokerageCostConv;
				CurInsuranceCost = _CurInsuranceCost;
				CurInsuranceCostConv = _CurInsuranceCostConv;
				CurLocFrtCost = _CurLocFrtCost;
				CurLocFrtCostConv = _CurLocFrtCostConv;
				CommCode = _CommCode;
				Origin = _Origin;
				UnitWeight = _UnitWeight;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				ItemExists = _ItemExists;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				PromptMsg = _PromptMsg;
				Infobar = _Infobar;
				LotTracked = _LotTracked;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				LotPrefix = _LotPrefix;
				SerialPrefix = _SerialPrefix;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				
				return (Severity, Item, Description, UM, SerialTracked, Revision, DrawingNbr, CostType, PMTCode, CurMatCost, CurMatCostConv, CurFreightCost, CurFreightCostConv, CurDutyCost, CurDutyCostConv, CurBrokerageCost, CurBrokerageCostConv, CurInsuranceCost, CurInsuranceCostConv, CurLocFrtCost, CurLocFrtCostConv, CommCode, Origin, UnitWeight, TaxCode1, TaxCode2, ItemExists, SupplQtyReq, SupplQtyConvFactor, PromptMsg, Infobar, LotTracked, PreassignLots, PreassignSerials, LotPrefix, SerialPrefix, IsOpenNonInvForm);
			}
		}
	}
}
