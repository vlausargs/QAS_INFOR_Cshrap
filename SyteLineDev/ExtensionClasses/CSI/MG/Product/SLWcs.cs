//PROJECT NAME: ProductExt
//CLASS NAME: SLWcs.cs

using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Production;
using CSI.MG;
using CSI.Data.SQL.UDDT;
using CSI.ExternalContracts.FactoryTrack;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Product
{
    [IDOExtensionClass("SLWcs")]
    public class SLWcs : ExtensionClassBase, IExtFTSLWcs
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcItemValidSp(ref string Item,
                                 string Whse,
                                 ref string TItemDesc,
                                 ref byte? TSerTracked,
                                 ref byte? TLotTracked,
                                 ref string TLoc,
                                 ref string TLot,
                                 ref string TUM,
                                 ref double? UomConvFactor,
                                 ref byte? NonInvItem,
                                 ref string PromptMsg,
                                 ref string PromptButtons,
                                 ref string Infobar,
                                 ref decimal? MatlCost,
                                 ref decimal? LbrCost,
                                 ref decimal? FovhdCost,
                                 ref decimal? VovhdCost,
                                 ref decimal? OutCost,
                                 ref byte? TrackPieces,
                                 ref string DimensionGroup,
                                 ref string TrxRestrictCode)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcItemValidExt = new WcItemValidFactory().Create(appDb);

                int Severity = iWcItemValidExt.WcItemValidSp(ref Item,
                                                             Whse,
                                                             ref TItemDesc,
                                                             ref TSerTracked,
                                                             ref TLotTracked,
                                                             ref TLoc,
                                                             ref TLot,
                                                             ref TUM,
                                                             ref UomConvFactor,
                                                             ref NonInvItem,
                                                             ref PromptMsg,
                                                             ref PromptButtons,
                                                             ref Infobar,
                                                             ref MatlCost,
                                                             ref LbrCost,
                                                             ref FovhdCost,
                                                             ref VovhdCost,
                                                             ref OutCost,
                                                             ref TrackPieces,
                                                             ref DimensionGroup,
                                                             ref TrxRestrictCode);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcEopCostSp(string StartingWc,
                               string EndingWc,
                               DateTime? PostThrough,
                               DateTime? TransDate,
                               ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcEopCostExt = new WcEopCostFactory().Create(appDb);

                int Severity = iWcEopCostExt.WcEopCostSp(StartingWc,
                                                         EndingWc,
                                                         PostThrough,
                                                         TransDate,
                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcEopCostLasttranSp(ref byte? TAsked,
                                       ref string PromptMsg,
                                       ref string PromptButtons,
                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcEopCostLasttranExt = new WcEopCostLasttranFactory().Create(appDb);

                int Severity = iWcEopCostLasttranExt.WcEopCostLasttranSp(ref TAsked,
                                                                         ref PromptMsg,
                                                                         ref PromptButtons,
                                                                         ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcContainerMatlSp(string TWc,
                                     string TWhse,
                                     DateTime? TTransDate,
                                     string TEmpNum,
                                     string TAcct,
                                     string TAcctUnit1,
                                     string TAcctUnit2,
                                     string TAcctUnit3,
                                     string TAcctUnit4,
                                     string SerialPrefix,
                                     string ContainerNum,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcContainerMatlExt = new WcContainerMatlFactory().Create(appDb);

                int Severity = iWcContainerMatlExt.WcContainerMatlSp(TWc,
                                                                     TWhse,
                                                                     TTransDate,
                                                                     TEmpNum,
                                                                     TAcct,
                                                                     TAcctUnit1,
                                                                     TAcctUnit2,
                                                                     TAcctUnit3,
                                                                     TAcctUnit4,
                                                                     SerialPrefix,
                                                                     ContainerNum,
                                                                     ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcmatlQtyValidSp(decimal? NewQty,
                                     string PItem,
                                     string UM,
                                     double? UomConvFactor,
                                     ref decimal? TQty,
                                     ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcmatlQtyValidExt = new WcmatlQtyValidFactory().Create(appDb);

                int Severity = iWcmatlQtyValidExt.WcmatlQtyValidSp(NewQty,
                                                                   PItem,
                                                                   UM,
                                                                   UomConvFactor,
                                                                   ref TQty,
                                                                   ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcPreDeleteSp(string PWc,
                                 ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcPreDeleteExt = new WcPreDeleteFactory().Create(appDb);

                int Severity = iWcPreDeleteExt.WcPreDeleteSp(PWc,
                                                             ref Infobar);

                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WcUMValidSp(string PItem,
                                decimal? PMatlQty,
                                ref string PUM,
                                ref double? UomConvFactor,
                                ref decimal? TQty,
                                ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWcUMValidExt = new WcUMValidFactory().Create(appDb);

                int Severity = iWcUMValidExt.WcUMValidSp(PItem,
                                                         PMatlQty,
                                                         ref PUM,
                                                         ref UomConvFactor,
                                                         ref TQty,
                                                         ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int DelEopCostSp(string StartingWc,
		                        string EndingWc,
		                        DateTime? StartingDate,
		                        DateTime? EndingDate,
		                        ref string Infobar,
		                        [Optional] short? StartingTransDateOffset,
		                        [Optional] short? EndingTransDateOffset)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iDelEopCostExt = new DelEopCostFactory().Create(appDb);
				
				var result = iDelEopCostExt.DelEopCostSp(StartingWc,
				                                         EndingWc,
				                                         StartingDate,
				                                         EndingDate,
				                                         Infobar,
				                                         StartingTransDateOffset,
				                                         EndingTransDateOffset);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WcmatlSetVarsSP(string SET,
		                           string TWc,
		                           string TItem,
		                           string TWhse,
		                           string TLoc,
		                           string TLot,
		                           decimal? TQty,
		                           DateTime? TTransDate,
		                           string TEmpNum,
		                           string TAcct,
		                           string TAcctUnit1,
		                           string TAcctUnit2,
		                           string TAcctUnit3,
		                           string TAcctUnit4,
		                           decimal? TMatlCost,
		                           decimal? TLbrCost,
		                           decimal? TFovhdCost,
		                           decimal? TVovhdCost,
		                           decimal? TOutCost,
		                           double? UmConvFactor,
		                           string SerialPrefix,
		                           ref string Infobar,
		                           [Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWcmatlSetVarsExt = new WcmatlSetVarsFactory().Create(appDb);
				
				var result = iWcmatlSetVarsExt.WcmatlSetVarsSp(SET,
				                                               TWc,
				                                               TItem,
				                                               TWhse,
				                                               TLoc,
				                                               TLot,
				                                               TQty,
				                                               TTransDate,
				                                               TEmpNum,
				                                               TAcct,
				                                               TAcctUnit1,
				                                               TAcctUnit2,
				                                               TAcctUnit3,
				                                               TAcctUnit4,
				                                               TMatlCost,
				                                               TLbrCost,
				                                               TFovhdCost,
				                                               TVovhdCost,
				                                               TOutCost,
				                                               UmConvFactor,
				                                               SerialPrefix,
				                                               Infobar,
				                                               DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WcmatlSp(string TWc,
		string TItem,
		string TWhse,
		string TLoc,
		string TLot,
		decimal? TQty,
		DateTime? TTransDate,
		string TEmpNum,
		string TAcct,
		string TAcctUnit1,
		string TAcctUnit2,
		string TAcctUnit3,
		string TAcctUnit4,
		decimal? TMatlCost,
		decimal? TLbrCost,
		decimal? TFovhdCost,
		decimal? TVovhdCost,
		decimal? TOutCost,
		decimal? UmConvFactor,
		string SerialPrefix,
		ref string Infobar,
		[Optional] string DocumentNum)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iWcmatlExt = new WcmatlFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iWcmatlExt.WcmatlSp(TWc,
				TItem,
				TWhse,
				TLoc,
				TLot,
				TQty,
				TTransDate,
				TEmpNum,
				TAcct,
				TAcctUnit1,
				TAcctUnit2,
				TAcctUnit3,
				TAcctUnit4,
				TMatlCost,
				TLbrCost,
				TFovhdCost,
				TVovhdCost,
				TOutCost,
				UmConvFactor,
				SerialPrefix,
				Infobar,
				DocumentNum);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
