//PROJECT NAME: CustomerExt
//CLASS NAME: SLRmaDisps.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Logistics.Customer;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;

namespace CSI.MG.Customer
{
    [IDOExtensionClass("SLRmaDisps")]
    public class SLRmaDisps : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXDispDefaultsSp(ref string DefWhse,
                                        ref string DefRmxWhse,
                                        ref string DefRmxLoc,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXDispDefaultsExt = new SSSRMXDispDefaultsFactory().Create(appDb);

                int Severity = iSSSRMXDispDefaultsExt.SSSRMXDispDefaultsSp(ref DefWhse,
                                                                           ref DefRmxWhse,
                                                                           ref DefRmxLoc,
                                                                           ref Infobar);

                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int SSSRMXDispValidRmaSp(string Mode,
                                        string RmaNum,
                                        ref short? RmaLine,
                                        ref string RmaCustNum,
                                        ref int? RmaCustSeq,
                                        ref string CadName,
                                        ref string RmaStat,
                                        ref string RmaLnItem,
                                        ref decimal? RmaLnQtyToReturn,
                                        ref decimal? RmaLnQtyReceived,
                                        ref decimal? RmaLnQtyDispConv,
                                        ref string RmaLnStat,
                                        ref string RmxSerNum,
                                        ref string RmxDispCode,
                                        ref string DispCode,
                                        ref byte? RmxEnableDisp,
                                        ref byte? DerSerTracked,
                                        ref byte? DerLotTracked,
                                        ref string RmaWhse,
                                        ref string Loc,
                                        ref string Lot,
                                        ref decimal? Amount,
                                        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iSSSRMXDispValidRmaExt = new SSSRMXDispValidRmaFactory().Create(appDb);

                int Severity = iSSSRMXDispValidRmaExt.SSSRMXDispValidRmaSp(Mode,
                                                                           RmaNum,
                                                                           ref RmaLine,
                                                                           ref RmaCustNum,
                                                                           ref RmaCustSeq,
                                                                           ref CadName,
                                                                           ref RmaStat,
                                                                           ref RmaLnItem,
                                                                           ref RmaLnQtyToReturn,
                                                                           ref RmaLnQtyReceived,
                                                                           ref RmaLnQtyDispConv,
                                                                           ref RmaLnStat,
                                                                           ref RmxSerNum,
                                                                           ref RmxDispCode,
                                                                           ref DispCode,
                                                                           ref RmxEnableDisp,
                                                                           ref DerSerTracked,
                                                                           ref DerLotTracked,
                                                                           ref RmaWhse,
                                                                           ref Loc,
                                                                           ref Lot,
                                                                           ref Amount,
                                                                           ref Infobar);

                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXGetQtyDispSp(string RmaNum,
		    int? RmaLine,
		    ref decimal? RmxQtyDisp,
		    ref string Infobar)
		{
			var iSSSRMXGetQtyDispExt = new SSSRMXGetQtyDispFactory().Create(this, true);
			
			var result = iSSSRMXGetQtyDispExt.SSSRMXGetQtyDispSp(RmaNum,
			    RmaLine,
			    RmxQtyDisp,
			    Infobar);
			
			RmxQtyDisp = result.RmxQtyDisp;
			Infobar = result.Infobar;
			
			return result.ReturnCode??0;
		}


		[IDOMethod(MethodFlags.None, "Infobar")]
		public int SSSRMXDispPostSp(string Mode,
		                            Guid? DispRowPointer,
		                            string iSroCopyTransFrom,
		                            string iTemplateSroNum,
		                            int? iTemplateSROLine,
		                            string iSelectedOpers,
		                            string iBillMgr,
		                            string iSRODesc,
		                            string iLeadPartner,
		                            string iCompItem,
		                            decimal? iCompQtyOrd,
		                            ref string PromptMsg,
		                            ref string PromptButtons,
		                            ref string Infobar,
		                            [Optional] byte? RewSROCreatedAlready,
		                            [Optional] string RewSroNum,
		                            [Optional] int? RewSroLine,
		                            [Optional] int? RewSroOper)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iSSSRMXDispPostExt = new SSSRMXDispPostFactory().Create(appDb);
				
				var result = iSSSRMXDispPostExt.SSSRMXDispPostSp(Mode,
				                                                 DispRowPointer,
				                                                 iSroCopyTransFrom,
				                                                 iTemplateSroNum,
				                                                 iTemplateSROLine,
				                                                 iSelectedOpers,
				                                                 iBillMgr,
				                                                 iSRODesc,
				                                                 iLeadPartner,
				                                                 iCompItem,
				                                                 iCompQtyOrd,
				                                                 PromptMsg,
				                                                 PromptButtons,
				                                                 Infobar,
				                                                 RewSROCreatedAlready,
				                                                 RewSroNum,
				                                                 RewSroLine,
				                                                 RewSroOper);
				
				int Severity = result.ReturnCode.Value;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
