//PROJECT NAME: MaterialExt
//CLASS NAME: WarningReceiveItemToContainer.cs

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
    [IDOExtensionClass("SLStockActItems")]
    public class SLStockActItems : ExtensionClassBase, IExtFTSLStockActItems
    {
        [IDOMethod(MethodFlags.None, "Infobar")]
        public int WarningReceiveItemToContainerSp(string ContainerNum,
                                                   ref string PromptMsg,
                                                   ref string PromptButtons)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iWarningReceiveItemToContainerExt = new WarningReceiveItemToContainerFactory().Create(appDb);

                InfobarType oPromptMsg = PromptMsg;
                InfobarType oPromptButtons = PromptButtons;

                int Severity = iWarningReceiveItemToContainerExt.WarningReceiveItemToContainerSp(ContainerNum,
                                                                                   ref oPromptMsg,
                                                                                   ref oPromptButtons);

                PromptMsg = oPromptMsg;
                PromptButtons = oPromptButtons;


                return Severity;
            }
        }

		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemMiscReceiptSetVarsSp(string SET,
		                                    string P_Item,
		                                    string P_Whse,
		                                    decimal? P_Qty,
		                                    string P_UM,
		                                    decimal? P_MatlCost,
		                                    decimal? P_LbrCost,
		                                    decimal? P_FovhdCost,
		                                    decimal? P_VovhdCost,
		                                    decimal? P_OutCost,
		                                    decimal? P_UnitCost,
		                                    string P_Loc,
		                                    string P_Lot,
		                                    string P_Reason,
		                                    string P_Acct,
		                                    string P_AcctUnit1,
		                                    string P_AcctUnit2,
		                                    string P_AcctUnit3,
		                                    string P_AcctUnit4,
		                                    DateTime? P_TransDate,
		                                    ref string Infobar,
		                                    [Optional] string DocumentNum,
		                                    string P_ImportDocId,
		                                    [Optional] string ContainerNum,
		                                    [Optional] string UMVendNum,
		                                    [Optional] string UMArea)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var iItemMiscReceiptSetVarsExt = new ItemMiscReceiptSetVarsFactory().Create(appDb);
				
				var result = iItemMiscReceiptSetVarsExt.ItemMiscReceiptSetVarsSp(SET,
				                                                                 P_Item,
				                                                                 P_Whse,
				                                                                 P_Qty,
				                                                                 P_UM,
				                                                                 P_MatlCost,
				                                                                 P_LbrCost,
				                                                                 P_FovhdCost,
				                                                                 P_VovhdCost,
				                                                                 P_OutCost,
				                                                                 P_UnitCost,
				                                                                 P_Loc,
				                                                                 P_Lot,
				                                                                 P_Reason,
				                                                                 P_Acct,
				                                                                 P_AcctUnit1,
				                                                                 P_AcctUnit2,
				                                                                 P_AcctUnit3,
				                                                                 P_AcctUnit4,
				                                                                 P_TransDate,
				                                                                 Infobar,
				                                                                 DocumentNum,
				                                                                 P_ImportDocId,
				                                                                 ContainerNum,
				                                                                 UMVendNum,
				                                                                 UMArea);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}



		[IDOMethod(MethodFlags.None, "Infobar")]
		public int ItemMiscReceiptSp(string P_Item,
		string P_Whse,
		decimal? P_Qty,
		string P_UM,
		decimal? P_MatlCost,
		decimal? P_LbrCost,
		decimal? P_FovhdCost,
		decimal? P_VovhdCost,
		decimal? P_OutCost,
		decimal? P_UnitCost,
		string P_Loc,
		string P_Lot,
		string P_Reason,
		string P_Acct,
		string P_AcctUnit1,
		string P_AcctUnit2,
		string P_AcctUnit3,
		string P_AcctUnit4,
		DateTime? P_TransDate,
		ref string Infobar,
		[Optional] string DocumentNum,
		string P_ImportDocId,
		string ContainerNum,
		[Optional] string UMVendNum,
		[Optional] string UMArea)
		{
			using(var MGAppDB = this.CreateAppDB())
			{
				var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
				
				var mgInvoker = new MGInvoker(this.Context);
				
				var iItemMiscReceiptExt = new ItemMiscReceiptFactory().Create(appDb,
				mgInvoker,
				new CSI.Data.SQL.SQLParameterProvider(),
				true);
				
				var result = iItemMiscReceiptExt.ItemMiscReceiptSp(P_Item,
				P_Whse,
				P_Qty,
				P_UM,
				P_MatlCost,
				P_LbrCost,
				P_FovhdCost,
				P_VovhdCost,
				P_OutCost,
				P_UnitCost,
				P_Loc,
				P_Lot,
				P_Reason,
				P_Acct,
				P_AcctUnit1,
				P_AcctUnit2,
				P_AcctUnit3,
				P_AcctUnit4,
				P_TransDate,
				Infobar,
				DocumentNum,
				P_ImportDocId,
				ContainerNum,
				UMVendNum,
				UMArea);
				
				int Severity = result.ReturnCode.Value;
				Infobar = result.Infobar;
				return Severity;
			}
		}
    }
}
