//PROJECT NAME: MaterialExt
//CLASS NAME: SLVendConsignmentWhseItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLVendConsignmentWhseItems")]
    public class SLVendConsignmentWhseItems : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AddItemWhseAndLocSp(string Item,
                                       string Whse,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAddItemWhseAndLocExt = new AddItemWhseAndLocFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iAddItemWhseAndLocExt.AddItemWhseAndLocSp(Item,
                                                                         Whse,
                                                                         ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckConsignmentReplenishmentPOSp(string ConsignmentType,
                                                     string ReplenPoNum,
                                                     string VendNum,
                                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckConsignmentReplenishmentPOExt = new CheckConsignmentReplenishmentPOFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCheckConsignmentReplenishmentPOExt.CheckConsignmentReplenishmentPOSp(ConsignmentType,
                                                                                                     ReplenPoNum,
                                                                                                     VendNum,
                                                                                                     ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemCcSetSp(byte? RollBackonProcessCount,
                               string CycleType,
                               short? CycleFreq,
                               DateTime? LastCount,
                               string AbcCode,
                               string BegItem,
                               string EndItem,
                               string BegProductCode,
                               string EndProductCode,
                               string BegPlanCode,
                               string EndPlanCode,
                               string BegWhse,
                               string EndWhse,
                               ref int? ProcessCount,
                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemCcSetExt = new ItemCcSetFactory().Create(appDb);

                IntType oProcessCount = ProcessCount;
                InfobarType oInfobar = Infobar;

                int Severity = iItemCcSetExt.ItemCcSetSp(RollBackonProcessCount,
                                                         CycleType,
                                                         CycleFreq,
                                                         LastCount,
                                                         AbcCode,
                                                         BegItem,
                                                         EndItem,
                                                         BegProductCode,
                                                         EndProductCode,
                                                         BegPlanCode,
                                                         EndPlanCode,
                                                         BegWhse,
                                                         EndWhse,
                                                         ref oProcessCount,
                                                         ref oInfobar);

                ProcessCount = oProcessCount;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemRsvdValidSp(string Whse,
                                   string Item,
                                   ref string CostMethod,
                                   ref string Description,
                                   ref string IssueBy,
                                   ref byte? LotTracked,
                                   ref byte? Reservable,
                                   ref byte? SerialTracked,
                                   ref string UM,
                                   ref decimal? QtyMrb,
                                   ref decimal? QtyOnHand,
                                   ref decimal? QtyRsvdCo,
                                   ref string Infobar,
                                   ref byte? TaxFreeMatl)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemRsvdValidExt = new ItemRsvdValidFactory().Create(appDb);

                CostMethodType oCostMethod = CostMethod;
                DescriptionType oDescription = Description;
                ListLocLotType oIssueBy = IssueBy;
                ListYesNoType oLotTracked = LotTracked;
                ListYesNoType oReservable = Reservable;
                ListYesNoType oSerialTracked = SerialTracked;
                UMType oUM = UM;
                QtyTotlType oQtyMrb = QtyMrb;
                QtyTotlType oQtyOnHand = QtyOnHand;
                QtyTotlType oQtyRsvdCo = QtyRsvdCo;
                InfobarType oInfobar = Infobar;
                ListYesNoType oTaxFreeMatl = TaxFreeMatl;

                int Severity = iItemRsvdValidExt.ItemRsvdValidSp(Whse,
                                                                 Item,
                                                                 ref oCostMethod,
                                                                 ref oDescription,
                                                                 ref oIssueBy,
                                                                 ref oLotTracked,
                                                                 ref oReservable,
                                                                 ref oSerialTracked,
                                                                 ref oUM,
                                                                 ref oQtyMrb,
                                                                 ref oQtyOnHand,
                                                                 ref oQtyRsvdCo,
                                                                 ref oInfobar,
                                                                 ref oTaxFreeMatl);

                CostMethod = oCostMethod;
                Description = oDescription;
                IssueBy = oIssueBy;
                LotTracked = oLotTracked;
                Reservable = oReservable;
                SerialTracked = oSerialTracked;
                UM = oUM;
                QtyMrb = oQtyMrb;
                QtyOnHand = oQtyOnHand;
                QtyRsvdCo = oQtyRsvdCo;
                Infobar = oInfobar;
                TaxFreeMatl = oTaxFreeMatl;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemwhseGetDetailsSp(string Item,
                    string Whse,
                    ref decimal? QtyOnHand,
                    ref decimal? QtyReorder,
                    ref int? CntInProc,
                    ref int? CycleFlag,
                    ref string Loc,
                    ref string Infobar)
        {
            var iItemwhseGetDetailsExt = new ItemwhseGetDetailsFactory().Create(this, true);

            var result = iItemwhseGetDetailsExt.ItemwhseGetDetailsSp(Item,
                Whse,
                QtyOnHand,
                QtyReorder,
                CntInProc,
                CycleFlag,
                Loc,
                Infobar);

            QtyOnHand = result.QtyOnHand;
            QtyReorder = result.QtyReorder;
            CntInProc = result.CntInProc;
            CycleFlag = result.CycleFlag;
            Loc = result.Loc;
            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemwhseValidSp(ref string Whse,
                                   string Item,
                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemwhseValidExt = new ItemwhseValidFactory().Create(appDb);

                WhseType oWhse = Whse;
                InfobarType oInfobar = Infobar;

                int Severity = iItemwhseValidExt.ItemwhseValidSp(ref oWhse,
                                                                 Item,
                                                                 ref oInfobar);

                Whse = oWhse;
                Infobar = oInfobar;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateItemWhseSp(string Item,
		                              string Whse,
		                              ref string Infobar,
		                              ref string PromptMsg,
		                              ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateItemWhseExt = new ValidateItemWhseFactory().Create(appDb);
				
				int Severity = iValidateItemWhseExt.ValidateItemWhseSp(Item,
				                                                       Whse,
				                                                       ref Infobar,
				                                                       ref PromptMsg,
				                                                       ref PromptButtons);
				
				return Severity;
			}
		}








		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemwhseAllValidSp(string ValidationType,
		                              string FromSite,
		                              string FromWhse,
		                              string ToSite,
		                              string ToWhse,
		                              ref string Item,
		                              ref string ItemDescription,
		                              ref string UM,
		                              ref byte? FromSiteSerialTracked,
		                              ref byte? FromSiteLotTracked,
		                              ref byte? ToSiteSerialTracked,
		                              ref byte? ToSiteLotTracked,
		                              ref string FromLoc,
		                              ref string FromLot,
		                              ref string ToLoc,
		                              ref string ToLot,
		                              ref string RemoteFromLotProcess,
		                              ref string RemoteToLotProcess,
		                              ref string ToSiteSerialPrefix,
		                              ref byte? ToSiteExpandSerial,
		                              ref string PromptMsg,
		                              ref string PromptButtons,
		                              ref string Infobar,
		                              ref string ImportDocId,
		                              [Optional, DefaultParameterValue((byte)0)] ref byte? TaxFreeMatl,
		ref string FromLotAttributeGroup,
		ref string ToLotAttributeGroup,
		ref string FromSiteDimensionGroup,
		ref string ToSiteDimensionGroup,
		ref byte? FromSiteTrackPieces,
		ref byte? ToSiteTrackPieces,
		ref string ToSiteLotPrefix,
		ref string FromSiteLotTrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemwhseAllValidExt = new ItemwhseAllValidFactory().Create(appDb);
				
				var result = iItemwhseAllValidExt.ItemwhseAllValidSp(ValidationType,
				                                                     FromSite,
				                                                     FromWhse,
				                                                     ToSite,
				                                                     ToWhse,
				                                                     Item,
				                                                     ItemDescription,
				                                                     UM,
				                                                     FromSiteSerialTracked,
				                                                     FromSiteLotTracked,
				                                                     ToSiteSerialTracked,
				                                                     ToSiteLotTracked,
				                                                     FromLoc,
				                                                     FromLot,
				                                                     ToLoc,
				                                                     ToLot,
				                                                     RemoteFromLotProcess,
				                                                     RemoteToLotProcess,
				                                                     ToSiteSerialPrefix,
				                                                     ToSiteExpandSerial,
				                                                     PromptMsg,
				                                                     PromptButtons,
				                                                     Infobar,
				                                                     ImportDocId,
				                                                     TaxFreeMatl,
				                                                     FromLotAttributeGroup,
				                                                     ToLotAttributeGroup,
				                                                     FromSiteDimensionGroup,
				                                                     ToSiteDimensionGroup,
				                                                     FromSiteTrackPieces,
				                                                     ToSiteTrackPieces,
				                                                     ToSiteLotPrefix,
				                                                     FromSiteLotTrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				ItemDescription = result.ItemDescription;
				UM = result.UM;
				FromSiteSerialTracked = result.FromSiteSerialTracked;
				FromSiteLotTracked = result.FromSiteLotTracked;
				ToSiteSerialTracked = result.ToSiteSerialTracked;
				ToSiteLotTracked = result.ToSiteLotTracked;
				FromLoc = result.FromLoc;
				FromLot = result.FromLot;
				ToLoc = result.ToLoc;
				ToLot = result.ToLot;
				RemoteFromLotProcess = result.RemoteFromLotProcess;
				RemoteToLotProcess = result.RemoteToLotProcess;
				ToSiteSerialPrefix = result.ToSiteSerialPrefix;
				ToSiteExpandSerial = result.ToSiteExpandSerial;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				ImportDocId = result.ImportDocId;
				TaxFreeMatl = result.TaxFreeMatl;
				FromLotAttributeGroup = result.FromLotAttributeGroup;
				ToLotAttributeGroup = result.ToLotAttributeGroup;
				FromSiteDimensionGroup = result.FromSiteDimensionGroup;
				ToSiteDimensionGroup = result.ToSiteDimensionGroup;
				FromSiteTrackPieces = result.FromSiteTrackPieces;
				ToSiteTrackPieces = result.ToSiteTrackPieces;
				ToSiteLotPrefix = result.ToSiteLotPrefix;
				FromSiteLotTrxRestrictCode = result.FromSiteLotTrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemwhseCheckCntInProcSp(string Whse,
		                                    string Item,
		                                    byte? CheckLotTracked,
		                                    byte? CheckSerialTracked,
		                                    string FormTitle,
		                                    ref string Description,
		                                    ref string UM,
		                                    ref byte? ItemSerialTracked,
		                                    ref byte? ItemLotTracked,
		                                    ref decimal? QtyOnHand,
		                                    ref string Infobar,
		                                    [Optional] ref string Prompt,
		                                    [Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemwhseCheckCntInProcExt = new ItemwhseCheckCntInProcFactory().Create(appDb);
				
				var result = iItemwhseCheckCntInProcExt.ItemwhseCheckCntInProcSp(Whse,
				                                                                 Item,
				                                                                 CheckLotTracked,
				                                                                 CheckSerialTracked,
				                                                                 FormTitle,
				                                                                 Description,
				                                                                 UM,
				                                                                 ItemSerialTracked,
				                                                                 ItemLotTracked,
				                                                                 QtyOnHand,
				                                                                 Infobar,
				                                                                 Prompt,
				                                                                 PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Description = result.Description;
				UM = result.UM;
				ItemSerialTracked = result.ItemSerialTracked;
				ItemLotTracked = result.ItemLotTracked;
				QtyOnHand = result.QtyOnHand;
				Infobar = result.Infobar;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int UtilSetIytd(byte? IytdPtd,
		                       byte? IytdYtd,
		                       string BeginItem,
		                       string EndItem,
		                       ref int? CounterItem,
		                       ref int? CounterItemWhse,
		                       ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iUtilSetIytdExt = new UtilSetIytdFactory().Create(appDb);
				
				var result = iUtilSetIytdExt.UtilSetIytdSp(IytdPtd,
				                                           IytdYtd,
				                                           BeginItem,
				                                           EndItem,
				                                           CounterItem,
				                                           CounterItemWhse,
				                                           Infobar);
				
				int Severity = result.ReturnCode.Value;
				CounterItem = result.CounterItem;
				CounterItemWhse = result.CounterItemWhse;
				Infobar = result.Infobar;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RebalItemAllocToOrderSp(ref int? CoitemCount,
		[Optional] string StartingItem,
		[Optional] string EndingItem,
		[Optional] string StartingWhse,
		[Optional] string EndingWhse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRebalItemAllocToOrderExt = new RebalItemAllocToOrderFactory().Create(appDb);
				
				var result = iRebalItemAllocToOrderExt.RebalItemAllocToOrderSp(CoitemCount,
				StartingItem,
				EndingItem,
				StartingWhse,
				EndingWhse);
				
				int Severity = result.ReturnCode.Value;
				CoitemCount = result.CoitemCount;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int RebalItemOnPurchaseOrderSp(ref string Infobar,
		[Optional] string StartingItem,
		[Optional] string EndingItem,
		[Optional] string StartingWhse,
		[Optional] string EndingWhse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iRebalItemOnPurchaseOrderExt = new RebalItemOnPurchaseOrderFactory().Create(appDb);
				
				var result = iRebalItemOnPurchaseOrderExt.RebalItemOnPurchaseOrderSp(Infobar,
				StartingItem,
				EndingItem,
				StartingWhse,
				EndingWhse);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}














		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemInitSp(string PItem,
		string PRecordDate,
		decimal? PLastUnitCost,
		decimal? PAvgMatlCost,
		decimal? PAvgLbrCost,
		decimal? PAvgFovhdCost,
		decimal? PAvgVovhdCost,
		decimal? PAvgOutCost,
		decimal? PAvgUnitCost,
		int? PNextConfig,
		decimal? PUsedYTD,
		decimal? PMfgYTD)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemInitExt = new ItemInitFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemInitExt.ItemInitSp(PItem,
				PRecordDate,
				PLastUnitCost,
				PAvgMatlCost,
				PAvgLbrCost,
				PAvgFovhdCost,
				PAvgVovhdCost,
				PAvgOutCost,
				PAvgUnitCost,
				PNextConfig,
				PUsedYTD,
				PMfgYTD);
				
				int Severity = result.Value;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemwhseValidAllSp(string Item,
		string Whse,
		string Site,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemwhseValidAllExt = new ItemwhseValidAllFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemwhseValidAllExt.ItemwhseValidAllSp(Item,
				Whse,
				Site,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_InventoryBelowSafetyStockSp([Optional, DefaultParameterValue("")] string PMTCodes,
		[Optional] string PlanCode,
		[Optional] string FilterString,
		[Optional] string PSiteGroup)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCLM_InventoryBelowSafetyStockExt = new CLM_InventoryBelowSafetyStockFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCLM_InventoryBelowSafetyStockExt.CLM_InventoryBelowSafetyStockSp(PMTCodes,
				PlanCode,
				FilterString,
				PSiteGroup);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable CLM_TranferLineSummarySp(string Whse,
			string PMTCodes,
			[Optional] string FilterString,
			[Optional] string PSiteGroup)
		{
			var iCLM_TranferLineSummaryExt = new CLM_TranferLineSummaryFactory().Create(this, true);

			var result = iCLM_TranferLineSummaryExt.CLM_TranferLineSummarySp(Whse,
				PMTCodes,
				FilterString,
				PSiteGroup);

			if (result.Data is null)
				return new DataTable();
			else
			{
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				return recordCollectionToDataTable.ToDataTable(result.Data.Items);
			}
		}
		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CanUpdateCostsSp(string PItem,
		string PCostType,
		string PCostMethod,
		string PPMTCode,
		[Optional, DefaultParameterValue("")] string PJob,
		int? PSuffix,
		ref int? PCanUpdateCosts,
		ref int? PCanPromptCost1,
		ref int? PCanPromptCost2,
		ref int? PDisplayUnitCosts,
		ref int? CanUpdateCur,
		[Optional] string Whse)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCanUpdateCostsExt = new CanUpdateCostsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCanUpdateCostsExt.CanUpdateCostsSp(PItem,
				PCostType,
				PCostMethod,
				PPMTCode,
				PJob,
				PSuffix,
				PCanUpdateCosts,
				PCanPromptCost1,
				PCanPromptCost2,
				PDisplayUnitCosts,
				CanUpdateCur,
				Whse);
				
				int Severity = result.ReturnCode.Value;
				PCanUpdateCosts = result.PCanUpdateCosts;
				PCanPromptCost1 = result.PCanPromptCost1;
				PCanPromptCost2 = result.PCanPromptCost2;
				PDisplayUnitCosts = result.PDisplayUnitCosts;
				CanUpdateCur = result.CanUpdateCur;
				return Severity;
			}
		}
    }
}
