//PROJECT NAME: Data
//CLASS NAME: ItemInsUpd.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using CSI.Data.CRUD;
using CSI.Data.RecordSets;
using CSI.MG;

namespace CSI.Functions
{
	public class ItemInsUpd : IItemInsUpd
	{
		readonly IApplicationDB appDB;
		
		public ItemInsUpd(IApplicationDB appDB)
		{
			this.appDB = appDB;
		}
		
		public (int? ReturnCode,
			string Item) ItemInsUpdSp(
			string Item,
			string AbcCode = null,
			int? AcceptReq = 0,
			int? ActiveForCustomerPortal = 0,
			int? ActiveForDataIntegration = 0,
			string AltItem = null,
			string AutoJob = null,
			int? Backflush = 0,
			string BflushLoc = null,
			string Buyer = null,
			string CfgModel = null,
			string Charfld1 = null,
			string Charfld2 = null,
			string Charfld3 = null,
			DateTime? ChgDate = null,
			string CommCode = null,
			string CostMethod = null,
			string CostType = null,
			decimal? CurUCost = null,
			DateTime? Datefld = null,
			int? DaysSupply = null,
			decimal? Decifld1 = null,
			decimal? Decifld2 = null,
			decimal? Decifld3 = null,
			string Description = null,
			int? DockTime = null,
			string DrawingNbr = null,
			int? DuePeriod = null,
			DateTime? EarliestPlannedPoReceipt = null,
			int? ExpLeadTime = null,
			string FamilyCode = null,
			string FeatStr = null,
			string FeatTempl = null,
			int? Featured = 0,
			decimal? FixedOrderQty = null,
			int? InfinitePart = 0,
			decimal? InventoryLclTolerance = null,
			decimal? InventoryUclTolerance = null,
			string IssueBy = "LOT",
			string Job = null,
			int? JobConfigurable = 0,
			int? Kit = 0,
			int? LeadTime = null,
			int? Logifld = null,
			string LotPrefix = null,
			decimal? LotSize = null,
			int? LotTracked = 0,
			int? LowLevel = null,
			string MatlType = null,
			int? MpsFlag = 0,
			int? MpsPlanFence = null,
			int? MrpPart = 0,
			int? OrderConfigurable = 0,
			decimal? OrderMax = null,
			decimal? OrderMin = null,
			decimal? OrderMult = null,
			string Origin = null,
			string Overview = null,
			int? PaperTime = null,
			int? PassReq = 0,
			int? PhantomFlag = 0,
			string PlanCode = null,
			int? PlanFlag = 0,
			string PMTCode = null,
			int? PrintKitComponents = 0,
			string ProdMix = null,
			string ProdType = null,
			string ProductCode = null,
			decimal? QtyAllocjob = null,
			decimal? RatePerDay = null,
			decimal? RcvdOverPoQtyTolerance = null,
			decimal? RcvdUnderPoQtyTolerance = null,
			string ReasonCode = null,
			decimal? ReorderPoint = null,
			int? Reservable = 0,
			string Revision = null,
			decimal? SafetyStockPercent = null,
			int? SerialLength = null,
			string SerialPrefix = null,
			int? SerialTracked = 0,
			string Setupgroup = null,
			int? ShelfLife = null,
			int? ShowInDropDownList = 0,
			decimal? ShrinkFact = null,
			string Stat = null,
			string StatusChgUserCode = null,
			int? Stocked = 0,
			int? Suffix = null,
			string SupplySite = null,
			decimal? SupplyToleranceHrs = null,
			string SupplyWhse = null,
			string TariffClassification = null,
			int? TaxFreeDays = null,
			int? TaxFreeMatl = 0,
			int? TimeFenceRule = 0,
			decimal? TimeFenceValue = null,
			int? TopSeller = 0,
			int? TrackEcn = 0,
			string UM = null,
			decimal? UnitCost = null,
			decimal? UnitWeight = null,
			int? UseReorderPoint = 0,
			decimal? VarExpLead = null,
			decimal? VarLead = null,
			string WeightUnits = null,
			int? SaveCurrentRevUponBomImport = 0,
			int? PreassignLots = 0,
			int? PreassignSerials = 0,
			int? SubjectToExciseTax = 0,
			decimal? ExciseTaxPercent = null,
			int? AllowOnPickList = 0,
			string FlagInsertUpdate = "I",
			Guid? RowPointer = null,
			DateTime? RecordDate = null,
			string NAFTACountryOfOrigin = null,
			string NAFTAPreferenceCriterion = null)
		{
			ItemType _Item = Item;
			AbcCodeType _AbcCode = AbcCode;
			ListYesNoType _AcceptReq = AcceptReq;
			ListYesNoType _ActiveForCustomerPortal = ActiveForCustomerPortal;
			ListYesNoType _ActiveForDataIntegration = ActiveForDataIntegration;
			ItemType _AltItem = AltItem;
			ConfigAutoJobType _AutoJob = AutoJob;
			ListYesNoType _Backflush = Backflush;
			LocType _BflushLoc = BflushLoc;
			UsernameType _Buyer = Buyer;
			ConfigModelType _CfgModel = CfgModel;
			UserCharFldType _Charfld1 = Charfld1;
			UserCharFldType _Charfld2 = Charfld2;
			UserCharFldType _Charfld3 = Charfld3;
			DateType _ChgDate = ChgDate;
			CommodityCodeType _CommCode = CommCode;
			CostMethodType _CostMethod = CostMethod;
			CostTypeType _CostType = CostType;
			CostPrcType _CurUCost = CurUCost;
			UserDateFldType _Datefld = Datefld;
			DaysSupplyType _DaysSupply = DaysSupply;
			UserDeciFldType _Decifld1 = Decifld1;
			UserDeciFldType _Decifld2 = Decifld2;
			UserDeciFldType _Decifld3 = Decifld3;
			DescriptionType _Description = Description;
			LeadTimeType _DockTime = DockTime;
			DrawingNbrType _DrawingNbr = DrawingNbr;
			DuePeriodType _DuePeriod = DuePeriod;
			DateType _EarliestPlannedPoReceipt = EarliestPlannedPoReceipt;
			LeadTimeType _ExpLeadTime = ExpLeadTime;
			FamilyCodeType _FamilyCode = FamilyCode;
			FeatStrType _FeatStr = FeatStr;
			FeatTemplateType _FeatTempl = FeatTempl;
			ListYesNoType _Featured = Featured;
			QtyUnitType _FixedOrderQty = FixedOrderQty;
			ListYesNoType _InfinitePart = InfinitePart;
			TolerancePercentType _InventoryLclTolerance = InventoryLclTolerance;
			TolerancePercentType _InventoryUclTolerance = InventoryUclTolerance;
			ListLocLotType _IssueBy = IssueBy;
			JobType _Job = Job;
			ListYesNoType _JobConfigurable = JobConfigurable;
			ListYesNoType _Kit = Kit;
			LeadTimeType _LeadTime = LeadTime;
			UserLogiFldType _Logifld = Logifld;
			LotPrefixType _LotPrefix = LotPrefix;
			QtyPerType _LotSize = LotSize;
			ListYesNoType _LotTracked = LotTracked;
			LowLevelType _LowLevel = LowLevel;
			MatlTypeType _MatlType = MatlType;
			ListYesNoType _MpsFlag = MpsFlag;
			PlanFenceType _MpsPlanFence = MpsPlanFence;
			ListYesNoType _MrpPart = MrpPart;
			ListYesNoType _OrderConfigurable = OrderConfigurable;
			QtyUnitType _OrderMax = OrderMax;
			QtyUnitType _OrderMin = OrderMin;
			QtyUnitType _OrderMult = OrderMult;
			EcCodeType _Origin = Origin;
			ProductOverviewType _Overview = Overview;
			LeadTimeType _PaperTime = PaperTime;
			ListYesNoType _PassReq = PassReq;
			ListYesNoType _PhantomFlag = PhantomFlag;
			UserCodeType _PlanCode = PlanCode;
			ListYesNoType _PlanFlag = PlanFlag;
			PMTCodeType _PMTCode = PMTCode;
			ListYesNoType _PrintKitComponents = PrintKitComponents;
			ProdMixType _ProdMix = ProdMix;
			ProdTypeType _ProdType = ProdType;
			ProductCodeType _ProductCode = ProductCode;
			QtyTotlType _QtyAllocjob = QtyAllocjob;
			RunRateType _RatePerDay = RatePerDay;
			TolerancePercentType _RcvdOverPoQtyTolerance = RcvdOverPoQtyTolerance;
			TolerancePercentType _RcvdUnderPoQtyTolerance = RcvdUnderPoQtyTolerance;
			ReasonCodeType _ReasonCode = ReasonCode;
			QtyUnitType _ReorderPoint = ReorderPoint;
			ListYesNoType _Reservable = Reservable;
			RevisionType _Revision = Revision;
			SafetyStockPercentType _SafetyStockPercent = SafetyStockPercent;
			SerialLengthType _SerialLength = SerialLength;
			SerialPrefixType _SerialPrefix = SerialPrefix;
			ListYesNoType _SerialTracked = SerialTracked;
			SetupGroupType _Setupgroup = Setupgroup;
			ShelfLifeType _ShelfLife = ShelfLife;
			ListYesNoType _ShowInDropDownList = ShowInDropDownList;
			ScrapFactorType _ShrinkFact = ShrinkFact;
			ItemStatusType _Stat = Stat;
			UserCodeType _StatusChgUserCode = StatusChgUserCode;
			ListYesNoType _Stocked = Stocked;
			SuffixType _Suffix = Suffix;
			SiteType _SupplySite = SupplySite;
			SupplyToleranceHoursType _SupplyToleranceHrs = SupplyToleranceHrs;
			WhseType _SupplyWhse = SupplyWhse;
			TariffClassificationType _TariffClassification = TariffClassification;
			TaxFreeDaysType _TaxFreeDays = TaxFreeDays;
			ListYesNoType _TaxFreeMatl = TaxFreeMatl;
			ListTimeFenceRuleType _TimeFenceRule = TimeFenceRule;
			ApsFloatType _TimeFenceValue = TimeFenceValue;
			ListYesNoType _TopSeller = TopSeller;
			ListYesNoType _TrackEcn = TrackEcn;
			UMType _UM = UM;
			CostPrcType _UnitCost = UnitCost;
			ItemWeightType _UnitWeight = UnitWeight;
			ListYesNoType _UseReorderPoint = UseReorderPoint;
			VarLeadTimeType _VarExpLead = VarExpLead;
			VarLeadTimeType _VarLead = VarLead;
			WeightUnitsType _WeightUnits = WeightUnits;
			ListYesNoType _SaveCurrentRevUponBomImport = SaveCurrentRevUponBomImport;
			ListYesNoType _PreassignLots = PreassignLots;
			ListYesNoType _PreassignSerials = PreassignSerials;
			ListYesNoType _SubjectToExciseTax = SubjectToExciseTax;
			ExciseTaxPercentType _ExciseTaxPercent = ExciseTaxPercent;
			ListYesNoType _AllowOnPickList = AllowOnPickList;
			SfModeType _FlagInsertUpdate = FlagInsertUpdate;
			RowPointerType _RowPointer = RowPointer;
			DateType _RecordDate = RecordDate;
			NAFTACountryOfOriginType _NAFTACountryOfOrigin = NAFTACountryOfOrigin;
			NAFTAPreferenceCriterionType _NAFTAPreferenceCriterion = NAFTAPreferenceCriterion;
			
			using (IDbCommand cmd = appDB.CreateCommand())
			{
				
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.CommandText = "ItemInsUpdSp";
				
				appDB.AddCommandParameter(cmd, "Item", _Item, ParameterDirection.InputOutput);
				appDB.AddCommandParameter(cmd, "AbcCode", _AbcCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AcceptReq", _AcceptReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForCustomerPortal", _ActiveForCustomerPortal, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ActiveForDataIntegration", _ActiveForDataIntegration, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AltItem", _AltItem, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AutoJob", _AutoJob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Backflush", _Backflush, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "BflushLoc", _BflushLoc, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Buyer", _Buyer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CfgModel", _CfgModel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld1", _Charfld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld2", _Charfld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Charfld3", _Charfld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ChgDate", _ChgDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CommCode", _CommCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostMethod", _CostMethod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CostType", _CostType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "CurUCost", _CurUCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Datefld", _Datefld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DaysSupply", _DaysSupply, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld1", _Decifld1, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld2", _Decifld2, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Decifld3", _Decifld3, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Description", _Description, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DockTime", _DockTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DrawingNbr", _DrawingNbr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "DuePeriod", _DuePeriod, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "EarliestPlannedPoReceipt", _EarliestPlannedPoReceipt, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExpLeadTime", _ExpLeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FamilyCode", _FamilyCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatStr", _FeatStr, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FeatTempl", _FeatTempl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Featured", _Featured, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FixedOrderQty", _FixedOrderQty, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InfinitePart", _InfinitePart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InventoryLclTolerance", _InventoryLclTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "InventoryUclTolerance", _InventoryUclTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "IssueBy", _IssueBy, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Job", _Job, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "JobConfigurable", _JobConfigurable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Kit", _Kit, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LeadTime", _LeadTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Logifld", _Logifld, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotPrefix", _LotPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotSize", _LotSize, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LotTracked", _LotTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "LowLevel", _LowLevel, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MatlType", _MatlType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpsFlag", _MpsFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MpsPlanFence", _MpsPlanFence, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "MrpPart", _MrpPart, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderConfigurable", _OrderConfigurable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderMax", _OrderMax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderMin", _OrderMin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "OrderMult", _OrderMult, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Origin", _Origin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Overview", _Overview, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PaperTime", _PaperTime, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PassReq", _PassReq, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PhantomFlag", _PhantomFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanCode", _PlanCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PlanFlag", _PlanFlag, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PMTCode", _PMTCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PrintKitComponents", _PrintKitComponents, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdMix", _ProdMix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProdType", _ProdType, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ProductCode", _ProductCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "QtyAllocjob", _QtyAllocjob, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RatePerDay", _RatePerDay, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdOverPoQtyTolerance", _RcvdOverPoQtyTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RcvdUnderPoQtyTolerance", _RcvdUnderPoQtyTolerance, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReasonCode", _ReasonCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ReorderPoint", _ReorderPoint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Reservable", _Reservable, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Revision", _Revision, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SafetyStockPercent", _SafetyStockPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialLength", _SerialLength, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialPrefix", _SerialPrefix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SerialTracked", _SerialTracked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Setupgroup", _Setupgroup, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShelfLife", _ShelfLife, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShowInDropDownList", _ShowInDropDownList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ShrinkFact", _ShrinkFact, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stat", _Stat, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "StatusChgUserCode", _StatusChgUserCode, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Stocked", _Stocked, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "Suffix", _Suffix, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplySite", _SupplySite, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyToleranceHrs", _SupplyToleranceHrs, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SupplyWhse", _SupplyWhse, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TariffClassification", _TariffClassification, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeDays", _TaxFreeDays, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TaxFreeMatl", _TaxFreeMatl, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeFenceRule", _TimeFenceRule, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TimeFenceValue", _TimeFenceValue, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TopSeller", _TopSeller, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "TrackEcn", _TrackEcn, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UM", _UM, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitCost", _UnitCost, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UnitWeight", _UnitWeight, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "UseReorderPoint", _UseReorderPoint, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VarExpLead", _VarExpLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "VarLead", _VarLead, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "WeightUnits", _WeightUnits, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SaveCurrentRevUponBomImport", _SaveCurrentRevUponBomImport, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignLots", _PreassignLots, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "PreassignSerials", _PreassignSerials, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "SubjectToExciseTax", _SubjectToExciseTax, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "ExciseTaxPercent", _ExciseTaxPercent, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "AllowOnPickList", _AllowOnPickList, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "FlagInsertUpdate", _FlagInsertUpdate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RowPointer", _RowPointer, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "RecordDate", _RecordDate, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NAFTACountryOfOrigin", _NAFTACountryOfOrigin, ParameterDirection.Input);
				appDB.AddCommandParameter(cmd, "NAFTAPreferenceCriterion", _NAFTAPreferenceCriterion, ParameterDirection.Input);
				
				var Severity = appDB.ExecuteNonQuery(cmd);
				
				Item = _Item;
				
				return (Severity, Item);
			}
		}
	}
}
