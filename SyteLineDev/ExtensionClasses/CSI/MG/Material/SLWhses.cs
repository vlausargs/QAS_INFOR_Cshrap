//PROJECT NAME: MaterialExt
//CLASS NAME: SLWhses.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using CSI.Data.SQL;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using Microsoft.Extensions.DependencyInjection;
using CSI.Production;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLWhses")]
    public class SLWhses : CSIExtensionClassBase
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int AskWhseInventorySp(ref string PromptMsg,
                                      ref string PromptButtons,
                                      ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iAskWhseInventoryExt = new AskWhseInventoryFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;
                InfobarType oInfobar = Infobar;

                int Severity = iAskWhseInventoryExt.AskWhseInventorySp(ref oPromptMsg,
                                                                       ref oPromptButtons,
                                                                       ref oInfobar);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int CheckCostItemAtWhseForConsignmentSp(ref string ConsignmentType,
                                                       ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iCheckCostItemAtWhseForConsignmentExt = new CheckCostItemAtWhseForConsignmentFactory().Create(appDb);

                ConsignmentTypeType oConsignmentType = ConsignmentType;
                InfobarType oInfobar = Infobar;

                int Severity = iCheckCostItemAtWhseForConsignmentExt.CheckCostItemAtWhseForConsignmentSp(ref oConsignmentType,
                                                                                                         ref oInfobar);

                ConsignmentType = oConsignmentType;
                Infobar = oInfobar;


                return Severity;
            }
        }

        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable Whse05RSp(string FromWhse,
                                   string DcLoc1,
                                   string ToWhse,
                                   string ToLoc)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iWhse05RExt = new Whse05RFactory().Create(appDb, bunchedLoadCollection);

                DataTable dt = iWhse05RExt.Whse05RSp(FromWhse,
                                                     DcLoc1,
                                                     ToWhse,
                                                     ToLoc);

                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WhSetSp(string Whse,
                           byte? CustomerSet,
                           string CustNumBegin,
                           string CustNumEnd,
                           byte? VendorSet,
                           string VendNumBegin,
                           string VendNumEnd,
                           byte? UserSet,
                           string UserBegin,
                           string UserEnd,
                           ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWhSetExt = new WhSetFactory().Create(appDb);

                InfobarType oInfobar = Infobar;

                int Severity = iWhSetExt.WhSetSp(Whse,
                                                 CustomerSet,
                                                 CustNumBegin,
                                                 CustNumEnd,
                                                 VendorSet,
                                                 VendNumBegin,
                                                 VendNumEnd,
                                                 UserSet,
                                                 UserBegin,
                                                 UserEnd,
                                                 ref oInfobar);

                Infobar = oInfobar;


                return Severity;
            }
        }




		[IDOMethod(MethodFlags.None, "Infobar")]
		public int VendorConsignQtyAvailforItemSp(string CheckType,
		string CurrentWhse,
		[Optional] string Item,
		[Optional] string Job,
		[Optional] string Loc,
		[Optional] string Lot,
		[Optional] int? JobSuffix,
		[Optional] int? JobmatlOperNum,
		[Optional] int? JobmatlSequence,
		[Optional] string ProjNum,
		[Optional] int? TaskNum,
		[Optional] int? ProjmatSeq,
		[Optional] decimal? QtyRequired,
		[Optional] ref decimal? ConsignQtyRequired,
		[Optional] ref string ConsignVdrWhse,
		[Optional] ref string ConsignVdrLoc,
		[Optional] ref string PromptMsg,
		[Optional] ref string PromptButtons,
		[Optional] ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iVendorConsignQtyAvailforItemExt = new VendorConsignQtyAvailforItemFactory().Create(appDb);
				
				var result = iVendorConsignQtyAvailforItemExt.VendorConsignQtyAvailforItemSp(CheckType,
				CurrentWhse,
				Item,
				Job,
				Loc,
				Lot,
				JobSuffix,
				JobmatlOperNum,
				JobmatlSequence,
				ProjNum,
				TaskNum,
				ProjmatSeq,
				QtyRequired,
				ConsignQtyRequired,
				ConsignVdrWhse,
				ConsignVdrLoc,
				PromptMsg,
				PromptButtons,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				ConsignQtyRequired = result.ConsignQtyRequired;
				ConsignVdrWhse = result.ConsignVdrWhse;
				ConsignVdrLoc = result.ConsignVdrLoc;
				PromptMsg = result.PromptMsg;
				PromptButtons = result.PromptButtons;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int WhseValidSp(string Whse,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iWhseValidExt = new WhseValidFactory().Create(appDb);
				
				var result = iWhseValidExt.WhseValidSp(Whse,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckWhsePhyInvFlgSp(string Whse,
		string Site,
		[Optional, DefaultParameterValue(0)] ref int? WhsePhyInvFlg,
		ref string Infobar)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iCheckWhsePhyInvFlgExt = new CheckWhsePhyInvFlgFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iCheckWhsePhyInvFlgExt.CheckWhsePhyInvFlgSp(Whse,
				Site,
				WhsePhyInvFlg,
				Infobar);
				
				int Severity = result.ReturnCode.Value;
				WhsePhyInvFlg = result.WhsePhyInvFlg;
				Infobar = result.Infobar;
				return Severity;
			}
		}

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int CheckWhseExternalControlledFlagSp(string Whse,
		string Site,
		ref string Infobar)
		{
			var iCheckWhseExternalControlledFlagExt = this.GetService<ICheckWhseExternalControlledFlag>();

			var result = iCheckWhseExternalControlledFlagExt.CheckWhseExternalControlledFlagSp(Whse,
			Site,
			Infobar);

			int Severity = result.ReturnCode.Value;
			Infobar = result.Infobar;
			return Severity;
		}
	}
}
