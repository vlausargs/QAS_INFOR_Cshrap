//PROJECT NAME: FSPlusSROExt
//CLASS NAME: FSSROs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.FieldService.Requests;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.FSPlusSRO
{
    [IDOExtensionClass("FSSROs")]
    public class FSSROs : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSApsSyncDeferSp(ref string Infobar)
        {
            var iSSSFSApsSyncDeferExt = new SSSFSApsSyncDeferFactory().Create(this, true);
        
            var result = iSSSFSApsSyncDeferExt.SSSFSApsSyncDeferSp(Infobar);
        
            Infobar = result.Infobar;
        
            return result.ReturnCode ?? 0;
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSerialCheckSp(string SerNum,
        ref string Prompt,
        ref string Infobar,
        string Item)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSerialCheckExt = new SSSFSSerialCheckFactory().Create(appDb);

                var result = iSSSFSSerialCheckExt.SSSFSSerialCheckSp(SerNum,
                Prompt,
                Infobar,
                Item);

                int Severity = result.ReturnCode.Value;
                Prompt = result.Prompt;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROTypeDefaultsSp(ref string ProductCode,
        ref string Whse,
        ref string BillCode,
        ref string BillType,
        ref string CGSLabor,
        ref string CGSMatl,
        ref string CGSMisc,
        ref byte? AccumWIP,
        ref byte? InclDemand,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROTypeDefaultsExt = new SSSFSSROTypeDefaultsFactory().Create(appDb);

                var result = iSSSFSSROTypeDefaultsExt.SSSFSSROTypeDefaultsSp(ProductCode,
                Whse,
                BillCode,
                BillType,
                CGSLabor,
                CGSMatl,
                CGSMisc,
                AccumWIP,
                InclDemand,
                Infobar);

                int Severity = result.ReturnCode.Value;
                ProductCode = result.ProductCode;
                Whse = result.Whse;
                BillCode = result.BillCode;
                BillType = result.BillType;
                CGSLabor = result.CGSLabor;
                CGSMatl = result.CGSMatl;
                CGSMisc = result.CGSMisc;
                AccumWIP = result.AccumWIP;
                InclDemand = result.InclDemand;
                Infobar = result.Infobar;
                return Severity;
            }
        }

        
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROStoreVarsSp(string Var1Name,
                                        string Var1Value,
                                        string Var2Name,
                                        string Var2Value,
                                        string Var3Name,
                                        string Var3Value,
                                        string Var4Name,
                                        string Var4Value,
                                        string Var5Name,
                                        string Var5Value,
                                        string Var6Name,
                                        string Var6Value,
                                        string Var7Name,
                                        string Var7Value,
                                        string Var8Name,
                                        string Var8Value,
                                        string Var9Name,
                                        string Var9Value,
                                        string Var10Name,
                                        string Var10Value)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROStoreVarsExt = new SSSFSSROStoreVarsFactory().Create(appDb);

                int Severity = iSSSFSSROStoreVarsExt.SSSFSSROStoreVarsSp(Var1Name,
                                                                         Var1Value,
                                                                         Var2Name,
                                                                         Var2Value,
                                                                         Var3Name,
                                                                         Var3Value,
                                                                         Var4Name,
                                                                         Var4Value,
                                                                         Var5Name,
                                                                         Var5Value,
                                                                         Var6Name,
                                                                         Var6Value,
                                                                         Var7Name,
                                                                         Var7Value,
                                                                         Var8Name,
                                                                         Var8Value,
                                                                         Var9Name,
                                                                         Var9Value,
                                                                         Var10Name,
                                                                         Var10Value);

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroStatOpenSp(string iSro_Num,
                                       int? iSro_Line,
                                       int? iSro_Oper,
                                       string iSro_Stat,
                                       string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSroStatOpenExt = new SSSFSSroStatOpenFactory().Create(appDb);

                int Severity = iSSSFSSroStatOpenExt.SSSFSSroStatOpenSp(iSro_Num,
                                                                       iSro_Line,
                                                                       iSro_Oper,
                                                                       iSro_Stat,
                                                                       Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROGetFirstOpenLineSp(string iSroNum,
                                               int? iSroLine,
                                               ref int? oSroLine,
                                               ref int? oSroOper,
                                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROGetFirstOpenLineExt = new SSSFSSROGetFirstOpenLineFactory().Create(appDb);

                int Severity = iSSSFSSROGetFirstOpenLineExt.SSSFSSROGetFirstOpenLineSp(iSroNum,
                                                                                       iSroLine,
                                                                                       ref oSroLine,
                                                                                       ref oSroOper,
                                                                                       ref Infobar);

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSROCustPoExistsWarningSp(string SroNum,
                                                  string CustPo,
                                                  string CustNum,
                                                  ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSROCustPoExistsWarningExt = new SSSFSSROCustPoExistsWarningFactory().Create(appDb);

                int Severity = iSSSFSSROCustPoExistsWarningExt.SSSFSSROCustPoExistsWarningSp(SroNum,
                                                                                             CustPo,
                                                                                             CustNum,
                                                                                             ref Infobar);

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSSroCopyDefaultSp(string RefType,
                                          ref string oDefSroTemplate,
                                          ref string oSroLabel,
                                          ref string oSroNumLabel,
                                          ref byte? oDefAutoSchedSro,
                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSSroCopyDefaultExt = new SSSFSSroCopyDefaultFactory().Create(appDb);

                int Severity = iSSSFSSroCopyDefaultExt.SSSFSSroCopyDefaultSp(RefType,
                                                                             ref oDefSroTemplate,
                                                                             ref oSroLabel,
                                                                             ref oSroNumLabel,
                                                                             ref oDefAutoSchedSro,
                                                                             ref Infobar);

                return Severity;
            }
        }
        
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSMultiSiteSroCopySp(string iToSite,
                                           string iFromSroNum,
                                           string iToSroNum,
                                           byte? iCloseSourceSro,
                                           byte? iDeleteSourceSro,
                                           byte? iCopyNotes,
                                           string iValSroType,
                                           string iValSlsman,
                                           string iValPartner,
                                           string iValOperCode,
                                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSMultiSiteSroCopyExt = new SSSFSMultiSiteSroCopyFactory().Create(appDb);

                Infobar oInfobar = Infobar;

                int Severity = iSSSFSMultiSiteSroCopyExt.SSSFSMultiSiteSroCopySp(iToSite,
                                                                                 iFromSroNum,
                                                                                 iToSroNum,
                                                                                 iCloseSourceSro,
                                                                                 iDeleteSourceSro,
                                                                                 iCopyNotes,
                                                                                 iValSroType,
                                                                                 iValSlsman,
                                                                                 iValPartner,
                                                                                 iValOperCode,
                                                                                 ref oInfobar);

                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSGetUnitItemSp(string Unit,
                                      ref string Item,
                                      ref string CustNum,
                                      ref int? CustSeq,
                                      ref string CustName,
                                      ref byte? CreditHold,
                                      ref string CreditHoldReason,
                                      ref string CreditHoldDesc,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSGetUnitItemExt = new SSSFSGetUnitItemFactory().Create(appDb);

                ItemType oItem = Item;
                CustNumType oCustNum = CustNum;
                CustSeqType oCustSeq = CustSeq;
                NameType oCustName = CustName;
                ListYesNoType oCreditHold = CreditHold;
                ReasonCodeType oCreditHoldReason = CreditHoldReason;
                DescriptionType oCreditHoldDesc = CreditHoldDesc;
                InfobarType oInfobar = Infobar;

                int Severity = iSSSFSGetUnitItemExt.SSSFSGetUnitItemSp(Unit,
                                                                       ref oItem,
                                                                       ref oCustNum,
                                                                       ref oCustSeq,
                                                                       ref oCustName,
                                                                       ref oCreditHold,
                                                                       ref oCreditHoldReason,
                                                                       ref oCreditHoldDesc,
                                                                       ref oInfobar);

                Item = oItem;
                CustNum = oCustNum;
                CustSeq = oCustSeq;
                CustName = oCustName;
                CreditHold = oCreditHold;
                CreditHoldReason = oCreditHoldReason;
                CreditHoldDesc = oCreditHoldDesc;
                Infobar = oInfobar;

                return Severity;
            }
        }
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSGetConsumerCustSp(string iUsrNum,
                                          ref string oCustNum)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSGetConsumerCustExt = new SSSFSGetConsumerCustFactory().Create(appDb);

                CustNumType ooCustNum = oCustNum;

                int Severity = iSSSFSGetConsumerCustExt.SSSFSGetConsumerCustSp(iUsrNum,
                                                                               ref ooCustNum);

                oCustNum = ooCustNum;

                return Severity;
            }
        }
        
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSFSCustNumVarCreditSp(string CustNum,
                                           ref int? CustSeq,
                                           ref string CustName,
                                           ref byte? CreditHold,
                                           ref string CreditHoldReason,
                                           ref string CreditHoldDescription)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSFSCustNumVarCreditExt = new SSSFSCustNumVarCreditFactory().Create(appDb);

                CustSeqType oCustSeq = CustSeq;
                NameType oCustName = CustName;
                ListYesNoType oCreditHold = CreditHold;
                ReasonCodeType oCreditHoldReason = CreditHoldReason;
                DescriptionType oCreditHoldDescription = CreditHoldDescription;

                int Severity = iSSSFSCustNumVarCreditExt.SSSFSCustNumVarCreditSp(CustNum,
                                                                                 ref oCustSeq,
                                                                                 ref oCustName,
                                                                                 ref oCreditHold,
                                                                                 ref oCreditHoldReason,
                                                                                 ref oCreditHoldDescription);

                CustSeq = oCustSeq;
                CustName = oCustName;
                CreditHold = oCreditHold;
                CreditHoldReason = oCreditHoldReason;
                CreditHoldDescription = oCreditHoldDescription;

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSApsSyncImmediateSp(ref string Infobar,
		                                   [Optional, DefaultParameterValue(0)] int? DropDeferred)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSApsSyncImmediateExt = new SSSFSApsSyncImmediateFactory().Create(appDb);
				
				int Severity = iSSSFSApsSyncImmediateExt.SSSFSApsSyncImmediateSp(ref Infobar,
				                                                                 DropDeferred);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSFormatNewSROSp(string SroNum,
		                               ref string NewSroNum,
		                               ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSFormatNewSROExt = new SSSFSFormatNewSROFactory().Create(appDb);
				
				int Severity = iSSSFSFormatNewSROExt.SSSFSFormatNewSROSp(SroNum,
				                                                         ref NewSroNum,
				                                                         ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSRODefaultsSp(ref string SROType,
		                              ref string SROTypeDesc,
		                              ref string ProductCode,
		                              ref string ProductCodeDesc,
		                              ref string Whse,
		                              ref string WhseName,
		                              ref string BillCode,
		                              ref string BillType,
		                              ref string CGSLabor,
		                              ref string CGSMatl,
		                              ref string CGSMisc,
		                              ref decimal? Disc,
		                              ref byte? AccumWIP,
		                              ref byte? InclDemand,
		                              ref byte? AllowPartial,
		                              ref byte? PlanTransReq,
		                              ref byte? UsePlanPricing,
		                              ref byte? UseEndUserTypes,
		                              ref byte? UseConsumer,
		                              ref byte? AutoCloseSRO,
		                              ref string PriorCode,
		                              ref string StatCode,
		                              ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSRODefaultsExt = new SSSFSSRODefaultsFactory().Create(appDb);
				
				int Severity = iSSSFSSRODefaultsExt.SSSFSSRODefaultsSp(ref SROType,
				                                                       ref SROTypeDesc,
				                                                       ref ProductCode,
				                                                       ref ProductCodeDesc,
				                                                       ref Whse,
				                                                       ref WhseName,
				                                                       ref BillCode,
				                                                       ref BillType,
				                                                       ref CGSLabor,
				                                                       ref CGSMatl,
				                                                       ref CGSMisc,
				                                                       ref Disc,
				                                                       ref AccumWIP,
				                                                       ref InclDemand,
				                                                       ref AllowPartial,
				                                                       ref PlanTransReq,
				                                                       ref UsePlanPricing,
				                                                       ref UseEndUserTypes,
				                                                       ref UseConsumer,
				                                                       ref AutoCloseSRO,
				                                                       ref PriorCode,
				                                                       ref StatCode,
				                                                       ref Infobar);
				
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROCopyGetUnitInfoSp(string SRONum,
		                                     string SROCustNum,
		                                     int? SROCustSeq,
		                                     string SerNum,
		                                     ref string UnitDesc,
		                                     ref byte? UnitExists,
		                                     ref string UnitCustNum,
		                                     ref int? UnitCustSeq,
		                                     ref string Item,
		                                     ref string ItemDesc,
		                                     ref byte? ItemExists,
		                                     ref string ItemUM,
		                                     ref string PromptMsgBadCust,
		                                     ref string PromptMsgNoUnit,
		                                     ref string Infobar,
		                                     [Optional] ref string UnitUsrNum,
		                                     [Optional] ref int? UnitUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROCopyGetUnitInfoExt = new SSSFSSROCopyGetUnitInfoFactory().Create(appDb);
				
				var result = iSSSFSSROCopyGetUnitInfoExt.SSSFSSROCopyGetUnitInfoSp(SRONum,
				                                                                   SROCustNum,
				                                                                   SROCustSeq,
				                                                                   SerNum,
				                                                                   UnitDesc,
				                                                                   UnitExists,
				                                                                   UnitCustNum,
				                                                                   UnitCustSeq,
				                                                                   Item,
				                                                                   ItemDesc,
				                                                                   ItemExists,
				                                                                   ItemUM,
				                                                                   PromptMsgBadCust,
				                                                                   PromptMsgNoUnit,
				                                                                   Infobar,
				                                                                   UnitUsrNum,
				                                                                   UnitUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				UnitDesc = result.UnitDesc;
				UnitExists = result.UnitExists;
				UnitCustNum = result.UnitCustNum;
				UnitCustSeq = result.UnitCustSeq;
				Item = result.Item;
				ItemDesc = result.ItemDesc;
				ItemExists = result.ItemExists;
				ItemUM = result.ItemUM;
				PromptMsgBadCust = result.PromptMsgBadCust;
				PromptMsgNoUnit = result.PromptMsgNoUnit;
				Infobar = result.Infobar;
				UnitUsrNum = result.UnitUsrNum;
				UnitUsrSeq = result.UnitUsrSeq;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroCopyUseItem(string iTemplateSroNum,
		                               int? iTemplateSroLine,
		                               string iItem,
		                               byte? ChkShowAllOper,
		                               string iSerNum,
		                               string Infobar,
		                               [Optional] string FilterString)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCopyUseItExt_ST = new SSSFSSroCopyUseItFactory_ST().Create(appDb);
				
				var result = iSSSFSSroCopyUseItExt_ST.SSSFSSroCopyUseItem(iTemplateSroNum,
				                                                       iTemplateSroLine,
				                                                       iItem,
				                                                       ChkShowAllOper,
				                                                       iSerNum,
				                                                       Infobar,
				                                                       FilterString);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROInvPrepSp(string SroNum,
		                             string Action,
		                             [Optional] string Value,
		                             ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROInvPrepExt = new SSSFSSROInvPrepFactory().Create(appDb);
				
				var result = iSSSFSSROInvPrepExt.SSSFSSROInvPrepSp(SroNum,
				                                                   Action,
				                                                   Value,
				                                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROSSDDefaultsSp([Optional] string SRONum,
		                                 [Optional] string TransType,
		                                 string DropType,
		                                 string DropNum,
		                                 int? DropSeq,
		                                 ref string EcCode,
		                                 ref string TransNat,
		                                 ref string TransNatDesc,
		                                 ref string Delterm,
		                                 ref string DeltermDesc,
		                                 ref string ProcessInd)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROSSDDefaultsExt = new SSSFSSROSSDDefaultsFactory().Create(appDb);
				
				var result = iSSSFSSROSSDDefaultsExt.SSSFSSROSSDDefaultsSp(SRONum,
				                                                           TransType,
				                                                           DropType,
				                                                           DropNum,
				                                                           DropSeq,
				                                                           EcCode,
				                                                           TransNat,
				                                                           TransNatDesc,
				                                                           Delterm,
				                                                           DeltermDesc,
				                                                           ProcessInd);
				
				int Severity = result.ReturnCode.Value;
				EcCode = result.EcCode;
				TransNat = result.TransNat;
				TransNatDesc = result.TransNatDesc;
				Delterm = result.Delterm;
				DeltermDesc = result.DeltermDesc;
				ProcessInd = result.ProcessInd;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROOperUpdateStatusSp(string SRONum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROOperUpdateStatusExt = new SSSFSSROOperUpdateStatusFactory().Create(appDb);
				
				var result = iSSSFSSROOperUpdateStatusExt.SSSFSSROOperUpdateStatusSp(SRONum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroUpdateTransSp(string poNum,
		short? poLine,
		decimal? newItemCostConv,
		decimal? newQtyOrderedConv,
		string SroType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroUpdateTransExt = new SSSFSSroUpdateTransFactory().Create(appDb);
				
				var result = iSSSFSSroUpdateTransExt.SSSFSSroUpdateTransSp(poNum,
				poLine,
				newItemCostConv,
				newQtyOrderedConv,
				SroType);
				
				
				return result.Value;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSUpdateXrefSroCheckTypeSp(string poNum,
		short? poLine,
		ref string SroType)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSUpdateXrefSroCheckTypeExt = new SSSFSUpdateXrefSroCheckTypeFactory().Create(appDb);
				
				var result = iSSSFSUpdateXrefSroCheckTypeExt.SSSFSUpdateXrefSroCheckTypeSp(poNum,
				poLine,
				SroType);
				
				int Severity = result.ReturnCode.Value;
				SroType = result.SroType;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroCopyCreateSroSp(string iSROCopyLevel,
		string iSROCopyCalledFrom,
		string iSroCopyTransFrom,
		string iSroCopyTransTo,
		string iSroCopyFromKey,
		string iTemplateSroNum,
		int? iTemplateSROLine,
		string iSelectedOpers,
		string iCustNum,
		int? iCustSeq,
		DateTime? iDate,
		string iBillMgr,
		string iSRODesc,
		string iSerNum,
		string iWhse,
		string iItemNum,
		string iUM,
		decimal? iQty,
		string iLineDesc,
		string iLeadPartner,
		string iCompItem,
		decimal? iCompQtyOrd,
		ref string oSRONum,
		ref int? oSROLine,
		ref int? oSROOper,
		ref string Infobar,
		[Optional, DefaultParameterValue((byte)0)] byte? iKeepOperNums,
		[Optional] string iFromRefType,
		[Optional] string iFromRefNum,
		[Optional] int? iFromRefLine,
		[Optional] int? iFromRefRelease,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseSroWhse,
		[Optional] string iSRONum,
		[Optional] int? iConfigCompId,
		[Optional, DefaultParameterValue("O")] string iSroStat,
		[Optional] string iRegion,
		[Optional, DefaultParameterValue((byte)0)] byte? iChkShowAllOpers,
		[Optional, DefaultParameterValue((byte)0)] byte? iKeepLineNums,
		[Optional, DefaultParameterValue((byte)0)] byte? iUseAllOpers,
		[Optional] string iToSite,
		[Optional, DefaultParameterValue(0)] int? iSeq,
		[Optional] string iCustPo,
		[Optional] DateTime? iStartDate,
		[Optional] decimal? iDuration,
		[Optional] string iCustItem,
		[Optional] DateTime? iMaintDate,
		[Optional] decimal? iDownTime,
		[Optional] string iShiftID,
		[Optional] byte? iSchedDownTime,
		[Optional, DefaultParameterValue((byte)0)] byte? iCreateIncident,
		[Optional, DefaultParameterValue((byte)0)] byte? iCopyLineTrans,
		[Optional] string iUsrNum,
		[Optional] int? iUsrSeq)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroCopyCreateSroExt = new SSSFSSroCopyCreateSroFactory().Create(appDb);
				
				var result = iSSSFSSroCopyCreateSroExt.SSSFSSroCopyCreateSroSp(iSROCopyLevel,
				iSROCopyCalledFrom,
				iSroCopyTransFrom,
				iSroCopyTransTo,
				iSroCopyFromKey,
				iTemplateSroNum,
				iTemplateSROLine,
				iSelectedOpers,
				iCustNum,
				iCustSeq,
				iDate,
				iBillMgr,
				iSRODesc,
				iSerNum,
				iWhse,
				iItemNum,
				iUM,
				iQty,
				iLineDesc,
				iLeadPartner,
				iCompItem,
				iCompQtyOrd,
				oSRONum,
				oSROLine,
				oSROOper,
				Infobar,
				iKeepOperNums,
				iFromRefType,
				iFromRefNum,
				iFromRefLine,
				iFromRefRelease,
				iUseSroWhse,
				iSRONum,
				iConfigCompId,
				iSroStat,
				iRegion,
				iChkShowAllOpers,
				iKeepLineNums,
				iUseAllOpers,
				iToSite,
				iSeq,
				iCustPo,
				iStartDate,
				iDuration,
				iCustItem,
				iMaintDate,
				iDownTime,
				iShiftID,
				iSchedDownTime,
				iCreateIncident,
				iCopyLineTrans,
				iUsrNum,
				iUsrSeq);
				
				int Severity = result.ReturnCode.Value;
				oSRONum = result.oSRONum;
				oSROLine = result.oSROLine;
				oSROOper = result.oSROOper;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSroValidCustCurrencySp(string iSroNum,
		[Optional] int? iSroLine,
		[Optional] int? iSroOper,
		ref string iCustNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSroValidCustCurrencyExt = new SSSFSSroValidCustCurrencyFactory().Create(appDb);
				
				var result = iSSSFSSroValidCustCurrencyExt.SSSFSSroValidCustCurrencySp(iSroNum,
				iSroLine,
				iSroOper,
				iCustNum,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				iCustNum = result.iCustNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSSROValidCustSp(string CustNum,
		ref int? CustSeq,
		string Level,
		ref string BillToAddr,
		ref string ShipToAddr,
		ref string BillMgr,
		ref string BillMgrName,
		ref string EndUserType,
		ref string TermsCode,
		ref string Slsman,
		ref string Pricecode,
		ref string ShipCode,
		ref string CurrCode,
		ref byte? FixedEuro,
		ref decimal? ExchRate,
		ref byte? CreditHold,
		ref string TaxCode1,
		ref string TaxCode1Desc,
		ref string TaxCode2,
		ref string TaxCode2Desc,
		ref byte? DepositReq,
		ref byte? ApplyOpenDeposits,
		ref string Region,
		ref string RegionDesc,
		ref string Contact,
		ref string Email,
		ref string Phone,
		ref string Fax,
		ref string PagerAddr,
		ref string TxtMsgAddr,
		ref string Infobar,
		ref string PriorCode,
		[Optional] ref string BillToName,
		[Optional] ref string ShipToName,
		[Optional] ref string NOTC,
		[Optional] ref string DeliveryTerms,
		ref string CurAmtFormat,
		ref string CurCstPrcFormat,
		[Optional] string PriorCustNum,
		[Optional] string SRONum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSFSSROValidCustExt = new SSSFSSROValidCustFactory().Create(appDb);
				
				var result = iSSSFSSROValidCustExt.SSSFSSROValidCustSp(CustNum,
				CustSeq,
				Level,
				BillToAddr,
				ShipToAddr,
				BillMgr,
				BillMgrName,
				EndUserType,
				TermsCode,
				Slsman,
				Pricecode,
				ShipCode,
				CurrCode,
				FixedEuro,
				ExchRate,
				CreditHold,
				TaxCode1,
				TaxCode1Desc,
				TaxCode2,
				TaxCode2Desc,
				DepositReq,
				ApplyOpenDeposits,
				Region,
				RegionDesc,
				Contact,
				Email,
				Phone,
				Fax,
				PagerAddr,
				TxtMsgAddr,
				Infobar,
				PriorCode,
				BillToName,
				ShipToName,
				NOTC,
				DeliveryTerms,
				CurAmtFormat,
				CurCstPrcFormat,
				PriorCustNum,
				SRONum);
				
				int Severity = result.ReturnCode.Value;
				CustSeq = result.CustSeq;
				BillToAddr = result.BillToAddr;
				ShipToAddr = result.ShipToAddr;
				BillMgr = result.BillMgr;
				BillMgrName = result.BillMgrName;
				EndUserType = result.EndUserType;
				TermsCode = result.TermsCode;
				Slsman = result.Slsman;
				Pricecode = result.Pricecode;
				ShipCode = result.ShipCode;
				CurrCode = result.CurrCode;
				FixedEuro = result.FixedEuro;
				ExchRate = result.ExchRate;
				CreditHold = result.CreditHold;
				TaxCode1 = result.TaxCode1;
				TaxCode1Desc = result.TaxCode1Desc;
				TaxCode2 = result.TaxCode2;
				TaxCode2Desc = result.TaxCode2Desc;
				DepositReq = result.DepositReq;
				ApplyOpenDeposits = result.ApplyOpenDeposits;
				Region = result.Region;
				RegionDesc = result.RegionDesc;
				Contact = result.Contact;
				Email = result.Email;
				Phone = result.Phone;
				Fax = result.Fax;
				PagerAddr = result.PagerAddr;
				TxtMsgAddr = result.TxtMsgAddr;
				Infobar = result.Infobar;
				PriorCode = result.PriorCode;
				BillToName = result.BillToName;
				ShipToName = result.ShipToName;
				NOTC = result.NOTC;
				DeliveryTerms = result.DeliveryTerms;
				CurAmtFormat = result.CurAmtFormat;
				CurCstPrcFormat = result.CurCstPrcFormat;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSApsCtpSROInfoSp(string PSroNum,
		int? PSroLine,
		int? PSroOper,
		int? PTransNum,
		DateTime? PTransDate,
		string PRefType,
		string PRefNum,
		int? PRefLineSuf,
		string PItem,
		ref string PApsOrderId,
		ref int? PCategory,
		ref int? PFlags,
		ref DateTime? PApsRequestDate,
		ref DateTime? PApsDueDate,
		ref string PApsItem,
		ref int? PExcludeFromATP,
		ref DateTime? PSroStartDate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSApsCtpSROInfoExt = new SSSFSApsCtpSROInfoFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSApsCtpSROInfoExt.SSSFSApsCtpSROInfoSp(PSroNum,
				PSroLine,
				PSroOper,
				PTransNum,
				PTransDate,
				PRefType,
				PRefNum,
				PRefLineSuf,
				PItem,
				PApsOrderId,
				PCategory,
				PFlags,
				PApsRequestDate,
				PApsDueDate,
				PApsItem,
				PExcludeFromATP,
				PSroStartDate);
				
				int Severity = result.ReturnCode.Value;
				PApsOrderId = result.PApsOrderId;
				PCategory = result.PCategory;
				PFlags = result.PFlags;
				PApsRequestDate = result.PApsRequestDate;
				PApsDueDate = result.PApsDueDate;
				PApsItem = result.PApsItem;
				PExcludeFromATP = result.PExcludeFromATP;
				PSroStartDate = result.PSroStartDate;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSArpmtdChgSroNumSp(string PArpmtdSite,
		string PArpmtdSroNum,
		string PArpmtdInvNum,
		string PArpmtCustNum,
		string PDerCustCurrCode,
		int? PAddMode,
		int? PReApp,
		string POpenType,
		string PArpmtdType,
		decimal? PArpmtExchRate,
		DateTime? PArpmtRecptDate,
		decimal? PForAmtRem,
		ref string PArpmtdApplyCustNum,
		ref string PApplCustName,
		ref int? PFixedEuro,
		ref decimal? PArpmtdExchRate,
		ref int? PUpdateRate,
		ref decimal? PArpmtdForAmtApplied,
		ref decimal? PArpmtdForDiscAmt,
		ref decimal? PArpmtdDomAmtApplied,
		ref decimal? PArpmtdDomDiscAmt,
		ref string PArpmtdDiscAcct,
		ref string PArpmtdDiscAcctUnit1,
		ref string PArpmtdDiscAcctUnit2,
		ref string PArpmtdDiscAcctUnit3,
		ref string PArpmtdDiscAcctUnit4,
		ref string Infobar,
		string PArpmtBankCode,
		string PArpmtPaymentCurrCode,
		decimal? PArpmtPaymentExchRate)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSArpmtdChgSroNumExt = new SSSFSArpmtdChgSroNumFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSArpmtdChgSroNumExt.SSSFSArpmtdChgSroNumSp(PArpmtdSite,
				PArpmtdSroNum,
				PArpmtdInvNum,
				PArpmtCustNum,
				PDerCustCurrCode,
				PAddMode,
				PReApp,
				POpenType,
				PArpmtdType,
				PArpmtExchRate,
				PArpmtRecptDate,
				PForAmtRem,
				PArpmtdApplyCustNum,
				PApplCustName,
				PFixedEuro,
				PArpmtdExchRate,
				PUpdateRate,
				PArpmtdForAmtApplied,
				PArpmtdForDiscAmt,
				PArpmtdDomAmtApplied,
				PArpmtdDomDiscAmt,
				PArpmtdDiscAcct,
				PArpmtdDiscAcctUnit1,
				PArpmtdDiscAcctUnit2,
				PArpmtdDiscAcctUnit3,
				PArpmtdDiscAcctUnit4,
				Infobar,
				PArpmtBankCode,
				PArpmtPaymentCurrCode,
				PArpmtPaymentExchRate);
				
				int Severity = result.ReturnCode.Value;
				PArpmtdApplyCustNum = result.PArpmtdApplyCustNum;
				PApplCustName = result.PApplCustName;
				PFixedEuro = result.PFixedEuro;
				PArpmtdExchRate = result.PArpmtdExchRate;
				PUpdateRate = result.PUpdateRate;
				PArpmtdForAmtApplied = result.PArpmtdForAmtApplied;
				PArpmtdForDiscAmt = result.PArpmtdForDiscAmt;
				PArpmtdDomAmtApplied = result.PArpmtdDomAmtApplied;
				PArpmtdDomDiscAmt = result.PArpmtdDomDiscAmt;
				PArpmtdDiscAcct = result.PArpmtdDiscAcct;
				PArpmtdDiscAcctUnit1 = result.PArpmtdDiscAcctUnit1;
				PArpmtdDiscAcctUnit2 = result.PArpmtdDiscAcctUnit2;
				PArpmtdDiscAcctUnit3 = result.PArpmtdDiscAcctUnit3;
				PArpmtdDiscAcctUnit4 = result.PArpmtdDiscAcctUnit4;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSConsoleTotalsSp(string SroNum,
		int? SroLine,
		int? SroOper,
		string Level,
		string ValueType,
		ref decimal? PlanMatl,
		ref decimal? PlanLabor,
		ref decimal? PlanMisc,
		ref decimal? ActMatl,
		ref decimal? ActLabor,
		ref decimal? ActMisc,
		ref decimal? ActProject,
		ref decimal? PlanTotal,
		ref decimal? ActTotal,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] ref decimal? PlanProject,
		[Optional, DefaultParameterValue(0)] ref decimal? UnActProject)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSConsoleTotalsExt = new SSSFSConsoleTotalsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSConsoleTotalsExt.SSSFSConsoleTotalsSp(SroNum,
				SroLine,
				SroOper,
				Level,
				ValueType,
				PlanMatl,
				PlanLabor,
				PlanMisc,
				ActMatl,
				ActLabor,
				ActMisc,
				ActProject,
				PlanTotal,
				ActTotal,
				Infobar,
				PlanProject,
				UnActProject);
				
				int Severity = result.ReturnCode.Value;
				PlanMatl = result.PlanMatl;
				PlanLabor = result.PlanLabor;
				PlanMisc = result.PlanMisc;
				ActMatl = result.ActMatl;
				ActLabor = result.ActLabor;
				ActMisc = result.ActMisc;
				ActProject = result.ActProject;
				PlanTotal = result.PlanTotal;
				ActTotal = result.ActTotal;
				Infobar = result.Infobar;
				PlanProject = result.PlanProject;
				UnActProject = result.UnActProject;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSGetCOCustInfoSp(string iCoNum,
			ref string oCustNum,
			ref int? oCustSeq)
		{
			var iSSSFSGetCOCustInfoExt = new SSSFSGetCOCustInfoFactory().Create(this, true);
			
			var result = iSSSFSGetCOCustInfoExt.SSSFSGetCOCustInfoSp(iCoNum,
				oCustNum,
				oCustSeq);
			
			oCustNum = result.oCustNum;
			oCustSeq = result.oCustSeq;
			
			return result.ReturnCode??0;
		}

		[IDOMethod(MethodFlags.CustomLoad, "Infobar")]
		public DataTable SSSFSProfileSROPrePackSlipSp([Optional] string StartSRONum,
		[Optional] string EndSRONum,
		[Optional] string StartCustNum,
		[Optional] string EndCustNum,
		[Optional] DateTime? StartOpenDate,
		[Optional] DateTime? EndOpenDate,
		[Optional] DateTime? StartTransDate,
		[Optional] DateTime? EndTransDate,
		[Optional, DefaultParameterValue("OIC")] string OrdStat)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSProfileSROPrePackSlipExt = new SSSFSProfileSROPrePackSlipFactory().Create(appDb,
				bunchedLoadCollection,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSProfileSROPrePackSlipExt.SSSFSProfileSROPrePackSlipSp(StartSRONum,
				EndSRONum,
				StartCustNum,
				EndCustNum,
				StartOpenDate,
				EndOpenDate,
				StartTransDate,
				EndTransDate,
				OrdStat);
				
				IRecordCollectionToDataTable recordCollectionToDataTable = new RecordCollectionToDataTable();
				
				DataTable dt = recordCollectionToDataTable.ToDataTable(result.Data.Items);
				return dt;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSFSValidSeqSp(string CustNum,
		int? CustSeq,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iSSSFSValidSeqExt = new SSSFSValidSeqFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iSSSFSValidSeqExt.SSSFSValidSeqSp(CustNum,
				CustSeq,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
