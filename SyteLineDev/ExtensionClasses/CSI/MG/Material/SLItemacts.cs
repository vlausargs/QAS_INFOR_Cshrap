//PROJECT NAME: MaterialExt
//CLASS NAME: SLItemacts.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLItemacts")]
    public class SLItemacts : ExtensionClassBase, IExtFTSLItemacts
    {

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetInvAdjAcctFromItemSp(string PItemItem,
                                                   ref string PInvAdjAcct,
                                                   ref string PChartDescription,
                                                   ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new GetInvAdjAcctFromItemFactory().Create(appDb);

                AcctType oPInvAdjAcct = PInvAdjAcct;
                DescriptionType oPChartDescription = PChartDescription;
                Infobar oInfobar = Infobar;

                int Severity = iSLItemactsExt.GetInvAdjAcctFromItemSp(PItemItem,
                                                                      ref oPInvAdjAcct,
                                                                      ref oPChartDescription,
                                                                      ref oInfobar);

                PInvAdjAcct = oPInvAdjAcct;
                PChartDescription = oPChartDescription;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetItemlocAcctsSp(string Item,
                                             string Whse,
                                             ref string InvAcct,
                                             ref string LbrAcct,
                                             ref string FovhdAcct,
                                             ref string VovhdAcct,
                                             ref string OutAcct)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new GetItemlocAcctsFactory().Create(appDb);

                AcctType oInvAcct = InvAcct;
                AcctType oLbrAcct = LbrAcct;
                AcctType oFovhdAcct = FovhdAcct;
                AcctType oVovhdAcct = VovhdAcct;
                AcctType oOutAcct = OutAcct;

                int Severity = iSLItemactsExt.GetItemlocAcctsSp(Item,
                                                                Whse,
                                                                ref oInvAcct,
                                                                ref oLbrAcct,
                                                                ref oFovhdAcct,
                                                                ref oVovhdAcct,
                                                                ref oOutAcct);

                InvAcct = oInvAcct;
                LbrAcct = oLbrAcct;
                FovhdAcct = oFovhdAcct;
                VovhdAcct = oVovhdAcct;
                OutAcct = oOutAcct;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemLifoSnapSp(string ItemlifoItem,
                                          string ItemlifoInvAcct,
                                          string ItemlifoLbrAcct,
                                          string ItemlifoFovhdAcct,
                                          string ItemlifoVovhdAcct,
                                          string ItemlifoOutAcct,
                                          string ItemlifoWhse,
                                          ref Guid? SessionId,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new ItemLifoSnapFactory().Create(appDb);

                RowPointerType oSessionId = SessionId;
                Infobar oInfobar = Infobar;

                int Severity = iSLItemactsExt.ItemLifoSnapSp(ItemlifoItem,
                                                             ItemlifoInvAcct,
                                                             ItemlifoLbrAcct,
                                                             ItemlifoFovhdAcct,
                                                             ItemlifoVovhdAcct,
                                                             ItemlifoOutAcct,
                                                             ItemlifoWhse,
                                                             ref oSessionId,
                                                             ref oInfobar);

                SessionId = oSessionId;
                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MiscIssueGetLotAndLoc(string Whse,
                                                 string Item,
                                                 ref string Loc,
                                                 ref string Lot,
                                                 ref string ImportDocId,
                                                 ref string TrxRestrictCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new MiscIssueGetLotAndLocFactory().Create(appDb);

                LocType oLoc = Loc;
                LotType oLot = Lot;
                ImportDocIdType oImportDocId = ImportDocId;
                TransRestrictionCodeType oTrxRestrictCode = TrxRestrictCode;

                int Severity = iSLItemactsExt.MiscIssueGetLotAndLocSp(Whse,
                                                                    Item,
                                                                    ref oLoc,
                                                                    ref oLot,
                                                                    ref oImportDocId,
                                                                    ref oTrxRestrictCode);

                Loc = oLoc;
                Lot = oLot;
                ImportDocId = oImportDocId;
                TrxRestrictCode = oTrxRestrictCode;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MiscIssueGetLotConvQtyOnHandSp(string Whse,
                                                          string Item,
                                                          string Loc,
                                                          string Lot,
                                                          decimal? QtyIssued,
                                                          string UM,
                                                          string Site,
                                                          ref decimal? LotQtyOnHand,
                                                          ref string PromptMsg,
                                                          ref string PromptButtons,
                                                          ref string Infobar,
                                                          string ImportDocId)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new MiscIssueGetLotConvQtyOnHandFactory().Create(appDb);

                QtyUnitType oLotQtyOnHand = LotQtyOnHand;
                Infobar oPromptMsg = PromptMsg;
                Infobar oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iSLItemactsExt.MiscIssueGetLotConvQtyOnHandSp(Whse,
                                                                             Item,
                                                                             Loc,
                                                                             Lot,
                                                                             QtyIssued,
                                                                             UM,
                                                                             Site,
                                                                             ref oLotQtyOnHand,
                                                                             ref oPromptMsg,
                                                                             ref oPromptButtons,
                                                                             ref oInfobar,
                                                                             ImportDocId);

                LotQtyOnHand = oLotQtyOnHand;
                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MO_JobChangeSp(string Job,
                                   short? Suffix,
                                   string Item,
                                   string Whse,
                                   ref string Loc,
                                   ref string Lot,
                                   ref string TrxRestrictCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new MO_JobChangeFactory().Create(appDb);

                LocType oLoc = Loc;
                LotType oLot = Lot;
                TransRestrictionCodeType oTrxRestrictCode = TrxRestrictCode;

                int Severity = iSLItemactsExt.MO_JobChangeSp(Job,
                                                             Suffix,
                                                             Item,
                                                             Whse,
                                                             ref oLoc,
                                                             ref oLot,
                                                             ref oTrxRestrictCode);

                Loc = oLoc;
                Lot = oLot;
                TrxRestrictCode = oTrxRestrictCode;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int MO_JobScrapPSp(Guid? SessionID,
                                          string PItem,
                                          string PJob,
                                          short? PJobSuffix,
                                          decimal? PQty,
                                          string PUM,
                                          string PWhse,
                                          string PLoc,
                                          DateTime? PTransDate,
                                          string PReason,
                                          string PLot,
                                          string PAccount,
                                          string PUnitCodes1,
                                          string PUnitCodes2,
                                          string PUnitCodes3,
                                          string PUnitCodes4,
                                          string PEmployee,
                                          int? POperNum,
                                          string Pwc,
                                          string PShift,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSLItemactsExt = new MO_JobScrapPFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iSLItemactsExt.MO_JobScrapPSp(SessionID,
                                                             PItem,
                                                             PJob,
                                                             PJobSuffix,
                                                             PQty,
                                                             PUM,
                                                             PWhse,
                                                             PLoc,
                                                             PTransDate,
                                                             PReason,
                                                             PLot,
                                                             PAccount,
                                                             PUnitCodes1,
                                                             PUnitCodes2,
                                                             PUnitCodes3,
                                                             PUnitCodes4,
                                                             PEmployee,
                                                             POperNum,
                                                             Pwc,
                                                             PShift,
                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ItemCostMethodCostTypeValidSp(string CostMethod,
                                                 string CostType,
                                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iItemCostMethodCostTypeValidExt = new ItemCostMethodCostTypeValidFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iItemCostMethodCostTypeValidExt.ItemCostMethodCostTypeValidSp(CostMethod,
                                                                                             CostType,
                                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }





		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ContainerIssuePostSp(string ContainerNum,
		                                DateTime? TransDate,
		                                string AccountCode,
		                                string AcctUnit1,
		                                string AcctUnit2,
		                                string AcctUnit3,
		                                string AcctUnit4,
		                                string ReasonCode,
		                                ref string InfoBar,
		                                [Optional] string CallFrom,
		                                [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iContainerIssuePostExt = new ContainerIssuePostFactory().Create(appDb);
				
				var result = iContainerIssuePostExt.ContainerIssuePostSp(ContainerNum,
				                                                         TransDate,
				                                                         AccountCode,
				                                                         AcctUnit1,
				                                                         AcctUnit2,
				                                                         AcctUnit3,
				                                                         AcctUnit4,
				                                                         ReasonCode,
				                                                         InfoBar,
				                                                         CallFrom,
				                                                         DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				InfoBar = result.InfoBar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MiscIssueGetLocQtyOnHandSp(string Whse,
		                                      string Item,
		                                      string Loc,
		                                      decimal? QtyIssued,
		                                      string Site,
		                                      ref decimal? LocQtyOnHand,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar,
		                                      [Optional, DefaultParameterValue(0)] ref int? CallForm,
		[Optional] string UM)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMiscIssueGetLocQtyOnHandExt = new MiscIssueGetLocQtyOnHandFactory().Create(appDb);
				
				var result = iMiscIssueGetLocQtyOnHandExt.MiscIssueGetLocQtyOnHandSp(Whse,
				                                                                     Item,
				                                                                     Loc,
				                                                                     QtyIssued,
				                                                                     Site,
				                                                                     LocQtyOnHand,
				                                                                     PromptMsg,
				                                                                     PromptButtons,
				                                                                     Infobar,
				                                                                     CallForm,
				                                                                     UM);
				
				int Severity = result.ReturnCode.Value;
				LocQtyOnHand = result.LocQtyOnHand;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int MiscIssueGetLotQtyOnHandSp(string Whse,
		                                      string Item,
		                                      string Loc,
		                                      string Lot,
		                                      decimal? QtyIssued,
		                                      string Site,
		                                      ref decimal? LotQtyOnHand,
		                                      ref string PromptMsg,
		                                      ref string PromptButtons,
		                                      ref string Infobar,
		                                      string ImportDocId,
		                                      [Optional, DefaultParameterValue(0)] ref int? CallForm)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iMiscIssueGetLotQtyOnHandExt = new MiscIssueGetLotQtyOnHandFactory().Create(appDb);
				
				var result = iMiscIssueGetLotQtyOnHandExt.MiscIssueGetLotQtyOnHandSp(Whse,
				                                                                     Item,
				                                                                     Loc,
				                                                                     Lot,
				                                                                     QtyIssued,
				                                                                     Site,
				                                                                     LotQtyOnHand,
				                                                                     PromptMsg,
				                                                                     PromptButtons,
				                                                                     Infobar,
				                                                                     ImportDocId,
				                                                                     CallForm);
				
				int Severity = result.ReturnCode.Value;
				LotQtyOnHand = result.LotQtyOnHand;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				CallForm = result.CallForm;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ValidateItemsActivitySp(string Item,
		                                   [Optional, DefaultParameterValue((byte)1)] byte? WarnIfSlowMoving,
		[Optional, DefaultParameterValue((byte)0)] byte? ErrorIfSlowMoving,
		[Optional, DefaultParameterValue((byte)0)] byte? WarnIfObsolete,
		[Optional, DefaultParameterValue((byte)1)] byte? ErrorIfObsolete,
		ref string Infobar,
		[Optional] ref string PromptObsSlow,
		[Optional] ref string PromptObsSlowButtons,
		[Optional] string Site,
		string Whse,
		byte? CheckLotTracked,
		byte? CheckSerialTracked,
		string FormTitle,
		ref string Description,
		ref string UM,
		ref byte? ItemSerialTracked,
		ref byte? ItemLotTracked,
		ref decimal? QtyOnHand,
		[Optional] ref string PromptCheckCntIn,
		[Optional] ref string PromptCheckCntInButtons,
		ref string Loc,
		ref string Lot,
		ref string ImportDocId,
		[Optional] ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iValidateItemsActivityExt = new ValidateItemsActivityFactory().Create(appDb);
				
				var result = iValidateItemsActivityExt.ValidateItemsActivitySp(Item,
				                                                               WarnIfSlowMoving,
				                                                               ErrorIfSlowMoving,
				                                                               WarnIfObsolete,
				                                                               ErrorIfObsolete,
				                                                               Infobar,
				                                                               PromptObsSlow,
				                                                               PromptObsSlowButtons,
				                                                               Site,
				                                                               Whse,
				                                                               CheckLotTracked,
				                                                               CheckSerialTracked,
				                                                               FormTitle,
				                                                               Description,
				                                                               UM,
				                                                               ItemSerialTracked,
				                                                               ItemLotTracked,
				                                                               QtyOnHand,
				                                                               PromptCheckCntIn,
				                                                               PromptCheckCntInButtons,
				                                                               Loc,
				                                                               Lot,
				                                                               ImportDocId,
				                                                               TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				PromptObsSlow = result.PromptObsSlow;
				PromptObsSlowButtons = result.PromptObsSlowButtons;
				Description = result.Description;
				UM = result.UM;
				ItemSerialTracked = result.ItemSerialTracked;
				ItemLotTracked = result.ItemLotTracked;
				QtyOnHand = result.QtyOnHand;
				PromptCheckCntIn = result.PromptCheckCntIn;
				PromptCheckCntInButtons = result.PromptCheckCntInButtons;
				Loc = result.Loc;
				Lot = result.Lot;
				ImportDocId = result.ImportDocId;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}










		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ConsignUsageGetLotAndLocSp(string CurrWhse,
		string Item,
		string ConsignWhse,
		string ConsignLoc,
		ref string Loc,
		ref string Lot,
		ref string ImportDocId,
		ref string TrxRestrictCode)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iConsignUsageGetLotAndLocExt = new ConsignUsageGetLotAndLocFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iConsignUsageGetLotAndLocExt.ConsignUsageGetLotAndLocSp(CurrWhse,
				Item,
				ConsignWhse,
				ConsignLoc,
				Loc,
				Lot,
				ImportDocId,
				TrxRestrictCode);
				
				int Severity = result.ReturnCode.Value;
				Loc = result.Loc;
				Lot = result.Lot;
				ImportDocId = result.ImportDocId;
				TrxRestrictCode = result.TrxRestrictCode;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemLifoSp(int? Delete,
		string ItemlifoItem,
		DateTime? ItemlifoTransDate,
		decimal? ItemlifoQty,
		decimal? ItemlifoUnitCost,
		decimal? ItemlifoMatlCost,
		decimal? ItemlifoLbrCost,
		decimal? ItemlifoFovhdCost,
		decimal? ItemlifoVovhdCost,
		decimal? ItemlifoOutCost,
		string ItemlifoInvAcct,
		string ItemlifoLbrAcct,
		string ItemlifoFovhdAcct,
		string ItemlifoVovhdAcct,
		string ItemlifoOutAcct,
		Guid? ItemlifoRowPointer,
		string ItemlifoRecordDate,
		string ItemlifoWhse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemLifoExt = new ItemLifoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemLifoExt.ItemLifoSp(Delete,
				ItemlifoItem,
				ItemlifoTransDate,
				ItemlifoQty,
				ItemlifoUnitCost,
				ItemlifoMatlCost,
				ItemlifoLbrCost,
				ItemlifoFovhdCost,
				ItemlifoVovhdCost,
				ItemlifoOutCost,
				ItemlifoInvAcct,
				ItemlifoLbrAcct,
				ItemlifoFovhdAcct,
				ItemlifoVovhdAcct,
				ItemlifoOutAcct,
				ItemlifoRowPointer,
				ItemlifoRecordDate,
				ItemlifoWhse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ItemOrCustItemLovSp(int? CIFlag,
		string CustNum,
		string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemOrCustItemLovExt = new ItemOrCustItemLovFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemOrCustItemLovExt.ItemOrCustItemLovSp(CIFlag,
				CustNum,
				Item);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
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
		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable ItemOrCustItemLov(int? CIFlag,
		string CustNum,
		string Item)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemOrCustItemLovExt = new ItemOrCustItemLovFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemOrCustItemLovExt.ItemOrCustItemLovSp(CIFlag,
				CustNum,
				Item);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}
    }
}
