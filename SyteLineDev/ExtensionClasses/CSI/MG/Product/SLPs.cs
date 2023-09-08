//PROJECT NAME: ProductExt
//CLASS NAME: SLPs.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.ExternalContracts.FactoryTrack;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLPs")]
    public class SLPs : ExtensionClassBase, IExtFTSLPs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CopyPsSp(string PsFrom,
                            string PsTo,
                            string BegItem,
                            string EndItem,
                            DateTime? BegDate,
                            DateTime? EndDate,
                            string PsRelStatP,
                            string PsRelStatR,
                            string PsRelStatC,
                            int? DaysLookback,
                            byte? CopyBomPs,
                            ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCopyPsExt = new CopyPsFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iCopyPsExt.CopyPsSp(PsFrom,
                                                   PsTo,
                                                   BegItem,
                                                   EndItem,
                                                   BegDate,
                                                   EndDate,
                                                   PsRelStatP,
                                                   PsRelStatR,
                                                   PsRelStatC,
                                                   DaysLookback,
                                                   CopyBomPs,
                                                   ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GenPsValidateDateSp(ref DateTime? FromDate,
                                       ref DateTime? EndDate,
                                       ref DateTime? MDate,
                                       ref int? MdayNum,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGenPsValidateDateExt = new GenPsValidateDateFactory().Create(appDb);

                DateType oFromDate = FromDate;
                DateType oEndDate = EndDate;
                DateType oMDate = MDate;
                MdayNumType oMdayNum = MdayNum;
                InfobarType oInfobar = Infobar;

                int Severity = iGenPsValidateDateExt.GenPsValidateDateSp(ref oFromDate,
                                                                         ref oEndDate,
                                                                         ref oMDate,
                                                                         ref oMdayNum,
                                                                         ref oInfobar);

                FromDate = oFromDate;
                EndDate = oEndDate;
                MDate = oMDate;
                MdayNum = oMdayNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GenPSValidItemSp(string PsGenStat,
                                    string PsGenType,
                                    ref string InItem,
                                    ref string ItemUM,
                                    ref decimal? GenQty,
                                    ref decimal? ItemRatePerDay,
                                    ref DateTime? OutFromDate,
                                    ref DateTime? OutToDate,
                                    ref DateTime? MDate,
                                    ref int? MdayNum,
                                    ref int? Freq,
                                    ref string PsNum,
                                    ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGenPSValidItemExt = new GenPSValidItemFactory().Create(appDb);

                ItemType oInItem = InItem;
                UMType oItemUM = ItemUM;
                QtyUnitType oGenQty = GenQty;
                RunRateType oItemRatePerDay = ItemRatePerDay;
                DateType oOutFromDate = OutFromDate;
                DateType oOutToDate = OutToDate;
                DateType oMDate = MDate;
                MdayNumType oMdayNum = MdayNum;
                MdaysType oFreq = Freq;
                PsNumType oPsNum = PsNum;
                InfobarType oInfobar = Infobar;

                int Severity = iGenPSValidItemExt.GenPSValidItemSp(PsGenStat,
                                                                   PsGenType,
                                                                   ref oInItem,
                                                                   ref oItemUM,
                                                                   ref oGenQty,
                                                                   ref oItemRatePerDay,
                                                                   ref oOutFromDate,
                                                                   ref oOutToDate,
                                                                   ref oMDate,
                                                                   ref oMdayNum,
                                                                   ref oFreq,
                                                                   ref oPsNum,
                                                                   ref oInfobar);

                InItem = oInItem;
                ItemUM = oItemUM;
                GenQty = oGenQty;
                ItemRatePerDay = oItemRatePerDay;
                OutFromDate = oOutFromDate;
                OutToDate = oOutToDate;
                MDate = oMDate;
                MdayNum = oMdayNum;
                Freq = oFreq;
                PsNum = oPsNum;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetMfgDateSp(string DateLabel,
                                DateTime? RequestDate,
                                ref DateTime? McalDate,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iGetMfgDateExt = new GetMfgDateFactory().Create(appDb);

                DateType oMcalDate = McalDate;
                InfobarType oInfobar = Infobar;

                int Severity = iGetMfgDateExt.GetMfgDateSp(DateLabel,
                                                           RequestDate,
                                                           ref oMcalDate,
                                                           ref oInfobar);

                McalDate = oMcalDate;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PreGenPsSp(string Item,
                              decimal? GenQty,
                              decimal? RatePerDay,
                              DateTime? MDate,
                              int? Freq,
                              string PsGenStat,
                              string PsNum,
                              ref string PromptMsg1,
                              ref string PromptButtons1,
                              ref string PromptMsg2,
                              ref string PromptButtons2,
                              ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPreGenPsExt = new PreGenPsFactory().Create(appDb);

                InfobarType oPromptMsg1 = PromptMsg1;
                InfobarType oPromptButtons1 = PromptButtons1;
                InfobarType oPromptMsg2 = PromptMsg2;
                InfobarType oPromptButtons2 = PromptButtons2;
                InfobarType oInfobar = Infobar;

                int Severity = iPreGenPsExt.PreGenPsSp(Item,
                                                       GenQty,
                                                       RatePerDay,
                                                       MDate,
                                                       Freq,
                                                       PsGenStat,
                                                       PsNum,
                                                       ref oPromptMsg1,
                                                       ref oPromptButtons1,
                                                       ref oPromptMsg2,
                                                       ref oPromptButtons2,
                                                       ref oInfobar);

                PromptMsg1 = oPromptMsg1;
                PromptButtons1 = oPromptButtons1;
                PromptMsg2 = oPromptMsg2;
                PromptButtons2 = oPromptButtons2;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ProdSchedNextKeyDelSp(string PSNum,
                                         ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iProdSchedNextKeyDelExt = new ProdSchedNextKeyDelFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iProdSchedNextKeyDelExt.ProdSchedNextKeyDelSp(PSNum,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }



        [IDOMethod(MethodFlags.None, "Infobar")]
        public int PsStatValidSp(string PFromStat,
                                 string PToStat,
                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iPsStatValidExt = new PsStatValidFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iPsStatValidExt.PsStatValidSp(PFromStat,
                                                             PToStat,
                                                             ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateTargetPsNumForCopySp(ref string PsNum,
                                                string FROMPsNum,
                                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateTargetPsNumForCopyExt = new ValidateTargetPsNumForCopyFactory().Create(appDb);

                PsNumType oPsNum = PsNum;
                Infobar oInfobar = Infobar;

                int Severity = iValidateTargetPsNumForCopyExt.ValidateTargetPsNumForCopySp(ref oPsNum,
                                                                                           FROMPsNum,
                                                                                           ref oInfobar);

                PsNum = oPsNum;
                Infobar = oInfobar;


                return Severity;
            }
        }






		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSDelSp([Optional] DateTime? ToDate,
		                   [Optional] DateTime? FromDate,
		                   [Optional] string ToPSNum,
		                   [Optional] string FromPSNum,
		                   [Optional] string ToPSItem,
		                   [Optional] string FromPSItem,
		                   ref int? CounterItem,
		                   ref string Infobar,
		                   [Optional] short? StartingTransDateOffset,
		                   [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSDelExt = new PSDelFactory().Create(appDb);
				
				var result = iPSDelExt.PSDelSp(ToDate,
				                               FromDate,
				                               ToPSNum,
				                               FromPSNum,
				                               ToPSItem,
				                               FromPSItem,
				                               CounterItem,
				                               Infobar,
				                               StartingTransDateOffset,
				                               EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				CounterItem = result.CounterItem;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PsQtyValidSp(decimal? Qty,
		                        string PItem,
		                        [Optional, DefaultParameterValue((byte)0)] byte? CmplFlag,
		[Optional, DefaultParameterValue((byte)0)] byte? ScrpFlag,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPsQtyValidExt = new PsQtyValidFactory().Create(appDb);
				
				var result = iPsQtyValidExt.PsQtyValidSp(Qty,
				                                         PItem,
				                                         CmplFlag,
				                                         ScrpFlag,
				                                         Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSVal10Sp(string PSItem,
		                     [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
		ref string PSNum,
		ref string UM,
		ref byte? LotTracked,
		ref byte? SerTracked,
		ref string Whse,
		ref string Wc,
		ref int? OperNum,
		ref string PSItemJob,
		ref short? PSItemSuffix,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSVal10Ext = new PSVal10Factory().Create(appDb);
				
				var result = iPSVal10Ext.PSVal10Sp(PSItem,
				                                   Cmpl,
				                                   PSNum,
				                                   UM,
				                                   LotTracked,
				                                   SerTracked,
				                                   Whse,
				                                   Wc,
				                                   OperNum,
				                                   PSItemJob,
				                                   PSItemSuffix,
				                                   Infobar);
				
				int Severity = result.ReturnCode.Value;
				PSNum = result.PSNum;
				UM = result.UM;
				LotTracked = result.LotTracked;
				SerTracked = result.SerTracked;
				Whse = result.Whse;
				Wc = result.Wc;
				OperNum = result.OperNum;
				PSItemJob = result.PSItemJob;
				PSItemSuffix = result.PSItemSuffix;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSVal3Sp(string PSNum,
		                    string PSItem,
		                    [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
		ref string Whse,
		ref string Wc,
		ref int? OperNum,
		ref string PSItemJob,
		ref short? PSItemSuffix,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSVal3Ext = new PSVal3Factory().Create(appDb);
				
				var result = iPSVal3Ext.PSVal3Sp(PSNum,
				                                 PSItem,
				                                 Cmpl,
				                                 Whse,
				                                 Wc,
				                                 OperNum,
				                                 PSItemJob,
				                                 PSItemSuffix,
				                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				Whse = result.Whse;
				Wc = result.Wc;
				OperNum = result.OperNum;
				PSItemJob = result.PSItemJob;
				PSItemSuffix = result.PSItemSuffix;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSVal4Sp(string PSNum,
		                    string PSItem,
		                    string Wc,
		                    [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
		ref int? OperNum,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSVal4Ext = new PSVal4Factory().Create(appDb);
				
				var result = iPSVal4Ext.PSVal4Sp(PSNum,
				                                 PSItem,
				                                 Wc,
				                                 Cmpl,
				                                 OperNum,
				                                 Infobar);
				
				int Severity = result.ReturnCode.Value;
				OperNum = result.OperNum;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PSVal5Sp(string PSNum,
		                    string PSItem,
		                    int? OperNum,
		                    [Optional, DefaultParameterValue((byte)0)] byte? Cmpl,
		ref string Wc,
		ref string Infobar,
		[Optional] ref byte? IsLastOper,
		[Optional, DefaultParameterValue((byte)0)] byte? ValidateCycle,
		[Optional] DateTime? TransDate,
		[Optional] ref string Prompt,
		[Optional] ref string PromptButtons)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iPSVal5Ext = new PSVal5Factory().Create(appDb);
				
				var result = iPSVal5Ext.PSVal5Sp(PSNum,
				                                 PSItem,
				                                 OperNum,
				                                 Cmpl,
				                                 Wc,
				                                 Infobar,
				                                 IsLastOper,
				                                 ValidateCycle,
				                                 TransDate,
				                                 Prompt,
				                                 PromptButtons);
				
				int Severity = result.ReturnCode.Value;
				Wc = result.Wc;
				Infobar = result.Infobar;
				IsLastOper = result.IsLastOper;
				Prompt = result.Prompt;
				PromptButtons = result.PromptButtons;
				return Severity;
			}
		}




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int GeneratePsSp(string Item,
		decimal? GenQty,
		decimal? RatePerDay,
		string PsGenType,
		DateTime? MDate,
		int? MdayNum,
		int? PsGenFreq,
		string PsGenStat,
		ref string PsNum,
		string UpdateJobRel,
		[Optional] string PsPrefix,
		[Optional] Guid? SessionID,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] int? FromMRP,
		[Optional] string PLN_Ref_Type,
		[Optional] string PLN_Ref_Num,
		[Optional] int? PLN_ref_suf,
		[Optional] int? CopyToPSItemBOM,
		[Optional] int? CopyToReleaseBOM,
		ref int? PsReleasecount)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iGeneratePsExt = new GeneratePsFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iGeneratePsExt.GeneratePsSp(Item,
				GenQty,
				RatePerDay,
				PsGenType,
				MDate,
				MdayNum,
				PsGenFreq,
				PsGenStat,
				PsNum,
				UpdateJobRel,
				PsPrefix,
				SessionID,
				Infobar,
				FromMRP,
				PLN_Ref_Type,
				PLN_Ref_Num,
				PLN_ref_suf,
				CopyToPSItemBOM,
				CopyToReleaseBOM,
				PsReleasecount);
				
				int Severity = result.ReturnCode.Value;
				PsNum = result.PsNum;
				Infobar = result.Infobar;
				PsReleasecount = result.PsReleasecount;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int PsItemValidSp(ref string Item,
		string Whse,
		ref string TItemDesc,
		ref int? TSerTracked,
		ref int? TLotTracked,
		ref string TLotPrefix,
		ref string TLoc,
		ref string TLot,
		ref string TUM,
		ref decimal? UomConvFactor,
		ref string PromptMsg,
		ref string PromptButtons,
		ref string Infobar,
		[Optional, DefaultParameterValue(0)] ref int? EnableContainer)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iPsItemValidExt = new PsItemValidFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iPsItemValidExt.PsItemValidSp(Item,
				Whse,
				TItemDesc,
				TSerTracked,
				TLotTracked,
				TLotPrefix,
				TLoc,
				TLot,
				TUM,
				UomConvFactor,
				PromptMsg,
				PromptButtons,
				Infobar,
				EnableContainer);
				
				int Severity = result.ReturnCode.Value;
				Item = result.Item;
				TItemDesc = result.TItemDesc;
				TSerTracked = result.TSerTracked;
				TLotTracked = result.TLotTracked;
				TLotPrefix = result.TLotPrefix;
				TLoc = result.TLoc;
				TLot = result.TLot;
				TUM = result.TUM;
				UomConvFactor = result.UomConvFactor;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				EnableContainer = result.EnableContainer;
				return Severity;
			}
		}
    }
}
