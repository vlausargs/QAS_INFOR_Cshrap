//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemAlls.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLItemAlls")]
    public class SLItemAlls : CSIExtensionClassBase
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemCheckShipSiteSp(string Item,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemCheckShipSiteExt = new ItemCheckShipSiteFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iItemCheckShipSiteExt.ItemCheckShipSiteSp(Item,
                                                                         ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemNewSp(string Item,
                     ref string ItemDescription,
                     ref string ItemUM)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemNewExt = new ItemNewFactory().Create(appDb);

                DescriptionType oItemDescription = ItemDescription;
                UMType oItemUM = ItemUM;

                int Severity = iItemNewExt.ItemNewSp(Item,
                                                     ref oItemDescription,
                                                     ref oItemUM);

                ItemDescription = oItemDescription;
                ItemUM = oItemUM;

                return Severity;
            }
        }



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckItemAllsForSiteSp(string Site,
			string SupplySite,
			string Item,
			ref string Infobar)
		{
			var iCheckItemAllsForSiteExt = this.GetService<ICheckItemAllsForSite>();

			var result = iCheckItemAllsForSiteExt.CheckItemAllsForSiteSp(Site,
				SupplySite,
				Item,
				Infobar);

			Infobar = result.Infobar;

			return result.ReturnCode ?? 0;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DisableEnableTaxFreeMatlForMultiSiteSp([Optional] string PSite,
		                                                  ref byte? DisableEnable)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDisableEnableTaxFreeMatlForMultiSiteExt = new DisableEnableTaxFreeMatlForMultiSiteFactory().Create(appDb);
				
				var result = iDisableEnableTaxFreeMatlForMultiSiteExt.DisableEnableTaxFreeMatlForMultiSiteSp(PSite,
				                                                                                             DisableEnable);
				
				int Severity = result.ReturnCode.Value;
				DisableEnable = result.DisableEnable;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetSiteParmsForItemAllsSP(string Site,
		                                     ref string CurrCode,
		                                     ref byte? EcReporting,
		                                     ref byte? LotGenExp,
		                                     ref byte? SerialLength)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iGetSiteParmsForItemAllsExt = new GetSiteParmsForItemAllsFactory().Create(appDb);
				
				var result = iGetSiteParmsForItemAllsExt.GetSiteParmsForItemAllsSP(Site,
				                                                                   CurrCode,
				                                                                   EcReporting,
				                                                                   LotGenExp,
				                                                                   SerialLength);
				
				int Severity = result.ReturnCode.Value;
				CurrCode = result.CurrCode;
				EcReporting = result.EcReporting;
				LotGenExp = result.LotGenExp;
				SerialLength = result.SerialLength;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemBFlushLocSp(string Item,
		                           string Loc,
		                           ref string Infobar,
		                           [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemBFlushLocExt = new ItemBFlushLocFactory().Create(appDb);
				
				var result = iItemBFlushLocExt.ItemBFlushLocSp(Item,
				                                               Loc,
				                                               Infobar,
				                                               PSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemJobCheckSp(string Item,
		                          byte? LotTracked,
		                          ref string Infobar,
		                          [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemJobCheckExt = new ItemJobCheckFactory().Create(appDb);
				
				var result = iItemJobCheckExt.ItemJobCheckSp(Item,
				                                             LotTracked,
				                                             Infobar,
				                                             PSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateProdCodeSp(ref string ProductCode,
		                              string Whse,
		                              ref short? TaxFreeDays,
		                              ref string Infobar,
		                              [Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateProdCodeExt = new ValidateProdCodeFactory().Create(appDb);
				
				var result = iValidateProdCodeExt.ValidateProdCodeSp(ProductCode,
				                                                     Whse,
				                                                     TaxFreeDays,
				                                                     Infobar,
				                                                     PSite);
				
				int Severity = result.ReturnCode.Value;
				ProductCode = result.ProductCode;
				TaxFreeDays = result.TaxFreeDays;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_ItemsWithExceptionsOnProjectsSp([Optional] string ProjMgr,
		[Optional] string FilterString,
		string SiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_ItemsWithExceptionsOnProjectsExt = new CLM_ItemsWithExceptionsOnProjectsFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_ItemsWithExceptionsOnProjectsExt.CLM_ItemsWithExceptionsOnProjectsSp(ProjMgr,
				FilterString,
				SiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemInsUpdRemCallSP(string Site,
		ref string Item,
		[Optional] string AbcCode,
		[Optional, DefaultParameterValue(0)] int? AcceptReq,
		[Optional, DefaultParameterValue(0)] int? ActiveForCustomerPortal,
		[Optional, DefaultParameterValue(0)] int? ActiveForDataIntegration,
		[Optional] string AltItem,
		[Optional] string AutoJob,
		[Optional, DefaultParameterValue(0)] int? Backflush,
		[Optional] string BflushLoc,
		[Optional] string Buyer,
		[Optional] string CfgModel,
		[Optional] string Charfld1,
		[Optional] string Charfld2,
		[Optional] string Charfld3,
		[Optional] DateTime? ChgDate,
		[Optional] string CommCode,
		[Optional] string CostMethod,
		[Optional] string CostType,
		[Optional] decimal? CurUCost,
		[Optional] DateTime? Datefld,
		[Optional] int? DaysSupply,
		[Optional] decimal? Decifld1,
		[Optional] decimal? Decifld2,
		[Optional] decimal? Decifld3,
		[Optional] string Description,
		[Optional] int? DockTime,
		[Optional] string DrawingNbr,
		[Optional] int? DuePeriod,
		[Optional] DateTime? EarliestPlannedPoReceipt,
		[Optional] int? ExpLeadTime,
		[Optional] string FamilyCode,
		[Optional] string FeatStr,
		[Optional] string FeatTempl,
		[Optional, DefaultParameterValue(0)] int? Featured,
		[Optional] decimal? FixedOrderQty,
		[Optional, DefaultParameterValue(0)] int? InfinitePart,
		[Optional] decimal? InventoryLclTolerance,
		[Optional] decimal? InventoryUclTolerance,
		[Optional, DefaultParameterValue("LOT")] string IssueBy,
		[Optional] string Job,
		[Optional, DefaultParameterValue(0)] int? JobConfigurable,
		[Optional, DefaultParameterValue(0)] int? Kit,
		[Optional] int? LeadTime,
		[Optional] int? Logifld,
		[Optional] string LotPrefix,
		[Optional] decimal? LotSize,
		[Optional, DefaultParameterValue(0)] int? LotTracked,
		[Optional] int? LowLevel,
		[Optional] string MatlType,
		[Optional, DefaultParameterValue(0)] int? MpsFlag,
		[Optional] int? MpsPlanFence,
		[Optional, DefaultParameterValue(0)] int? MrpPart,
		[Optional, DefaultParameterValue(0)] int? OrderConfigurable,
		[Optional] decimal? OrderMax,
		[Optional] decimal? OrderMin,
		[Optional] decimal? OrderMult,
		[Optional] string Origin,
		[Optional] string Overview,
		[Optional] int? PaperTime,
		[Optional, DefaultParameterValue(0)] int? PassReq,
		[Optional, DefaultParameterValue(0)] int? PhantomFlag,
		[Optional] string PlanCode,
		[Optional, DefaultParameterValue(0)] int? PlanFlag,
		[Optional] string PMTCode,
		[Optional, DefaultParameterValue(0)] int? PrintKitComponents,
		[Optional] string ProdMix,
		[Optional] string ProdType,
		[Optional] string ProductCode,
		[Optional] decimal? QtyAllocjob,
		[Optional] decimal? RatePerDay,
		[Optional] decimal? RcvdOverPoQtyTolerance,
		[Optional] decimal? RcvdUnderPoQtyTolerance,
		[Optional] string ReasonCode,
		[Optional] decimal? ReorderPoint,
		[Optional, DefaultParameterValue(0)] int? Reservable,
		[Optional] string Revision,
		[Optional] decimal? SafetyStockPercent,
		[Optional] int? SerialLength,
		[Optional] string SerialPrefix,
		[Optional, DefaultParameterValue(0)] int? SerialTracked,
		[Optional] string Setupgroup,
		[Optional] int? ShelfLife,
		[Optional, DefaultParameterValue(0)] int? ShowInDropDownList,
		[Optional] decimal? ShrinkFact,
		[Optional] string Stat,
		[Optional] string StatusChgUserCode,
		[Optional, DefaultParameterValue(0)] int? Stocked,
		[Optional] int? Suffix,
		[Optional] string SupplySite,
		[Optional] decimal? SupplyToleranceHrs,
		[Optional] string SupplyWhse,
		[Optional] string TariffClassification,
		[Optional] int? TaxFreeDays,
		[Optional, DefaultParameterValue(0)] int? TaxFreeMatl,
		[Optional, DefaultParameterValue(0)] int? TimeFenceRule,
		[Optional] decimal? TimeFenceValue,
		[Optional, DefaultParameterValue(0)] int? TopSeller,
		[Optional, DefaultParameterValue(0)] int? TrackEcn,
		[Optional] string UM,
		[Optional] decimal? UnitCost,
		[Optional] decimal? UnitWeight,
		[Optional, DefaultParameterValue(0)] int? UseReorderPoint,
		[Optional] decimal? VarExpLead,
		[Optional] decimal? VarLead,
		[Optional] string WeightUnits,
		[Optional, DefaultParameterValue(0)] int? SaveCurrentRevUponBomImport,
		[Optional, DefaultParameterValue(0)] int? PreassignLots,
		[Optional, DefaultParameterValue(0)] int? PreassignSerials,
		[Optional, DefaultParameterValue(0)] int? SubjectToExciseTax,
		[Optional, DefaultParameterValue(0)] decimal? ExciseTaxPercent,
		[Optional, DefaultParameterValue(0)] int? AllowOnPickList,
		[Optional, DefaultParameterValue("I")] string FlagInsertUpdate,
		[Optional] ref DateTime? RecordDate,
		[Optional] string NAFTACountryOfOrigin,
        [Optional] string NAFTAPreferenceCriterion,
		[Optional] decimal? Length,
		[Optional] decimal? Width,
		[Optional] decimal? Height,
		[Optional] string DimensionUM,
		[Optional] string PackageType,
		[Optional] decimal? PackageTypeMaxQty,
		[Optional, DefaultParameterValue(0)] int? Hazard,
		[Optional] string ShippingName,
		[Optional] string UNNum,
		[Optional] string HazardousMatlPackageGroup,
		[Optional] string HazardousMatlClass,
		[Optional] string HazmatContact,
		[Optional] string HazmatContactPhone,
		[Optional, DefaultParameterValue(0)] int? HazmatPlacardRequired,
		[Optional] string NationalMotorFreightClass,
		[Optional] string FreightClass)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemInsUpdRemCallExt = new ItemInsUpdRemCallFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemInsUpdRemCallExt.ItemInsUpdRemCallSP(Site,
				Item,
				AbcCode,
				AcceptReq,
				ActiveForCustomerPortal,
				ActiveForDataIntegration,
				AltItem,
				AutoJob,
				Backflush,
				BflushLoc,
				Buyer,
				CfgModel,
				Charfld1,
				Charfld2,
				Charfld3,
				ChgDate,
				CommCode,
				CostMethod,
				CostType,
				CurUCost,
				Datefld,
				DaysSupply,
				Decifld1,
				Decifld2,
				Decifld3,
				Description,
				DockTime,
				DrawingNbr,
				DuePeriod,
				EarliestPlannedPoReceipt,
				ExpLeadTime,
				FamilyCode,
				FeatStr,
				FeatTempl,
				Featured,
				FixedOrderQty,
				InfinitePart,
				InventoryLclTolerance,
				InventoryUclTolerance,
				IssueBy,
				Job,
				JobConfigurable,
				Kit,
				LeadTime,
				Logifld,
				LotPrefix,
				LotSize,
				LotTracked,
				LowLevel,
				MatlType,
				MpsFlag,
				MpsPlanFence,
				MrpPart,
				OrderConfigurable,
				OrderMax,
				OrderMin,
				OrderMult,
				Origin,
				Overview,
				PaperTime,
				PassReq,
				PhantomFlag,
				PlanCode,
				PlanFlag,
				PMTCode,
				PrintKitComponents,
				ProdMix,
				ProdType,
				ProductCode,
				QtyAllocjob,
				RatePerDay,
				RcvdOverPoQtyTolerance,
				RcvdUnderPoQtyTolerance,
				ReasonCode,
				ReorderPoint,
				Reservable,
				Revision,
				SafetyStockPercent,
				SerialLength,
				SerialPrefix,
				SerialTracked,
				Setupgroup,
				ShelfLife,
				ShowInDropDownList,
				ShrinkFact,
				Stat,
				StatusChgUserCode,
				Stocked,
				Suffix,
				SupplySite,
				SupplyToleranceHrs,
				SupplyWhse,
				TariffClassification,
				TaxFreeDays,
				TaxFreeMatl,
				TimeFenceRule,
				TimeFenceValue,
				TopSeller,
				TrackEcn,
				UM,
				UnitCost,
				UnitWeight,
				UseReorderPoint,
				VarExpLead,
				VarLead,
				WeightUnits,
				SaveCurrentRevUponBomImport,
				PreassignLots,
				PreassignSerials,
				SubjectToExciseTax,
				ExciseTaxPercent,
				AllowOnPickList,
				FlagInsertUpdate,
				RecordDate,
				NAFTACountryOfOrigin,
                NAFTAPreferenceCriterion,
				Length,
				Width,
				Height,
				DimensionUM,
				PackageType,
				PackageTypeMaxQty,
				Hazard,
				ShippingName,
				UNNum,
				HazardousMatlPackageGroup,
				HazardousMatlClass,
				HazmatContact,
				HazmatContactPhone,
				HazmatPlacardRequired,
				NationalMotorFreightClass,
				FreightClass);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				RecordDate = result.RecordDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemInsUpdValidatorRemSP(string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemInsUpdValidatorRemExt = new ItemInsUpdValidatorRemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemInsUpdValidatorRemExt.ItemInsUpdValidatorRemSP(Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckTaxFreeMatlItemSp([Optional] string Item,
		string CallFrom,
		ref int? DisableEnable,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckTaxFreeMatlItemExt = new CheckTaxFreeMatlItemFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckTaxFreeMatlItemExt.CheckTaxFreeMatlItemSp(Item,
				CallFrom,
				DisableEnable,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				DisableEnable = result.DisableEnable;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DistAcctExistsSp(string Whse,
		string ProductCode,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iDistAcctExistsExt = new DistAcctExistsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iDistAcctExistsExt.DistAcctExistsSp(Whse,
				ProductCode,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetItemParSp(ref string ApsParmApsmode,
		ref int? TrackTaxFreeimports,
		ref string RUserCode,
		ref decimal? POToleranceOver,
		ref decimal? POToleranceUnder,
		ref int? Vchrauthorize,
		ref decimal? VchrOverPoCostTolerance,
		ref decimal? VchrUnderPoCostTolerance,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemParExt = new GetItemParFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemParExt.GetItemParSp(ApsParmApsmode,
				TrackTaxFreeimports,
				RUserCode,
				POToleranceOver,
				POToleranceUnder,
				Vchrauthorize,
				VchrOverPoCostTolerance,
				VchrUnderPoCostTolerance,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				ApsParmApsmode = result.ApsParmApsmode;
				TrackTaxFreeimports = result.TrackTaxFreeimports;
				RUserCode = result.RUserCode;
				POToleranceOver = result.POToleranceOver;
				POToleranceUnder = result.POToleranceUnder;
				Vchrauthorize = result.Vchrauthorize;
				VchrOverPoCostTolerance = result.VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance;
				Infobar = result.Infobar;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable GetItemsPriceForCustItemSp([Optional] string CustItem,
		[Optional] string CustNum,
		[Optional] string Item,
		[Optional] string SiteRef,
		string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetItemsPriceForCustItemExt = new GetItemsPriceForCustItemFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetItemsPriceForCustItemExt.GetItemsPriceForCustItemSp(CustItem,
				CustNum,
				Item,
				SiteRef,
				Infobar);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetPurchasingParmsSp(ref decimal? POToleranceOver,
		ref decimal? POToleranceUnder,
		ref int? Vchrauthorize,
		ref decimal? VchrOverPoCostTolerance,
		ref decimal? VchrUnderPoCostTolerance,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGetPurchasingParmsExt = new GetPurchasingParmsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGetPurchasingParmsExt.GetPurchasingParmsSp(POToleranceOver,
				POToleranceUnder,
				Vchrauthorize,
				VchrOverPoCostTolerance,
				VchrUnderPoCostTolerance,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				POToleranceOver = result.POToleranceOver;
				POToleranceUnder = result.POToleranceUnder;
				Vchrauthorize = result.Vchrauthorize;
				VchrOverPoCostTolerance = result.VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GetTaxFreeDaysSp(string ProdCode,
		ref int? TaxFreeDays,
		[Optional] string PSite)
		{
			var iGetTaxFreeDaysExt = new GetTaxFreeDaysFactory().Create(this, true);
			
			var result = iGetTaxFreeDaysExt.GetTaxFreeDaysSp(ProdCode,
			TaxFreeDays,
			PSite);
			
			int Severity = result.ReturnCode.Value;
			TaxFreeDays = result.TaxFreeDays;
			return Severity;
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemEnableFormSp(ref int? use_wholesale_price,
		ref int? use_backflush,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemEnableFormExt = new ItemEnableFormFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemEnableFormExt.ItemEnableFormSp(use_wholesale_price,
				use_backflush,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				use_wholesale_price = result.use_wholesale_price;
				use_backflush = result.use_backflush;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemExtraInitSp(ref string LotPrefix,
		ref int? LotTracked,
		ref string IssueBy,
		ref int? SerialTracked,
		ref string SerialPrefix,
		ref string CostType,
		string PSite,
		ref int? PreassignLots,
		ref int? PreassignSerials)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemExtraInitExt = new ItemExtraInitFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemExtraInitExt.ItemExtraInitSp(LotPrefix,
				LotTracked,
				IssueBy,
				SerialTracked,
				SerialPrefix,
				CostType,
				PSite,
				PreassignLots,
				PreassignSerials);
				
				int Severity = result.ReturnCode.Value;
				LotPrefix = result.LotPrefix;
				LotTracked = result.LotTracked;
				IssueBy = result.IssueBy;
				SerialTracked = result.SerialTracked;
				SerialPrefix = result.SerialPrefix;
				CostType = result.CostType;
				PreassignLots = result.PreassignLots;
				PreassignSerials = result.PreassignSerials;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemPreDisplaySp(ref int? CanUpdateRevTrack,
		ref string ApsParmApsmode,
		ref int? TrackTaxFreeimports,
		ref string RUserCode,
		ref decimal? POToleranceOver,
		ref decimal? POToleranceUnder,
		ref int? Vchrauthorize,
		ref decimal? VchrOverPoCostTolerance,
		ref decimal? VchrUnderPoCostTolerance,
		ref int? use_wholesale_price,
		ref int? use_backflush,
		ref string ConfigServerId,
		ref string ConfigHeaderNameSpace,
		ref string Configurator,
		ref string ConfiguratorURL,
		ref string ConfigDeploymentPath,
		ref int? AvailCfg,
		ref int? AllowFcstBomSupplyItems,
		ref string Infobar,
		[Optional] string PSite,
		[Optional] ref int? CostItemAtWhse,
		[Optional] ref string LinearDimensionUM,
		[Optional] ref string DensityUM,
		[Optional] ref string AreaUM,
		[Optional] ref string BulkMassUM,
		[Optional] ref string ReamMassUM,
		[Optional] ref string LotPrefix,
		[Optional] ref int? LotTracked,
		[Optional] ref string IssueBy,
		[Optional] ref int? SerialTracked,
		[Optional] ref string SerialPrefix,
		[Optional] ref string CostType,
		[Optional] ref int? PreassignLots,
		[Optional] ref int? PreassignSerials)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemPreDisplayExt = new ItemPreDisplayFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemPreDisplayExt.ItemPreDisplaySp(CanUpdateRevTrack,
				ApsParmApsmode,
				TrackTaxFreeimports,
				RUserCode,
				POToleranceOver,
				POToleranceUnder,
				Vchrauthorize,
				VchrOverPoCostTolerance,
				VchrUnderPoCostTolerance,
				use_wholesale_price,
				use_backflush,
				ConfigServerId,
				ConfigHeaderNameSpace,
				Configurator,
				ConfiguratorURL,
				ConfigDeploymentPath,
				AvailCfg,
				AllowFcstBomSupplyItems,
				Infobar,
				PSite,
				CostItemAtWhse,
				LinearDimensionUM,
				DensityUM,
				AreaUM,
				BulkMassUM,
				ReamMassUM,
				LotPrefix,
				LotTracked,
				IssueBy,
				SerialTracked,
				SerialPrefix,
				CostType,
				PreassignLots,
				PreassignSerials);
				
				int Severity = result.ReturnCode.Value;
				CanUpdateRevTrack = result.CanUpdateRevTrack;
				ApsParmApsmode = result.ApsParmApsmode;
				TrackTaxFreeimports = result.TrackTaxFreeimports;
				RUserCode = result.RUserCode;
				POToleranceOver = result.POToleranceOver;
				POToleranceUnder = result.POToleranceUnder;
				Vchrauthorize = result.Vchrauthorize;
				VchrOverPoCostTolerance = result.VchrOverPoCostTolerance;
				VchrUnderPoCostTolerance = result.VchrUnderPoCostTolerance;
				use_wholesale_price = result.use_wholesale_price;
				use_backflush = result.use_backflush;
				ConfigServerId = result.ConfigServerId;
				ConfigHeaderNameSpace = result.ConfigHeaderNameSpace;
				Configurator = result.Configurator;
				ConfiguratorURL = result.ConfiguratorURL;
				ConfigDeploymentPath = result.ConfigDeploymentPath;
				AvailCfg = result.AvailCfg;
				AllowFcstBomSupplyItems = result.AllowFcstBomSupplyItems;
				Infobar = result.Infobar;
				CostItemAtWhse = result.CostItemAtWhse;
				LinearDimensionUM = result.LinearDimensionUM;
				DensityUM = result.DensityUM;
				AreaUM = result.AreaUM;
				BulkMassUM = result.BulkMassUM;
				ReamMassUM = result.ReamMassUM;
				LotPrefix = result.LotPrefix;
				LotTracked = result.LotTracked;
				IssueBy = result.IssueBy;
				SerialTracked = result.SerialTracked;
				SerialPrefix = result.SerialPrefix;
				CostType = result.CostType;
				PreassignLots = result.PreassignLots;
				PreassignSerials = result.PreassignSerials;
				return Severity;
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateProductCodeSp(ref string ProductCode,
		string Whse,
		ref string Infobar,
		[Optional] string PSite)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iValidateProductCodeExt = new ValidateProductCodeFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iValidateProductCodeExt.ValidateProductCodeSp(ProductCode,
				Whse,
				Infobar,
				PSite);
				
				int Severity = result.ReturnCode.Value;
				ProductCode = result.ProductCode;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
