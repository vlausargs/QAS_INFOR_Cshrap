//PROJECT NAME: MaterialExt
//CLASS NAME: SLContainerItems.cs

using CSI.Data.SQL.UDDT;
using System;
using System.Data;
using Mongoose.IDO;
using Mongoose.IDO.Protocol;
using CSI.Material;
using CSI.MG;
using System.Runtime.InteropServices;
using CSI.Data.RecordSets;
using CSI.ExternalContracts.FactoryTrack;

namespace CSI.MG.Material
{
    [IDOExtensionClass("SLContainerItems")]
    public class SLContainerItems : CSIExtensionClassBase, IExtFTSLContainerItems
    {
        [IDOMethod(MethodFlags.CustomLoad, "Infobar")]
        public DataTable AU_GetContainerContentSp(string PContainerNum,
                                                          ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());
                var bunchedLoadCollection = new CSIAppDBFactory().CreateLoadCollectionDatabase(MGAppDB, (LoadCollectionDataBase)this.Context.Request);

                var iAU_GetContainerContentExt = new AU_GetContainerContentFactory().Create(appDb, bunchedLoadCollection);

                Infobar oInfobar = Infobar;

                DataTable dt = iAU_GetContainerContentExt.AU_GetContainerContentSp(PContainerNum,
                                                                             ref oInfobar);

                Infobar = oInfobar;


                return dt;
            }
        }

        [IDOMethod(MethodFlags.None, "Infobar")]
        public int ValidateSerailTrackedItemForContainerSp(string PItem,
                                                           string PContainerNum,
                                                           ref string Infobar)
        {
            var iValidateSerailTrackedItemForContainerExt = new ValidateSerailTrackedItemForContainerFactory().Create(this, true);

            var result = iValidateSerailTrackedItemForContainerExt.ValidateSerailTrackedItemForContainerSp(PItem,
                PContainerNum,
                Infobar);

            Infobar = result.Infobar;

            return result.ReturnCode ?? 0;
        }

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
        public int ValidateContainerItemsSp(string ContainerNum,
                                            string CurWhse,
                                            string RefType,
                                            [Optional] string RefNum,
                                            [Optional] short? RefLineSuf,
                                            [Optional] short? RefRelease,
                                            [Optional, DefaultParameterValue((byte)0)] byte? MessageContentFlg,
        ref string PromptMsg,
        ref string PromptButtons,
        ref string Infobar,
        [Optional, DefaultParameterValue((byte)0)] byte? VerifyQtyFlag,
        [Optional, DefaultParameterValue((byte)0)] byte? ExtScrap,
        [Optional] string TransType)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var iValidateContainerItemsExt = new ValidateContainerItemsFactory().Create(appDb);

                var result = iValidateContainerItemsExt.ValidateContainerItemsSp(ContainerNum,
                                                                                 CurWhse,
                                                                                 RefType,
                                                                                 RefNum,
                                                                                 RefLineSuf,
                                                                                 RefRelease,
                                                                                 MessageContentFlg,
                                                                                 PromptMsg,
                                                                                 PromptButtons,
                                                                                 Infobar,
                                                                                 VerifyQtyFlag,
                                                                                 ExtScrap,
                                                                                 TransType);

                int Severity = result.ReturnCode.Value;
                PromptMsg = result.PromptMsg;
                PromptButtons = result.PromptButtons;
                Infobar = result.Infobar;
                return Severity;
            }
        }


        [IDOMethod(MethodFlags.None, "Infobar")]
        public int GetQtyDetlForContainerSp(string ContainNum,
        string Whse,
        string Loc,
        string Item,
        string Lot,
        ref decimal? TotalQtyContained,
        ref decimal? OtherQtyContained,
        ref decimal? QtyOnHand,
        ref decimal? QtyRvsd,
        ref decimal? ForUseQtyContained,
        ref decimal? QtyContained,
        ref string Infobar)
        {
            using (var MGAppDB = this.CreateAppDB())
            {
                var appDb = new CSIAppDBFactory().CreateAppDB(MGAppDB, this.Context, this.GetMessageProvider());

                var mgInvoker = new MGInvoker(this.Context);

                var iGetQtyDetlForContainerExt = new GetQtyDetlForContainerFactory().Create(appDb,
                mgInvoker,
                new CSI.Data.SQL.SQLParameterProvider(),
                true);

                var result = iGetQtyDetlForContainerExt.GetQtyDetlForContainerSp(ContainNum,
                Whse,
                Loc,
                Item,
                Lot,
                TotalQtyContained,
                OtherQtyContained,
                QtyOnHand,
                QtyRvsd,
                ForUseQtyContained,
                QtyContained,
                Infobar);

                int Severity = result.ReturnCode.Value;
                TotalQtyContained = result.TotalQtyContained;
                OtherQtyContained = result.OtherQtyContained;
                QtyOnHand = result.QtyOnHand;
                QtyRvsd = result.QtyRvsd;
                ForUseQtyContained = result.ForUseQtyContained;
                QtyContained = result.QtyContained;
                Infobar = result.Infobar;
                return Severity;
            }
        }
    }
}
