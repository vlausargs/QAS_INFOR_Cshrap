//PROJECT NAME: Logistics
//CLASS NAME: PoItemGetItemInfo.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PoItemGetItemInfo : IPoItemGetItemInfo
	{
		readonly IApplicationDB appDB;
		
		
		public PoItemGetItemInfo(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode, string Item,
		string Description,
		string ItemUM,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? SerialTracked,
		string Revision,
		string DrawingNbr,
		string CostType,
		string PMTCode,
		string CommCode,
		string Origin,
		decimal? UnitWeight,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string PromptMsgNI,
		string PromptMsgCZ,
		string PromptBtnsCZ,
		string PromptMsgOS,
		string PromptBtnsOS,
		string Infobar,
		string WarningMsg,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		int? DispMsg,
		int? LotTracked,
		int? PreassignLots,
		int? PreassignSerials,
		string LotPrefix,
		string SerialPrefix,
		int? AcctIsControl,
		int? IsOpenNonInvForm,
		int? ControlledByExternalWms,
		string PromptMsgUseUp) PoItemGetItemInfoSp(string Item,
		string VendNum,
		string VendorCurrCode,
		decimal? ExchRate,
		string Whse,
		string PoTaxCode1,
		string PoTaxCode2,
		decimal? QtyOrderedConv,
		DateTime? EffectiveDate,
		string Description,
		string ItemUM,
		decimal? UnitMatCostConv,
		decimal? UnitFreightCostConv,
		decimal? UnitDutyCostConv,
		decimal? UnitBrokerageCostConv,
		decimal? UnitInsuranceCostConv,
		decimal? UnitLocFrtCostConv,
		int? SerialTracked,
		string Revision,
		string DrawingNbr,
		string CostType,
		string PMTCode,
		string CommCode,
		string Origin,
		decimal? UnitWeight,
		string TaxCode1,
		string TaxCode2,
		int? ItemExists,
		string NonInvAcct,
		string NonInvAcctUnit1,
		string NonInvAcctUnit2,
		string NonInvAcctUnit3,
		string NonInvAcctUnit4,
		string AccessUnit1,
		string AccessUnit2,
		string AccessUnit3,
		string AccessUnit4,
		string PromptMsgNI,
		string PromptMsgCZ,
		string PromptBtnsCZ,
		string PromptMsgOS,
		string PromptBtnsOS,
		string Infobar,
		string PONum,
		string WarningMsg,
		int? SupplQtyReq,
		decimal? SupplQtyConvFactor,
		int? DispMsg,
		string Site = null,
		int? LotTracked = null,
		int? PreassignLots = null,
		int? PreassignSerials = null,
		string LotPrefix = null,
		string SerialPrefix = null,
		int? AcctIsControl = null,
		int? IsOpenNonInvForm = 0,
		int? ControlledByExternalWms = 0,
		string PromptMsgUseUp = null)
		{
			ItemType _Item = Item;
			VendNumType _VendNum = VendNum;
			CurrCodeType _VendorCurrCode = VendorCurrCode;
			ExchRateType _ExchRate = ExchRate;
			WhseType _Whse = Whse;
			TaxCodeType _PoTaxCode1 = PoTaxCode1;
			TaxCodeType _PoTaxCode2 = PoTaxCode2;
			QtyUnitNoNegType _QtyOrderedConv = QtyOrderedConv;
			DateType _EffectiveDate = EffectiveDate;
			DescriptionType _Description = Description;
			UMType _ItemUM = ItemUM;
			CostPrcType _UnitMatCostConv = UnitMatCostConv;
			CostPrcType _UnitFreightCostConv = UnitFreightCostConv;
			CostPrcType _UnitDutyCostConv = UnitDutyCostConv;
			CostPrcType _UnitBrokerageCostConv = UnitBrokerageCostConv;
			CostPrcType _UnitInsuranceCostConv = UnitInsuranceCostConv;
			CostPrcType _UnitLocFrtCostConv = UnitLocFrtCostConv;
			ListYesNoType _SerialTracked = SerialTracked;
			RevisionType _Revision = Revision;
			DrawingNbrType _DrawingNbr = DrawingNbr;
			CostTypeType _CostType = CostType;
			PMTCodeType _PMTCode = PMTCode;
			CommodityCodeType _CommCode = CommCode;
			EcCodeType _Origin = Origin;
			UnitWeightType _UnitWeight = UnitWeight;
			TaxCodeType _TaxCode1 = TaxCode1;
			TaxCodeType _TaxCode2 = TaxCode2;
			ListYesNoType _ItemExists = ItemExists;
			AcctType _NonInvAcct = NonInvAcct;
			UnitCode1Type _NonInvAcctUnit1 = NonInvAcctUnit1;
			UnitCode2Type _NonInvAcctUnit2 = NonInvAcctUnit2;
			UnitCode3Type _NonInvAcctUnit3 = NonInvAcctUnit3;
			UnitCode4Type _NonInvAcctUnit4 = NonInvAcctUnit4;
			UnitCodeAccessType _AccessUnit1 = AccessUnit1;
			UnitCodeAccessType _AccessUnit2 = AccessUnit2;
			UnitCodeAccessType _AccessUnit3 = AccessUnit3;
			UnitCodeAccessType _AccessUnit4 = AccessUnit4;
			InfobarType _PromptMsgNI = PromptMsgNI;
			InfobarType _PromptMsgCZ = PromptMsgCZ;
			InfobarType _PromptBtnsCZ = PromptBtnsCZ;
			InfobarType _PromptMsgOS = PromptMsgOS;
			InfobarType _PromptBtnsOS = PromptBtnsOS;
			InfobarType _Infobar = Infobar;
			PoNumType _PONum = PONum;
			InfobarType _WarningMsg = WarningMsg;
			FlagNyType _SupplQtyReq = SupplQtyReq;
			UMConvFactorType _SupplQtyConvFactor = SupplQtyConvFactor;
			ListYesNoType _DispMsg = DispMsg;
			SiteType _Site = Site;
			ListYesNoType _LotTracked = LotTracked;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			LotPrefixType _LotPrefix = LotPrefix;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ListYesNoType _AcctIsControl = AcctIsControl;
			ListYesNoType _IsOpenNonInvForm = IsOpenNonInvForm;
			ListYesNoType _ControlledByExternalWms = ControlledByExternalWms;
			InfobarType _PromptMsgUseUp = PromptMsgUseUp;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "PoItemGetItemInfoSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "VendNum", _VendNum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VendorCurrCode", _VendorCurrCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExchRate", _ExchRate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Whse", _Whse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoTaxCode1", _PoTaxCode1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PoTaxCode2", _PoTaxCode2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyOrderedConv", _QtyOrderedConv, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EffectiveDate", _EffectiveDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemUM", _ItemUM, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitMatCostConv", _UnitMatCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitFreightCostConv", _UnitFreightCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitDutyCostConv", _UnitDutyCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitBrokerageCostConv", _UnitBrokerageCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitInsuranceCostConv", _UnitInsuranceCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitLocFrtCostConv", _UnitLocFrtCostConv, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DrawingNbr", _DrawingNbr, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode1", _TaxCode1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "TaxCode2", _TaxCode2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ItemExists", _ItemExists, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcct", _NonInvAcct, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit1", _NonInvAcctUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit2", _NonInvAcctUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit3", _NonInvAcctUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "NonInvAcctUnit4", _NonInvAcctUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit1", _AccessUnit1, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit2", _AccessUnit2, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit3", _AccessUnit3, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AccessUnit4", _AccessUnit4, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgNI", _PromptMsgNI, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgCZ", _PromptMsgCZ, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptBtnsCZ", _PromptBtnsCZ, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgOS", _PromptMsgOS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptBtnsOS", _PromptBtnsOS, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Infobar", _Infobar, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PONum", _PONum, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WarningMsg", _WarningMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyReq", _SupplQtyReq, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SupplQtyConvFactor", _SupplQtyConvFactor, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "DispMsg", _DispMsg, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "Site", _Site, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AcctIsControl", _AcctIsControl, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "IsOpenNonInvForm", _IsOpenNonInvForm, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "ControlledByExternalWms", _ControlledByExternalWms, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "PromptMsgUseUp", _PromptMsgUseUp, ParameterDirection.InputOutput);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				Description = _Description;
				ItemUM = _ItemUM;
				UnitMatCostConv = _UnitMatCostConv;
				UnitFreightCostConv = _UnitFreightCostConv;
				UnitDutyCostConv = _UnitDutyCostConv;
				UnitBrokerageCostConv = _UnitBrokerageCostConv;
				UnitInsuranceCostConv = _UnitInsuranceCostConv;
				UnitLocFrtCostConv = _UnitLocFrtCostConv;
				SerialTracked = _SerialTracked;
				Revision = _Revision;
				DrawingNbr = _DrawingNbr;
				CostType = _CostType;
				PMTCode = _PMTCode;
				CommCode = _CommCode;
				Origin = _Origin;
				UnitWeight = _UnitWeight;
				TaxCode1 = _TaxCode1;
				TaxCode2 = _TaxCode2;
				ItemExists = _ItemExists;
				NonInvAcct = _NonInvAcct;
				NonInvAcctUnit1 = _NonInvAcctUnit1;
				NonInvAcctUnit2 = _NonInvAcctUnit2;
				NonInvAcctUnit3 = _NonInvAcctUnit3;
				NonInvAcctUnit4 = _NonInvAcctUnit4;
				AccessUnit1 = _AccessUnit1;
				AccessUnit2 = _AccessUnit2;
				AccessUnit3 = _AccessUnit3;
				AccessUnit4 = _AccessUnit4;
				PromptMsgNI = _PromptMsgNI;
				PromptMsgCZ = _PromptMsgCZ;
				PromptBtnsCZ = _PromptBtnsCZ;
				PromptMsgOS = _PromptMsgOS;
				PromptBtnsOS = _PromptBtnsOS;
				Infobar = _Infobar;
				WarningMsg = _WarningMsg;
				SupplQtyReq = _SupplQtyReq;
				SupplQtyConvFactor = _SupplQtyConvFactor;
				DispMsg = _DispMsg;
				LotTracked = _LotTracked;
				PreassignLots = _PreassignLots;
				PreassignSerials = _PreassignSerials;
				LotPrefix = _LotPrefix;
				SerialPrefix = _SerialPrefix;
				AcctIsControl = _AcctIsControl;
				IsOpenNonInvForm = _IsOpenNonInvForm;
				ControlledByExternalWms = _ControlledByExternalWms;
				PromptMsgUseUp = _PromptMsgUseUp;
				
				return (Severity, Item, Description, ItemUM, UnitMatCostConv, UnitFreightCostConv, UnitDutyCostConv, UnitBrokerageCostConv, UnitInsuranceCostConv, UnitLocFrtCostConv, SerialTracked, Revision, DrawingNbr, CostType, PMTCode, CommCode, Origin, UnitWeight, TaxCode1, TaxCode2, ItemExists, NonInvAcct, NonInvAcctUnit1, NonInvAcctUnit2, NonInvAcctUnit3, NonInvAcctUnit4, AccessUnit1, AccessUnit2, AccessUnit3, AccessUnit4, PromptMsgNI, PromptMsgCZ, PromptBtnsCZ, PromptMsgOS, PromptBtnsOS, Infobar, WarningMsg, SupplQtyReq, SupplQtyConvFactor, DispMsg, LotTracked, PreassignLots, PreassignSerials, LotPrefix, SerialPrefix, AcctIsControl, IsOpenNonInvForm, ControlledByExternalWms, PromptMsgUseUp);
			}
		}
	}
}
